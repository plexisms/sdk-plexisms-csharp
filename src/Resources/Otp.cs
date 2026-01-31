namespace Plexisms.Resources;

public class Otp : BaseResource
{
    public Otp(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Send an OTP code
    /// </summary>
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
    /// Verify an OTP code
    /// </summary>
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
