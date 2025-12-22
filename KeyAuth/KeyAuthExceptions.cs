using System;

namespace KeyAuth
{
    /// <summary>
    /// Base exception for KeyAuth
    /// </summary>
    public class KeyAuthException : Exception
    {
        public KeyAuthException(string message) : base(message)
        {
        }

        public KeyAuthException(string message, Exception? innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception thrown when application is not configured correctly
    /// </summary>
    public class KeyAuthSetupException : KeyAuthException
    {
        public KeyAuthSetupException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Exception thrown when connection error occurs
    /// </summary>
    public class KeyAuthConnectionException : KeyAuthException
    {
        public KeyAuthConnectionException(string message) : base(message)
        {
        }

        public KeyAuthConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Exception thrown when authentication fails
    /// </summary>
    public class KeyAuthAuthenticationException : KeyAuthException
    {
        public KeyAuthAuthenticationException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Exception thrown when signature verification fails
    /// </summary>
    public class KeyAuthSignatureException : KeyAuthException
    {
        public KeyAuthSignatureException(string message) : base(message)
        {
        }

        public KeyAuthSignatureException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Exception thrown when SSL validation fails
    /// </summary>
    public class KeyAuthSslException : KeyAuthException
    {
        public KeyAuthSslException(string message) : base(message)
        {
        }
    }
}

