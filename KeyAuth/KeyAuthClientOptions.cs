using System;

namespace KeyAuth;

/// <summary>
/// Options for configuring KeyAuth client
/// </summary>
public class KeyAuthClientOptions
{
    /// <summary>
    /// Application name
    /// </summary>
    public string AppName { get; set; }

    /// <summary>
    /// Application OwnerID (must be 10 characters)
    /// </summary>
    public string OwnerId { get; set; }

    /// <summary>
    /// Application version
    /// </summary>
    public string AppVersion { get; set; } = "1.0";

    /// <summary>
    /// Base URL for API requests
    /// </summary>
    public string BaseUrl { get; set; } = "https://keyauth.win/api/1.3/";

    /// <summary>
    /// Timeout for HTTP requests
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(20);

    /// <summary>
    /// Proxy to use (null = no proxy)
    /// </summary>
    public System.Net.IWebProxy? Proxy { get; set; } = null;

    /// <summary>
    /// Enable SSL certificate validation
    /// </summary>
    public bool ValidateSslCertificate { get; set; } = true;

    /// <summary>
    /// Enable file manipulation check
    /// </summary>
    public bool EnableFileCheck { get; set; } = true;

    /// <summary>
    /// Domain name for file check
    /// </summary>
    public string FileCheckDomain { get; set; } = "keyauth.win";

    /// <summary>
    /// Creates a new instance of KeyAuthClientOptions
    /// </summary>
    /// <param name="appName">Application name</param>
    /// <param name="ownerId">Application OwnerID (must be 10 characters)</param>
    public KeyAuthClientOptions(string appName, string ownerId) : base()
    {
        AppName = appName ?? throw new ArgumentNullException(nameof(appName));
        OwnerId = ownerId ?? throw new ArgumentNullException(nameof(ownerId));
    }

    /// <summary>
    /// Creates a new instance of KeyAuthClientOptions.
    /// </summary>
    public KeyAuthClientOptions() : base()
    {
        AppName = string.Empty;
        OwnerId = string.Empty;
    }
}

