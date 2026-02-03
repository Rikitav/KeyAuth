# KeyAuth API client

**DISCLAIMER:**
This is an **unofficial**, refactored version of the KeyAuth API wrapper. It is not affiliated with, endorsed by, or supported by the official KeyAuth team. This library does not violate the original license and does not intend to replace the official library. It offers a modern, Dependency Injection (DI) friendly, and asynchronous approach to integrating KeyAuth.

If you are looking for the official, supported library, please visit: [KeyAuth GitHub Page](https://github.com/KeyAuth).

---

## Refactored KeyAuth C# Client

This library provides a modernized wrapper for the KeyAuth API, featuring:
* **Asynchronous API**: All network operations use `async/await`.
* **DI Support**: Built-in support for `Microsoft.Extensions.DependencyInjection`.
* **Interface-Based**: Easy mocking and testing via `IKeyAuthClient`.
* **Stateless Design**: Responses return data directly rather than modifying global state.

### Tutorial Video (Official)

If you are looking for the official examples and reference for C#, please visit: [KeyAuth-CSHARP-Example](https://github.com/KeyAuth/KeyAuth-CSHARP-Example).
For general KeyAuth concepts and setup, please refer to the official tutorial:
https://www.youtube.com/watch?v=5x4YkTmFH-U

## **Bugs**

If you encounter issues specific to this refactored logic, please open an issue in this repository.
If you have general KeyAuth account, website, or API questions, please use the [official support channel](https://t.me/keyauth).

## **Security practices**

* Utilize obfuscation provided by companies such as VMProtect or Themida (utilize their SDKs too for greater protection).
* Perform frequent integrity checks to ensure the memory of the program has not been modified.
* Don't write the bytes of a file you've downloaded to disk if you don't want that file to be retrieved by the user. Rather, execute the file in memory and erase it from memory the moment execution finishes.

## Copyright License

KeyAuth is licensed under **Elastic License 2.0**. This refactor respects the original licensing terms.

* You may not provide the software to third parties as a hosted or managed
service, where the service provides users with access to any substantial set of
the features or functionality of the software.

* You may not move, change, disable, or circumvent the license key functionality
in the software, and you may not remove or obscure any functionality in the
software that is protected by the license key.

* You may not alter, remove, or obscure any licensing, copyright, or other notices
of the licensor in the software. Any use of the licensor’s trademarks is subject
to applicable law.

Thank you for your compliance, we work hard on the development of KeyAuth and do not appreciate our copyright being infringed.

## Standard Usage (Console/No-DI)

Below are examples of how to use the `KeyAuthClient` in a standard console application without Dependency Injection.

### Installation
```bash
dotnet add package KeyAuth-Api
```

### 1. Initialization

You must create a `KeyAuthClient` instance and call `InitAsync` before using other features.

```csharp
using KeyAuth;

// Configure the client options
var options = new KeyAuthClientOptions
{
    AppName = "example",
    OwnerId = "JjPMBVlIOd",
    Secret: "db40d586f4b189e04e5c18c3c94b7e72221be3f6551995adc05236948d1762bc",
    AppVersion = "1.0"
};

// Create the client instance
using var client = new KeyAuthClient(options);

// Initialize connection
var initResponse = await client.InitAsync();

if (!initResponse.Success)
{
    Console.WriteLine($"\n Status: {initResponse.Message}");
    Thread.Sleep(2500);
    Environment.Exit(0);
}

```

### 2. Display application information

```csharp
var stats = await client.FetchStatsAsync();

if (stats.Success && stats.AppData != null)
{
    Console.WriteLine($"\n Application Version: {stats.AppData.Version}");
    Console.WriteLine($" Customer panel link: {stats.AppData.CustomerPanelLink}");
    Console.WriteLine($" Number of users: {stats.AppData.NumUsers}");
    Console.WriteLine($" Number of online users: {stats.AppData.NumOnlineUsers}");
    Console.WriteLine($" Number of keys: {stats.AppData.NumKeys}");
}

```

### 3. Check session validation

```csharp
var check = await client.CheckAsync();
Console.WriteLine($" Current Session Validation Status: {check.Message}");

```

### 4. Check blacklist status

```csharp
// Note: The library throws exceptions for connection issues, 
// but CheckBlackAsync returns a response object you can inspect.
var blackCheck = await client.CheckBlackAsync(hwid: "current-hwid", ip: "current-ip");
if (!blackCheck.Success) 
{
    // Logic if user is blacklisted
    Environment.Exit(0);
}

```

### 5. Login with username/password

**Note:** Unlike the official library which stores user data in a global variable, this library returns the User Data in the `LoginResponse`.

```csharp
Console.WriteLine("\n\n Enter username: ");
string username = Console.ReadLine();
Console.WriteLine("\n\n Enter password: ");
string password = Console.ReadLine();

var loginResult = await client.LoginAsync(username, password);

if (!loginResult.Success)
{
    Console.WriteLine($"\n Status: {loginResult.Message}");
    Thread.Sleep(2500);
    Environment.Exit(0);
}

// Access user data from the response result
var currentUser = loginResult.UserData;
Console.WriteLine($"\n Logged in as {currentUser?.Username}");

```

### 6. Register with username/password/key

```csharp
Console.Write("\n\n Enter username: ");
string username = Console.ReadLine();
Console.Write("\n\n Enter password: ");
string password = Console.ReadLine();
Console.Write("\n\n Enter license: ");
string key = Console.ReadLine();
Console.Write("\n\n Enter email (just press enter if none): ");
string email = Console.ReadLine();

var registerResult = await client.RegisterAsync(username, password, key, email);

if (!registerResult.Success)
{
    Console.WriteLine($"\n Status: {registerResult.Message}");
    Thread.Sleep(2500);
    Environment.Exit(0);
}

// Access user data
var currentUser = registerResult.UserData;

```

### 7. Login with just license key

```csharp
Console.WriteLine("\n\n Enter license: ");
string key = Console.ReadLine();

var licenseResult = await client.LicenseAsync(key);

if (!licenseResult.Success)
{
    Console.WriteLine($"\n Status: {licenseResult.Message}");
    Thread.Sleep(2500);
    Environment.Exit(0);
}

var currentUser = licenseResult.UserData;

```

### 8. Upgrade user

```csharp
Console.WriteLine("\n\n Enter username: ");
string username = Console.ReadLine();
Console.WriteLine("\n\n Enter license: ");
string key = Console.ReadLine();

var upgradeResult = await client.UpgradeAsync(username, key);

Console.WriteLine($"\n Status: {upgradeResult.Message}");
Thread.Sleep(2500);
Environment.Exit(0);

```

### 9. Forgot password

```csharp
Console.Write("\n\n Enter username: ");
string username = Console.ReadLine();
Console.Write("\n\n Enter email: ");
string email = Console.ReadLine();

var forgotResult = await client.ForgotAsync(username, email);

Console.WriteLine($"\n Status: {forgotResult.Message}");

```

### 10. User Data

In this library, user data is returned in the `UserData` property of the `LoginResponse`, `RegisterResponse`, or `LicenseResponse`. You should store this object after a successful authentication.

```csharp
// Assuming 'currentUser' was obtained from a successful LoginAsync call
if (currentUser != null)
{
    Console.WriteLine("\n User data:");
    Console.WriteLine($" Username: {currentUser.Username}");
    Console.WriteLine($" IP address: {currentUser.Ip}");
    Console.WriteLine($" Hardware-Id: {currentUser.Hwid}");
    Console.WriteLine($" Created at: {currentUser.Createdate}"); 
    Console.WriteLine($" Last login at: {currentUser.Lastlogin}");
    
    Console.WriteLine(" Your subscription(s):");
    if (currentUser.Subscriptions != null)
    {
        foreach (var sub in currentUser.Subscriptions)
        {
            Console.WriteLine($" Subscription: {sub.Subscription} - Expires: {sub.Expiry} - Time left: {sub.Timeleft}");
        }
    }
}

```

### 11. Application variables

```csharp
var varResponse = await client.GetVarAsync("variableNameHere");

if (!varResponse.Success)
{
    Console.WriteLine($"\n Status: {varResponse.Message}");
}
else
{
    // The library may return the generic response, verify specific usage in 'GetVarResponse'
    Console.WriteLine($"\n App variable data: {varResponse.Message}"); 
}

```

### 12. User Variables

**Set User Variable:**

```csharp
var setVarResult = await client.SetVarAsync("discord", "test#0001");
if (setVarResult.Success)
    Console.WriteLine("\n Successfully set user variable");

```

**Get User Variable:**

```csharp
var getVarResult = await client.GetVarAsync("discord");
if (getVarResult.Success)
    Console.WriteLine($"\n User variable value: {getVarResult.Message}"); // Check 'Message' or specific content property

```

### 13. Ban the user

```csharp
// Ban without reason
await client.BanAsync();

// Ban with reason
await client.BanAsync("You've been banned for a reason.");

```

### 14. Server-sided webhooks

```csharp
// Example with parameters
var webhookResult = await client.WebhookAsync("7kR0UedlVI", "&ip=1.1.1.1&hwid=abc");

if (webhookResult.Success)
    Console.WriteLine($"\n Response: {webhookResult.Response}");

```

### 15. Download file

```csharp
var downloadResult = await client.DownloadAsync("385624");

if (!downloadResult.Success)
{
    Console.WriteLine($"\n Status: {downloadResult.Message}");
}
else
{
    // Assuming 'Bytes' or 'Content' property exists in DownloadResponse
    // File.WriteAllBytes("text.txt", downloadResult.Bytes); 
}

```

---

## Dependency Injection (DI) Integration

This is the primary feature of this refactored library. You can easily integrate KeyAuth into ASP.NET Core, Worker Services, or modern Console Apps using `Microsoft.Extensions.DependencyInjection`.

### Installation
```bash
dotnet add package KeyAuth-Api.HostingExtensions
```

### Setup

1. Add `KeyAuth` configuration to your `appsettings.json`:
```json
"KeyAuth": {
  "AppName": "example",
  "OwnerId": "JjPMBVlIOd",
  "AppVersion": "1.0"
}

```

2. Register the service in your `Program.cs` or `Startup.cs`:
```csharp
using KeyAuth.HostingExtensions;

var builder = Host.CreateApplicationBuilder(args);

// Register KeyAuth using configuration
builder.Services.AddKeyAuth(builder.Configuration.GetSection("KeyAuth"));

// OR Register manually
// builder.Services.AddKeyAuth(sp => new KeyAuthClient(new KeyAuthClientOptions { ... }));

var host = builder.Build();
host.Run();

```


3. Inject `IKeyAuthClient` into your services:
```csharp
public class MyService
{
    private readonly IKeyAuthClient _authClient;

    public MyService(IKeyAuthClient authClient)
    {
        _authClient = authClient;
    }

    public async Task RunAuthCheck()
    {
        await _authClient.InitAsync();
        var login = await _authClient.LoginAsync("user", "pass");
        // ...
    }
}

```