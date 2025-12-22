using KeyAuth.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KeyAuth
{
    /// <summary>
    /// KeyAuth API client implementation using HttpClient
    /// </summary>
    public class KeyAuthClient : IKeyAuthClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClientHandler _handler;

        /// <summary>
        /// Client options
        /// </summary>
        public KeyAuthClientOptions Options { get; }

        /// <summary>
        /// Current session ID (set after successful initialization)
        /// </summary>
        public string? SessionId { get; private set; }

        public KeyAuthClient(KeyAuthClientOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));

            _handler = new HttpClientHandler
            {
                Proxy = Options.Proxy
            };

            _httpClient = new HttpClient(_handler)
            {
                Timeout = Options.Timeout
            };

            if (Options.ValidateSslCertificate)
                _handler.ServerCertificateCustomValidationCallback = AssertSsl;
        }

        /// <summary>
        /// Sends an HTTP request and returns the deserialized response
        /// </summary>
        public async Task<TResponse> SendRequest<TResponse>(HttpRequestMessage request) where TResponse : ResponseBase
        {
            try
            {
                // Check for file manipulation
                if (Options.EnableFileCheck && FileCheck(Options.FileCheckDomain))
                {
                    throw new KeyAuthException("File manipulation detected. Terminating process.");
                }

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw response.StatusCode switch
                    {
                        // Rate Limited
                        HttpStatusCode.TooManyRequests => new KeyAuthConnectionException("You're connecting too fast to loader, slow down"),
                        _ => new KeyAuthConnectionException("Connection failure. Please try again, or contact us for help."),
                    };
                }

                string rawResponse = await response.Content.ReadAsStringAsync();

                // Handle case when server returns a string instead of JSON
                if (rawResponse == "KeyAuth_Invalid")
                {
                    var invalidResponse = Activator.CreateInstance<TResponse>();
                    invalidResponse.Success = false;
                    invalidResponse.Message = "KeyAuth_Invalid";
                    return invalidResponse;
                }

                // Signature verification
                var headers = new WebHeaderCollection();
                if (response.Headers.TryGetValues("x-signature-ed25519", out IEnumerable<string> signatureValues))
                    headers["x-signature-ed25519"] = signatureValues.FirstOrDefault();

                if (response.Headers.TryGetValues("x-signature-timestamp", out IEnumerable<string> timeStampValues))
                    headers["x-signature-timestamp"] = timeStampValues.FirstOrDefault();

                // Get request type from request properties
                string requestType = "unknown";
                if (request.Properties.ContainsKey("RequestType"))
                {
                    requestType = request.Properties["RequestType"].ToString();
                }

                SigCheck(rawResponse, headers, requestType);

                // Direct deserialization into TResponse via JSON
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    var result = JsonSerializer.Deserialize<TResponse>(rawResponse, options);
                    return result ?? throw new KeyAuthConnectionException("Failed to deserialize server response. Response was null.");
                }
                catch (JsonException jsonEx)
                {
                    throw new KeyAuthConnectionException($"Failed to deserialize server response. Invalid JSON format. Response: {rawResponse}", jsonEx);
                }
            }
            catch (KeyAuthException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new KeyAuthConnectionException("Connection failure. Please try again, or contact us for help.", ex);
            }
        }

        private static bool FileCheck(string domain)
        {
            try
            {
                var address = Dns.GetHostAddresses(domain);
                foreach (var addr in address)
                {
                    if (IPAddress.IsLoopback(addr) || IsPrivateIP(addr))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return true;
            }
        }

        private static bool IsPrivateIP(IPAddress ip)
        {
            byte[] bytes = ip.GetAddressBytes();

            // 10.0.0.0/8
            if (bytes[0] == 10)
                return true;

            // 172.16.0.0/12
            if (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] < 32)
                return true;

            // 192.168.0.0/16
            if (bytes[0] == 192 && bytes[1] == 168)
                return true;

            return false;
        }

        private static bool AssertSsl(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if ((!certificate.Issuer.Contains("Google Trust Services") && !certificate.Issuer.Contains("Let's Encrypt")) || sslPolicyErrors != SslPolicyErrors.None)
            {
                throw new KeyAuthSslException("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. If not, ask the developer of the program to use custom domains to fix this.");
            }

            return true;
        }

        private static void SigCheck(string resp, WebHeaderCollection headers, string type)
        {
            if (type == "log" || type == "file" || type == "2faenable" || type == "2fadisable")
            {
                return;
            }

            try
            {
                string signature = headers["x-signature-ed25519"];
                string timestamp = headers["x-signature-timestamp"];

                if (string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp))
                {
                    throw new KeyAuthSignatureException("Missing signature or timestamp in response headers.");
                }

                // Try to parse the input string to a long Unix timestamp
                if (!long.TryParse(timestamp, out long unixTimestamp))
                {
                    throw new KeyAuthSignatureException("Failed to parse the timestamp from the server. Please ensure your device's date and time settings are correct.");
                }

                // Convert the Unix timestamp to a DateTime object (in UTC)
                DateTime timestampTime = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;

                // Get the current UTC time
                DateTime currentTime = DateTime.UtcNow;

                // Calculate the difference between the current time and the timestamp
                TimeSpan timeDifference = currentTime - timestampTime;

                // Check if the timestamp is within 20 seconds of the current time
                if (timeDifference.TotalSeconds > 20)
                {
                    throw new KeyAuthSignatureException("Date/Time settings aren't synced on your device, please sync them to use the program");
                }

                var byteSig = EncryptionHelper.ToByteArray(signature);
                var byteKey = EncryptionHelper.ToByteArray("5586b4bc69c7a4b487e4563a4cd96afd39140f919bd31cea7d1c6a1e8439422b");
                string body = timestamp + resp;
                var byteBody = Encoding.Default.GetBytes(body);

                bool signatureValid = Ed25519.CheckValid(byteSig, byteBody, byteKey);
                if (!signatureValid)
                {
                    throw new KeyAuthSignatureException("Signature checksum failed. Request was tampered with or session ended most likely. Response: " + resp);
                }
            }
            catch (KeyAuthException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new KeyAuthSignatureException("Signature checksum failed. Request was tampered with or session ended most likely. Response: " + resp, ex);
            }
        }

        /// <summary>
        /// Sets the session ID (internal method for use by extension methods)
        /// </summary>
        internal void SetSessionId(string sessionId)
        {
            SessionId = sessionId;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
            _handler?.Dispose();
        }
    }
}

