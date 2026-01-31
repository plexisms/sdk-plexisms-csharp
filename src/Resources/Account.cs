namespace Plexisms.Resources;

/// <summary>
/// Resource for managing account-related operations.
/// </summary>
public class Account : BaseResource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Account"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public Account(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Retrieves the current account balance.
    /// </summary>
    /// <returns>A <see cref="BalanceResponse"/> containing the balance and currency.</returns>
    public async Task<BalanceResponse> GetBalanceAsync()
    {
        return await SendRequestAsync<BalanceResponse>(HttpMethod.Get, "/api/sms/balance/");
    }
}
