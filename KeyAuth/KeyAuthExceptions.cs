using System;

namespace KeyAuth;

/// <summary>
/// Base exception for KeyAuth
/// </summary>
public class KeyAuthException(string message, Exception? innerException = null) : Exception(message, innerException);

/// <summary>
/// Exception thrown when application is not configured correctly
/// </summary>
public class KeyAuthSetupException(string message) : KeyAuthException(message);

/// <summary>
/// Exception thrown when connection error occurs
/// </summary>
public class KeyAuthConnectionException(string message, Exception? innerException = null) : KeyAuthException(message, innerException);

/// <summary>
/// Exception thrown when authentication fails
/// </summary>
public class KeyAuthAuthenticationException(string message) : KeyAuthException(message);

/// <summary>
/// Exception thrown when signature verification fails
/// </summary>
public class KeyAuthSignatureException(string message, Exception? innerException = null) : KeyAuthException(message, innerException);

/// <summary>
/// Exception thrown when SSL validation fails
/// </summary>
public class KeyAuthSslException(string message) : KeyAuthException(message);
