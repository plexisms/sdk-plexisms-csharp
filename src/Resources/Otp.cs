namespace Plexisms.Resources;

/// <summary>
/// Resource for handling One-Time Password (OTP) operations.
/// </summary>
public class Otp : BaseResource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Otp"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public Otp(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Sends an OTP code to a phone number.
    /// </summary>
    /// <param name="to">The recipient's phone number.</param>
    /// <param name="brand">The brand name to display (default: "PlexiSMS").</param>
    /// <returns>A <see cref="OtpRequestResponse"/> containing the verification ID.</returns>
    public async Task<OtpRequestResponse> SendAsync(string to, string brand = "PlexiSMS")
    {
        var request = new SendOtpRequest
        {
            PhoneNumber = to,
            Brand = brand
        };

        return await SendRequestAsync<OtpRequestResponse>(HttpMethod.Post, "/api/sms/send-otp/", request);
    }

    /// <summary>
    /// Verifies an OTP code.
    /// </summary>
    /// <param name="verificationId">The verification ID received from the send request.</param>
    /// <param name="code">The OTP code entered by the user.</param>
    /// <returns>A <see cref="OtpVerifyResponse"/> indicating validity.</returns>
    public async Task<OtpVerifyResponse> VerifyAsync(string verificationId, string code)
    {
        var request = new VerifyOtpRequest
        {
            VerificationId = verificationId,
            OtpCode = code
        };

        return await SendRequestAsync<OtpVerifyResponse>(HttpMethod.Post, "/api/sms/verify-otp/", request);
    }
}
