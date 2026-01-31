namespace Plexisms;

public class PlexismsClient
{
    private const string DefaultBaseUrl = "https://server.plexisms.com";
    private readonly HttpClient _httpClient;

    public Messages Messages { get; }
    public Otp Otp { get; }
    public Account Account { get; }

    public PlexismsClient(string apiKey, string baseUrl = null)
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
