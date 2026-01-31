namespace Plexisms.Exceptions;

public class PlexismsException : Exception
{
    public PlexismsException(string message) : base(message) { }
    public PlexismsException(string message, Exception innerException) : base(message, innerException) { }
}

public class AuthenticationException : PlexismsException
{
    public AuthenticationException(string message) : base(message) { }
}

public class BalanceException : PlexismsException
{
    public BalanceException(string message) : base(message) { }
}

public class ApiException : PlexismsException
{
    public int StatusCode { get; }
    public string ResponseBody { get; }

    public ApiException(string message, int statusCode, string responseBody) : base(message)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}
