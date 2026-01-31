using System;

namespace KeyAuth;

/// <summary>
/// Options for configuring KeyAuth client
/// </summary>
/// <remarks>
/// Creates a new instance of KeyAuthClientOptions
/// </remarks>
/// <param name="appName">Application name</param>
/// <param name="ownerId">Application OwnerID (must be 10 characters)</param>
public class KeyAuthClientOptions(string appName, string ownerId)
{
    /// <summary>
    /// Application name
    /// </summary>
    public string AppName { get; private set; } = appName ?? throw new ArgumentNullException(nameof(appName));

    /// <summary>
    /// Application OwnerID (must be 10 characters)
    /// </summary>
    public string OwnerId { get; private set; } = ownerId ?? throw new ArgumentNullException(nameof(ownerId));

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
}

