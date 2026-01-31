using KeyAuth.Requests;
using KeyAuth.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace KeyAuth;

/// <summary>
/// Extension methods for IKeyAuthClient
/// </summary>
public static class KeyAuthExtensions
{
    /// <summary>
    /// Initializes KeyAuth
    /// </summary>
    /// <param name="client"></param>
    /// <param name="tokenPath">Optional path to token file</param>
    /// <param name="cancellationToken"></param>
    public static async Task<InitResponse> InitAsync(this IKeyAuthClient client, string? tokenPath = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;

        if (string.IsNullOrEmpty(options.OwnerId) || options.OwnerId.Length != 10)
        {
            throw new KeyAuthSetupException("Application not setup correctly. OwnerID must be 10 characters long.");
        }

        if (string.IsNullOrEmpty(options.AppName))
        {
            throw new KeyAuthSetupException("Application name is required.");
        }

        var request = new InitRequest
        {
            Name = options.AppName,
            OwnerId = options.OwnerId,
            Version = options.AppVersion,
            TokenPath = tokenPath
        };

        var httpRequest = request.ToRequestMessage(options.BaseUrl, null, options.AppName, options.OwnerId);
        var response = await client.SendRequest<InitResponse>(httpRequest, cancellationToken);

        // Check for KeyAuth_Invalid (when server returns a string instead of JSON)
        if (response.Message == "KeyAuth_Invalid" || (!response.Success && response.Message == null))
        {
            throw new KeyAuthAuthenticationException("Application not found");
        }

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        // Handle invalidver - version mismatch
        if (!response.Success && response.Message == "invalidver")
        {
            // DownloadLink will already be populated from the response
            throw new KeyAuthAuthenticationException($"Invalid version. Download link: {response.DownloadLink ?? "N/A"}");
        }

        // Store session ID after successful initialization
        if (response.Success && !string.IsNullOrEmpty(response.SessionId))
        {
            client.SetSessionId(response.SessionId);
        }

        return response;
    }

    /// <summary>
    /// Authenticates user with username and password
    /// </summary>
    public static async Task<LoginResponse> LoginAsync(this IKeyAuthClient client, string username, string password, string? code = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new LoginRequest
        {
            Username = username,
            Password = password,
            Code = code
        };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<LoginResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        // Update session ID if it changed
        if (!string.IsNullOrEmpty(response.SessionId) && client is KeyAuthClient keyAuthClient)
        {
            keyAuthClient.SetSessionId(response.SessionId);
        }

        return response;
    }

    /// <summary>
    /// Registers a new user
    /// </summary>
    public static async Task<RegisterResponse> RegisterAsync(this IKeyAuthClient client, string username, string password, string key, string? email = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new RegisterRequest
        {
            Username = username,
            Password = password,
            Key = key,
            Email = email
        };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<RegisterResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        // Update session ID if it changed
        if (!string.IsNullOrEmpty(response.SessionId) && client is KeyAuthClient keyAuthClient)
        {
            keyAuthClient.SetSessionId(response.SessionId);
        }

        return response;
    }

    /// <summary>
    /// Logs out the user
    /// </summary>
    public static async Task<LogoutResponse> LogoutAsync(this IKeyAuthClient client, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new LogoutRequest();
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<LogoutResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Authenticates user with license key
    /// </summary>
    public static async Task<LicenseResponse> LicenseAsync(this IKeyAuthClient client, string key, string? code = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new LicenseRequest
        {
            Key = key,
            Code = code
        };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<LicenseResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        // Update session ID if it changed
        if (!string.IsNullOrEmpty(response.SessionId) && client is KeyAuthClient keyAuthClient)
        {
            keyAuthClient.SetSessionId(response.SessionId);
        }

        return response;
    }

    /// <summary>
    /// Checks if the session is valid
    /// </summary>
    public static async Task<CheckResponse> CheckAsync(this IKeyAuthClient client, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new CheckRequest();
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<CheckResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Gets a user variable
    /// </summary>
    public static async Task<GetVarResponse> GetVarAsync(this IKeyAuthClient client, string varName, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new GetVarRequest { VarName = varName };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<GetVarResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Sets a user variable
    /// </summary>
    public static async Task<SetVarResponse> SetVarAsync(this IKeyAuthClient client, string varName, string data, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new SetVarRequest { VarName = varName, Data = data };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<SetVarResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Gets a global variable
    /// </summary>
    public static async Task<VarResponse> VarAsync(this IKeyAuthClient client, string varId, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new VarRequest { VarId = varId };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<VarResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Fetches list of online users
    /// </summary>
    public static async Task<FetchOnlineResponse> FetchOnlineAsync(this IKeyAuthClient client, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new FetchOnlineRequest();
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<FetchOnlineResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Fetches application statistics
    /// </summary>
    public static async Task<FetchStatsResponse> FetchStatsAsync(this IKeyAuthClient client, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new FetchStatsRequest();
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<FetchStatsResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Gets messages from chat channel
    /// </summary>
    public static async Task<ChatGetResponse> ChatGetAsync(this IKeyAuthClient client, string channelName, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new ChatGetRequest { ChannelName = channelName };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<ChatGetResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Sends a message to chat channel
    /// </summary>
    public static async Task<ChatSendResponse> ChatSendAsync(this IKeyAuthClient client, string message, string channelName, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new ChatSendRequest { Message = message, ChannelName = channelName };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<ChatSendResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Checks if the current IP/HWID is blacklisted
    /// </summary>
    public static async Task<CheckBlackResponse> CheckBlackAsync(this IKeyAuthClient client, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new CheckBlackRequest();
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<CheckBlackResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Calls a webhook
    /// </summary>
    public static async Task<WebhookResponse> WebhookAsync(this IKeyAuthClient client, string webId, string? @params = null, string? body = null, string? contentType = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new WebhookRequest
        {
            WebId = webId,
            Params = @params,
            Body = body,
            ContentType = contentType
        };

        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<WebhookResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Downloads a file
    /// </summary>
    public static async Task<DownloadResponse> DownloadAsync(this IKeyAuthClient client, string fileId, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new DownloadRequest { FileId = fileId };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<DownloadResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Logs an event
    /// </summary>
    public static async Task LogAsync(this IKeyAuthClient client, string message, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new LogRequest { Message = message };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        await client.SendRequest<LogResponse>(httpRequest, cancellationToken);
    }

    /// <summary>
    /// Changes the username
    /// </summary>
    public static async Task<ChangeUsernameResponse> ChangeUsernameAsync(this IKeyAuthClient client, string newUsername, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new ChangeUsernameRequest { NewUsername = newUsername };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<ChangeUsernameResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Sends password recovery email
    /// </summary>
    public static async Task<ForgotResponse> ForgotAsync(this IKeyAuthClient client, string username, string email, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new ForgotRequest { Username = username, Email = email };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<ForgotResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Upgrades user subscription
    /// </summary>
    public static async Task<UpgradeResponse> UpgradeAsync(this IKeyAuthClient client, string username, string key, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new UpgradeRequest { Username = username, Key = key };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<UpgradeResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }

    /// <summary>
    /// Enables two-factor authentication
    /// </summary>
    public static async Task<Enable2FaResponse> Enable2FaAsync(this IKeyAuthClient client, string? code = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new Enable2FaRequest { Code = code };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<Enable2FaResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Disables two-factor authentication
    /// </summary>
    public static async Task<Disable2FaResponse> Disable2FaAsync(this IKeyAuthClient client, string code, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new Disable2FaRequest { Code = code };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<Disable2FaResponse>(httpRequest, cancellationToken);

        return response;
    }

    /// <summary>
    /// Bans the current logged-in user
    /// </summary>
    public static async Task<BanResponse> BanAsync(this IKeyAuthClient client, string? reason = null, CancellationToken cancellationToken = default)
    {
        var options = client.Options;
        var request = new BanRequest { Reason = reason };
        var httpRequest = request.ToRequestMessage(options.BaseUrl, client.SessionId, options.AppName, options.OwnerId);
        var response = await client.SendRequest<BanResponse>(httpRequest, cancellationToken);

        if (response.OwnerId != options.OwnerId)
        {
            throw new KeyAuthAuthenticationException("OwnerID mismatch");
        }

        return response;
    }
}

