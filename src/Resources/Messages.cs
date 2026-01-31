using System.Collections.Generic;

namespace Plexisms.Resources;

/// <summary>
/// Resource for sending and managing SMS messages.
/// </summary>
public class Messages : BaseResource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Messages"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public Messages(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Sends a single SMS message.
    /// </summary>
    /// <param name="to">The recipient's phone number.</param>
    /// <param name="message">The content of the SMS message.</param>
    /// <param name="senderId">The sender ID (optional).</param>
    /// <param name="smsType">The type of SMS (default: "transactional").</param>
    /// <returns>A <see cref="SmsResponse"/> indicating the result.</returns>
    public async Task<SmsResponse> SendAsync(string to, string message, string? senderId = null, string smsType = "transactional")
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
    /// Sends bulk SMS messages to multiple recipients.
    /// </summary>
    /// <param name="phoneNumbers">A list of recipient phone numbers.</param>
    /// <param name="message">The content of the SMS message.</param>
    /// <param name="senderId">The sender ID (optional).</param>
    /// <param name="smsType">The type of SMS (default: "transactional").</param>
    /// <returns>A <see cref="BulkSmsResponse"/> indicating the result.</returns>
    public async Task<BulkSmsResponse> SendBulkAsync(List<string> phoneNumbers, string message, string? senderId = null, string smsType = "transactional")
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
    /// Retrieves the status of a specific message.
    /// </summary>
    /// <param name="messageId">The unique ID of the message.</param>
    /// <returns>A <see cref="MessageStatusResponse"/> containing the status.</returns>
    public async Task<MessageStatusResponse> GetStatusAsync(string messageId)
    {
        return await SendRequestAsync<MessageStatusResponse>(HttpMethod.Get, $"/api/sms/{messageId}/status/");
    }
}
