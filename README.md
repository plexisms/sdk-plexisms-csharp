# Plexisms C# .NET SDK

Official .NET client library for the Plexisms SMS API.

## Installation

Using the .NET CLI:
```sh
dotnet add package Plexisms.Net
```

## Usage

### Initialization

```csharp
using Plexisms;

var client = new PlexismsClient("YOUR_API_KEY");
```

### Send SMS

```csharp
var response = await client.Messages.SendAsync(
    to: "+243840000000",
    message: "Hello from C# SDK!",
    senderId: "MyBrand"
);

Console.WriteLine($"SMS ID: {response.Data.Id}");
```

### Check Balance

```csharp
var balance = await client.Account.GetBalanceAsync();
Console.WriteLine($"Balance: {balance.Balance} {balance.Currency}");
```

### Send OTP

```csharp
var otp = await client.Otp.SendAsync("+243840000000");
string verificationId = otp.VerificationId;
```

### Verify OTP

```csharp
var result = await client.Otp.VerifyAsync(verificationId, "123456");
if (result.Valid)
{
    Console.WriteLine("OTP Verified!");
}
```

## License

MIT

## Publishing

See [PUBLISHING.md](PUBLISHING.md) for instructions on how to publish this package to NuGet.org.
