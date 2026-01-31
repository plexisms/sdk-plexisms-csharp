using System.Collections.Generic;

namespace Plexisms.Models.Requests;

public class SendSmsRequest
{
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("sender_id")]
    public string SenderId { get; set; }

    [JsonProperty("sms_type")]
    public string SmsType { get; set; } = "transactional";
}

public class SendBulkSmsRequest
{
    [JsonProperty("phone_numbers")]
    public List<string> PhoneNumbers { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("sender_id")]
    public string SenderId { get; set; }

    [JsonProperty("sms_type")]
    public string SmsType { get; set; } = "transactional";
}

public class SendOtpRequest
{
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonProperty("brand")]
    public string Brand { get; set; }
}

public class VerifyOtpRequest
{
    [JsonProperty("verification_id")]
    public string VerificationId { get; set; }

    [JsonProperty("otp_code")]
    public string OtpCode { get; set; }
}
