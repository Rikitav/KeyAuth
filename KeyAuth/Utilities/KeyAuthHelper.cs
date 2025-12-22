using System;
using System.IO;
using System.Security.Cryptography;

namespace KeyAuth.Utilities
{
    /// <summary>
    /// Helper methods for KeyAuth
    /// </summary>
    public static class KeyAuthHelper
    {
        /// <summary>
        /// Calculates MD5 hash of a file
        /// </summary>
        public static string Checksum(string filename)
        {
            string result;
            using (MD5 md = MD5.Create())
            {
                using (FileStream fileStream = File.OpenRead(filename))
                {
                    byte[] value = md.ComputeHash(fileStream);
                    result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates SHA256 hash of token from file
        /// </summary>
        public static string TokenHash(string tokenPath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var s = File.OpenRead(tokenPath))
                {
                    byte[] bytes = sha256.ComputeHash(s);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }

        /// <summary>
        /// Converts Unix timestamp to DateTime
        /// </summary>
        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;
        }

        /// <summary>
        /// Calculates days remaining until subscription expiry
        /// </summary>
        public static string ExpiryDaysLeft(SubscriptionData subscription)
        {
            if (subscription.Expiry == null)
                return "0 Days 0 Hours Left";

            DateTime dtDateTime = UnixTimeToDateTime(long.Parse(subscription.Expiry));
            TimeSpan difference = dtDateTime - DateTime.Now;
            return Convert.ToString(difference.Days + " Days " + difference.Hours + " Hours Left");
        }
    }
}

