namespace Plexisms.Resources;

public class Account : BaseResource
{
    public Account(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Check account balance
    /// </summary>
    public async Task<BalanceResponse> GetBalanceAsync()
    {
        return await SendRequestAsync<BalanceResponse>(HttpMethod.Get, "/api/sms/balance/");
    }
}
