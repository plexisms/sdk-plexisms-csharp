using System.Text;

namespace Plexisms.Resources;

public abstract class BaseResource
{
    protected readonly HttpClient HttpClient;

    protected BaseResource(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    protected async Task<T> SendRequestAsync<T>(HttpMethod method, string path, object body = null)
    {
        var request = new HttpRequestMessage(method, path);

        if (body != null)
        {
            var json = JsonConvert.SerializeObject(body, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await HttpClient.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            HandleError(response, responseBody);
        }

        return JsonConvert.DeserializeObject<T>(responseBody);
    }

    private void HandleError(HttpResponseMessage response, string responseBody)
    {
        string message = "Unknown Error";
        try
        {
            // Try to parse error message from JSON
            dynamic errorObj = JsonConvert.DeserializeObject(responseBody);
            if (errorObj != null)
            {
                message = errorObj.error ?? errorObj.detail ?? errorObj.message ?? message;
            }
        }
        catch
        {
            // If parsing fails, use raw body or default message
            if (!string.IsNullOrWhiteSpace(responseBody))
            {
                message = responseBody;
            }
        }

        int statusCode = (int)response.StatusCode;

        if (statusCode == 401 || statusCode == 403)
        {
            throw new AuthenticationException($"Unauthorized: {message}");
        }
        else if (statusCode == 402)
        {
            throw new BalanceException($"Insufficient funds: {message}");
        }
        else
        {
            throw new ApiException($"API Error ({statusCode}): {message}", statusCode, responseBody);
        }
    }
}
