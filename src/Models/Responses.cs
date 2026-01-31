using System.Collections.Generic;

namespace Plexisms.Models.Responses;

public class SmsResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("data")]
    public SmsData Data { get; set; }
}

public class SmsData
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("cost")]
    public decimal? Cost { get; set; }

    [JsonProperty("parts")]
    public int Parts { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }
}

public class BulkSmsResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("total_sent")]
    public int TotalSent { get; set; }

    [JsonProperty("data")]
    public List<SmsData> Data { get; set; }
}

public class OtpRequestResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("verification_id")]
    public string VerificationId { get; set; }
}

public class OtpVerifyResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("valid")]
    public bool Valid { get; set; }
}

public class BalanceResponse
{
    [JsonProperty("balance")]
    public decimal Balance { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }
}

public class MessageStatusResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    // Add other fields as needed based on API response
}
