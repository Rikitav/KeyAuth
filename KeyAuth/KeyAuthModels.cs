using KeyAuth.Utilities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth;

/// <summary>
/// Represents a chat message
/// </summary>
public class MessageEntity
{
    /// <summary>
    /// The message content
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The message author
    /// </summary>
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    /// <summary>
    /// The message timestamp
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }
}

/// <summary>
/// Represents a user
/// </summary>
public class User
{
    /// <summary>
    /// The user credential
    /// </summary>
    [JsonPropertyName("credential")]
    public string? Credential { get; set; }
}

/// <summary>
/// Represents user data
/// </summary>
public class UserDataStructure
{
    /// <summary>
    /// The username
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The user's IP address
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// The user's hardware ID
    /// </summary>
    [JsonPropertyName("hwid")]
    public string? Hwid { get; set; }

    /// <summary>
    /// The user's creation date
    /// </summary>
    [JsonPropertyName("createdate")]
    public string? Createdate { get; set; }

    /// <summary>
    /// The user's last login date
    /// </summary>
    [JsonPropertyName("lastlogin")]
    public string? Lastlogin { get; set; }

    /// <summary>
    /// The user's subscriptions
    /// </summary>
    [JsonPropertyName("subscriptions")]
    public List<SubscriptionData>? Subscriptions { get; set; }
}

/// <summary>
/// Represents a user subscription
/// </summary>
public class SubscriptionData
{
    /// <summary>
    /// The subscription name
    /// </summary>
    [JsonPropertyName("subscription")]
    public string? Subscription { get; set; }

    /// <summary>
    /// The subscription expiry date (Unix timestamp)
    /// </summary>
    [JsonPropertyName("expiry")]
    public string? Expiry { get; set; }

    /// <summary>
    /// The time left in seconds
    /// </summary>
    [JsonPropertyName("timeleft")]
    public long? Timeleft { get; set; }

    /// <summary>
    /// The subscription key
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The subscription expiration date
    /// </summary>
    public DateTime Expiration => Expiry != null ? KeyAuthHelper.UnixTimeToDateTime(long.Parse(Expiry)) : DateTime.MaxValue;
}

/// <summary>
/// Represents application data
/// </summary>
public class AppDataStructure
{
    /// <summary>
    /// The number of users
    /// </summary>
    [JsonPropertyName("numUsers")]
    public string? NumUsers { get; set; }

    /// <summary>
    /// The number of online users
    /// </summary>
    [JsonPropertyName("numOnlineUsers")]
    public string? NumOnlineUsers { get; set; }

    /// <summary>
    /// The number of keys
    /// </summary>
    [JsonPropertyName("numKeys")]
    public string? NumKeys { get; set; }

    /// <summary>
    /// The application version
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// The customer panel link
    /// </summary>
    [JsonPropertyName("customerPanelLink")]
    public string? CustomerPanelLink { get; set; }

    /// <summary>
    /// The download link
    /// </summary>
    [JsonPropertyName("downloadLink")]
    public string? DownloadLink { get; set; }
}

/// <summary>
/// Represents two-factor authentication data
/// </summary>
public class TwoFactorData
{
    /// <summary>
    /// The secret code for 2FA
    /// </summary>
    [JsonPropertyName("secret_code")]
    public string? SecretCode { get; set; }

    /// <summary>
    /// The QR code for 2FA
    /// </summary>
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

