using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Reflection;

namespace KeyAuth;

/// <summary>
/// Attribute for specifying the API parameter name
/// </summary>
/// <remarks>
/// Creates a new instance of the ApiParameterAttribute
/// </remarks>
/// <param name="name">The name of the API parameter</param>
[AttributeUsage(AttributeTargets.Property)]
public class ApiParameterAttribute(string name) : Attribute
{
    /// <summary>
    /// The name of the API parameter
    /// </summary>
    public string Name { get; } = name;
}

/// <summary>
/// Attribute to indicate that a property should be ignored during serialization
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class IgnoreApiParameterAttribute : Attribute;

/// <summary>
/// Base class for all KeyAuth API requests
/// </summary>
/// <typeparam name="TResponse">The response type expected from this request</typeparam>
public abstract class RequestBase<TResponse> where TResponse : ResponseBase
{
    /// <summary>
    /// Request type (init, login, register, etc.)
    /// </summary>
    [IgnoreApiParameter]
    public abstract string Type { get; }

    /// <summary>
    /// Gets additional parameters that are not class properties (e.g., hwid, hash)
    /// </summary>
    /// <param name="sessionId">The current session ID</param>
    /// <param name="name">The application name</param>
    /// <param name="ownerId">The application owner ID</param>
    /// <returns>A collection of additional parameters</returns>
    protected virtual NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
    {
        return [];
    }

    /// <summary>
    /// Creates an HttpRequestMessage from the request with automatic property serialization
    /// </summary>
    /// <param name="baseUrl">The base URL for the API</param>
    /// <param name="sessionId">The current session ID</param>
    /// <param name="name">The application name</param>
    /// <param name="ownerId">The application owner ID</param>
    /// <returns>An HttpRequestMessage</returns>
    public HttpRequestMessage ToRequestMessage(string baseUrl, string? sessionId, string name, string ownerId)
    {
        var parameters = new NameValueCollection
        {
            ["type"] = Type
        };

        // Add standard parameters
        if (!string.IsNullOrEmpty(sessionId))
        {
            parameters["sessionid"] = sessionId;
        }
        if (!string.IsNullOrEmpty(name))
        {
            parameters["name"] = name;
        }
        if (!string.IsNullOrEmpty(ownerId))
        {
            parameters["ownerid"] = ownerId;
        }

        // Serialize class properties
        var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            // Skip properties with IgnoreApiParameter attribute
            if (property.GetCustomAttribute<IgnoreApiParameterAttribute>() != null)
            {
                continue;
            }

            var value = property.GetValue(this);
            if (value == null)
            {
                continue;
            }

            // Get parameter name from attribute or use property name in lowercase
            var apiParamAttr = property.GetCustomAttribute<ApiParameterAttribute>();
            var paramName = apiParamAttr?.Name ?? property.Name.ToLowerInvariant();

            // Convert value to string
            string stringValue = value switch
            {
                string str => str,
                bool b => b.ToString().ToLowerInvariant(),
                _ => value.ToString()
            };

            if (!string.IsNullOrEmpty(stringValue))
            {
                parameters[paramName] = stringValue;
            }
        }

        // Add additional parameters
        var additionalParams = GetAdditionalParameters(sessionId, name, ownerId);
        foreach (string key in additionalParams)
        {
            parameters[key] = additionalParams[key];
        }

        // Create form data
        var formData = new List<KeyValuePair<string, string>>();
        foreach (string key in parameters)
        {
            formData.Add(new KeyValuePair<string, string>(key, parameters[key]));
        }

        var content = new FormUrlEncodedContent(formData);
        var request = new HttpRequestMessage(HttpMethod.Post, baseUrl)
        {
            Content = content
        };

        // Store request type for signature verification
        // Use Properties for .NET Standard 2.1 compatibility
        request.Properties["RequestType"] = Type;
        return request;
    }
}

