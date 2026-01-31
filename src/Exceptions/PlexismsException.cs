namespace Plexisms.Exceptions;

/// <summary>
/// Base exception for errors occurring in the Plexisms SDK.
/// </summary>
public class PlexismsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlexismsException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PlexismsException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlexismsException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PlexismsException(string message, Exception innerException) : base(message, innerException) { }
}

/// <summary>
/// Exception thrown when API authentication fails.
/// </summary>
public class AuthenticationException : PlexismsException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationException"/> class.
    /// </summary>
    /// <param name="message">The authentication error message.</param>
    public AuthenticationException(string message) : base(message) { }
}

/// <summary>
/// Exception thrown when the account has insufficient funds.
/// </summary>
public class BalanceException : PlexismsException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BalanceException"/> class.
    /// </summary>
    /// <param name="message">The balance error message.</param>
    public BalanceException(string message) : base(message) { }
}

/// <summary>
/// Exception thrown for general API errors (e.g., validation failures, server errors).
/// </summary>
public class ApiException : PlexismsException
{
    /// <summary>
    /// The HTTP status code returned by the API.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// The raw response body returned by the API.
    /// </summary>
    public string ResponseBody { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="responseBody">The raw response body.</param>
    public ApiException(string message, int statusCode, string responseBody) : base(message)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}
