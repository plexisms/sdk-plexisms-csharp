using System.Collections.Generic;

namespace Plexisms.Models.Responses;

/// <summary>
/// Response object for a single SMS send request.
/// </summary>
public class SmsResponse
{
    /// <summary>
    /// The status of the request (e.g., "success", "error").
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// A message describing the result of the request.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The data associated with the sent SMS.
    /// </summary>
    [JsonProperty("data")]
    public SmsData? Data { get; set; }
}

/// <summary>
/// Detailed data about a specific SMS.
/// </summary>
public class SmsData
{
    /// <summary>
    /// The unique identifier for the SMS.
    /// </summary>
    [JsonProperty("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The recipient's phone number.
    /// </summary>
    [JsonProperty("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The content of the SMS message.
    /// </summary>
    [JsonProperty("body")]
    public string? Body { get; set; }

    /// <summary>
    /// The delivery status of the SMS.
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The cost of the SMS.
    /// </summary>
    [JsonProperty("cost")]
    public decimal? Cost { get; set; }

    /// <summary>
    /// The number of parts the SMS was split into (for long messages).
    /// </summary>
    [JsonProperty("parts")]
    public int Parts { get; set; }

    /// <summary>
    /// The timestamp when the SMS was created.
    /// </summary>
    [JsonProperty("created_at")]
    public string? CreatedAt { get; set; }
}

/// <summary>
/// Response object for a bulk SMS send request.
/// </summary>
public class BulkSmsResponse
{
    /// <summary>
    /// The status of the bulk request.
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// A message describing the result of the bulk request.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The total number of SMS messages sent/queued.
    /// </summary>
    [JsonProperty("total_sent")]
    public int TotalSent { get; set; }

    /// <summary>
    /// A list of SMS data objects for the messages sent.
    /// </summary>
    [JsonProperty("data")]
    public List<SmsData>? Data { get; set; }
}

/// <summary>
/// Response object for an OTP send request.
/// </summary>
public class OtpRequestResponse
{
    /// <summary>
    /// The status of the OTP request.
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// A message describing the result of the OTP request.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The unique verification ID associated with this OTP request.
    /// </summary>
    [JsonProperty("verification_id")]
    public string? VerificationId { get; set; }
}

/// <summary>
/// Response object for an OTP verification request.
/// </summary>
public class OtpVerifyResponse
{
    /// <summary>
    /// The status of the verification request.
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    /// <summary>
    /// A message describing the result of the verification.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Indicates whether the OTP code was valid.
    /// </summary>
    [JsonProperty("valid")]
    public bool Valid { get; set; }
}

/// <summary>
/// Response object for an account balance check.
/// </summary>
public class BalanceResponse
{
    /// <summary>
    /// The current account balance.
    /// </summary>
    [JsonProperty("balance")]
    public decimal Balance { get; set; }

    /// <summary>
    /// The currency of the balance.
    /// </summary>
    [JsonProperty("currency")]
    public string? Currency { get; set; }
}

/// <summary>
/// Response object for checking a message's status.
/// </summary>
public class MessageStatusResponse
{
    /// <summary>
    /// The current status of the message (e.g., "delivered", "failed", "pending").
    /// </summary>
    [JsonProperty("status")]
    public string? Status { get; set; }

    // Add other fields as needed based on API response
}
