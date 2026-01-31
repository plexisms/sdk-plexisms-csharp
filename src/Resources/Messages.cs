using System.Collections.Generic;

namespace Plexisms.Resources;

public class Messages : BaseResource
{
    public Messages(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Send a single SMS
    /// </summary>
    public async Task<SmsResponse> SendAsync(string to, string message, string senderId = null, string smsType = "transactional")
    {
        var request = new SendSmsRequest
        {
            PhoneNumber = to,
            Message = message,
            SenderId = senderId,
            SmsType = smsType
        };

        return await SendRequestAsync<SmsResponse>(HttpMethod.Post, "/api/sms/send/", request);
    }

    /// <summary>
    /// Send bulk SMS
    /// </summary>
    public async Task<BulkSmsResponse> SendBulkAsync(List<string> phoneNumbers, string message, string senderId = null, string smsType = "transactional")
    {
        var request = new SendBulkSmsRequest
        {
            PhoneNumbers = phoneNumbers,
            Message = message,
            SenderId = senderId,
            SmsType = smsType
        };

        return await SendRequestAsync<BulkSmsResponse>(HttpMethod.Post, "/api/sms/send-bulk/", request);
    }

    /// <summary>
    /// Get SMS status
    /// </summary>
    public async Task<MessageStatusResponse> GetStatusAsync(string messageId)
    {
        return await SendRequestAsync<MessageStatusResponse>(HttpMethod.Get, $"/api/sms/{messageId}/status/");
    }
}
