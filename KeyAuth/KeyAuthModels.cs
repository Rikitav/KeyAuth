using KeyAuth.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth
{
    public class MessageEntity
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }
    }

    public class User
    {
        [JsonPropertyName("credential")]
        public string? Credential { get; set; }
    }

    public class UserDataStructure
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("ip")]
        public string? Ip { get; set; }

        [JsonPropertyName("hwid")]
        public string? Hwid { get; set; }

        [JsonPropertyName("createdate")]
        public string? Createdate { get; set; }

        [JsonPropertyName("lastlogin")]
        public string? Lastlogin { get; set; }

        [JsonPropertyName("subscriptions")]
        public List<SubscriptionData>? Subscriptions { get; set; }
    }

    public class SubscriptionData
    {
        [JsonPropertyName("subscription")]
        public string? Subscription { get; set; }

        [JsonPropertyName("expiry")]
        public string? Expiry { get; set; }

        [JsonPropertyName("timeleft")]
        public long? Timeleft { get; set; }

        [JsonPropertyName("key")]
        public string? Key { get; set; }

        public DateTime Expiration => Expiry != null ? KeyAuthHelper.UnixTimeToDateTime(long.Parse(Expiry)) : DateTime.MaxValue;
    }

    public class AppDataStructure
    {
        [JsonPropertyName("numUsers")]
        public string? NumUsers { get; set; }

        [JsonPropertyName("numOnlineUsers")]
        public string? NumOnlineUsers { get; set; }

        [JsonPropertyName("numKeys")]
        public string? NumKeys { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("customerPanelLink")]
        public string? CustomerPanelLink { get; set; }

        [JsonPropertyName("downloadLink")]
        public string? DownloadLink { get; set; }
    }

    public class TwoFactorData
    {
        [JsonPropertyName("secret_code")]
        public string? SecretCode { get; set; }

        [JsonPropertyName("QRCode")]
        public string? QRCode { get; set; }
    }

    internal class UserDataStructureInternal
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("ip")]
        public string? Ip { get; set; }

        [JsonPropertyName("hwid")]
        public string? Hwid { get; set; }

        [JsonPropertyName("createdate")]
        public string? Createdate { get; set; }

        [JsonPropertyName("lastlogin")]
        public string? Lastlogin { get; set; }

        [JsonPropertyName("subscriptions")]
        public List<SubscriptionDataInternal>? Subscriptions { get; set; }
    }

    internal class AppDataStructureInternal
    {
        [JsonPropertyName("numUsers")]
        public string? NumUsers { get; set; }

        [JsonPropertyName("numOnlineUsers")]
        public string? NumOnlineUsers { get; set; }

        [JsonPropertyName("numKeys")]
        public string? NumKeys { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("customerPanelLink")]
        public string? CustomerPanelLink { get; set; }

        [JsonPropertyName("downloadLink")]
        public string? DownloadLink { get; set; }
    }

    internal class SubscriptionDataInternal
    {
        [JsonPropertyName("subscription")]
        public string? Subscription { get; set; }

        [JsonPropertyName("expiry")]
        public string? Expiry { get; set; }

        [JsonPropertyName("timeleft")]
        public long? Timeleft { get; set; }

        [JsonPropertyName("key")]
        public string? Key { get; set; }
    }

    internal class MessageInternal
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }
    }

    internal class UserInternal
    {
        [JsonPropertyName("credential")]
        public string? Credential { get; set; }
    }
}

