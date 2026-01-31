namespace Plexisms;

/// <summary>
/// The main client for interacting with the Plexisms API.
/// </summary>
public class PlexismsClient
{
    private const string DefaultBaseUrl = "https://server.plexisms.com";
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Resources for sending and managing SMS messages.
    /// </summary>
    public Messages Messages { get; }

    /// <summary>
    /// Resources for One-Time Password (OTP) verification.
    /// </summary>
    public Otp Otp { get; }

    /// <summary>
    /// Resources for account management (e.g., balance check).
    /// </summary>
    public Account Account { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlexismsClient"/> class.
    /// </summary>
    /// <param name="apiKey">Your Plexisms API Key. If null, attempts to load from defining environment variable PLEXISMS_API_KEY.</param>
    /// <param name="baseUrl">The base URL of the API. Defaults to https://server.plexisms.com.</param>
    public PlexismsClient(string? apiKey, string? baseUrl = null)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            // Fallback to environment variable
            apiKey = Environment.GetEnvironmentVariable("PLEXISMS_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API Key is required.", nameof(apiKey));
            }
        }

        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri((baseUrl ?? Environment.GetEnvironmentVariable("PLEXISMS_BASE_URL") ?? DefaultBaseUrl).TrimEnd('/'));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", apiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("plexisms-csharp/1.0.0");

        Messages = new Messages(_httpClient);
        Otp = new Otp(_httpClient);
        Account = new Account(_httpClient);
    }
}
