using System.Collections.Generic;

namespace Plexisms.Models.Requests;

/// <summary>
/// Request payload for sending a single SMS.
/// </summary>
public class SendSmsRequest
{
    /// <summary>
    /// The recipient's phone number.
    /// </summary>
    [JsonProperty("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The content of the SMS message.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The sender ID (alphanumeric or numeric).
    /// </summary>
    [JsonProperty("sender_id")]
    public string? SenderId { get; set; }

    /// <summary>
    /// The type of SMS (e.g., "transactional", "promotional"). Default is "transactional".
    /// </summary>
    [JsonProperty("sms_type")]
    public string SmsType { get; set; } = "transactional";
}

/// <summary>
/// Request payload for sending bulk SMS.
/// </summary>
public class SendBulkSmsRequest
{
    /// <summary>
    /// List of recipient phone numbers.
    /// </summary>
    [JsonProperty("phone_numbers")]
    public List<string>? PhoneNumbers { get; set; }

    /// <summary>
    /// The content of the SMS message.
    /// </summary>
    [JsonProperty("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The sender ID (alphanumeric or numeric).
    /// </summary>
    [JsonProperty("sender_id")]
    public string? SenderId { get; set; }

    /// <summary>
    /// The type of SMS (e.g., "transactional", "promotional"). Default is "transactional".
    /// </summary>
    [JsonProperty("sms_type")]
    public string SmsType { get; set; } = "transactional";
}

/// <summary>
/// Request payload for sending an OTP.
/// </summary>
public class SendOtpRequest
{
    /// <summary>
    /// The recipient's phone number.
    /// </summary>
    [JsonProperty("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The brand name to display in the OTP message.
    /// </summary>
    [JsonProperty("brand")]
    public string? Brand { get; set; }
}

/// <summary>
/// Request payload for verifying an OTP.
/// </summary>
public class VerifyOtpRequest
{
    /// <summary>
    /// The verification ID returned by the Send OTP request.
    /// </summary>
    [JsonProperty("verification_id")]
    public string? VerificationId { get; set; }

    /// <summary>
    /// The OTP code entered by the user.
    /// </summary>
    [JsonProperty("otp_code")]
    public string? OtpCode { get; set; }
}
