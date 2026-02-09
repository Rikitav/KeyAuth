using KeyAuth.Responses;

namespace KeyAuth.ExampleApp;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("=== KeyAuth Test Application ===\n");

        // Configuring client options
        KeyAuthClientOptions options = new KeyAuthClientOptions()
        {
            AppName = "example",      // Change to name of your application
            OwnerId = "JjPMBVlIOd"    // Change to your OwnerID (should be 10 characters long)
        };

        using KeyAuthClient client = new KeyAuthClient(options);

        try
        {
            // 1. Initialization
            Console.WriteLine("\n1. Initializing KeyAuth...");

            var initResponse = await client.InitAsync();
            Console.WriteLine($"   ✓ Initialization successful!");
            Console.WriteLine($"   Session ID: {initResponse.SessionId ?? "NULL"}");
            Console.WriteLine($"   New Session: {initResponse.NewSession}");

            // 2. API methods demo
            Console.WriteLine("\n2. Testing API methods...\n");

            // Example: Session checking
            Console.WriteLine("   Checking session...");
            var checkResponse = await client.CheckAsync();
            Console.WriteLine($"   ✓ Session valid: {checkResponse.Success}\n");

            // Example: Getting staticstics
            Console.WriteLine("   Fetching app statistics...");
            var statsResponse = await client.FetchStatsAsync();
            if (statsResponse.Success && statsResponse.AppData != null)
            {
                Console.WriteLine($"   ✓ Statistics retrieved:");
                Console.WriteLine($"     Users: {statsResponse.AppData.NumUsers}");
                Console.WriteLine($"     Online Users: {statsResponse.AppData.NumOnlineUsers}");
                Console.WriteLine($"     Keys: {statsResponse.AppData.NumKeys}");
                Console.WriteLine($"     Version: {statsResponse.AppData.Version}\n");
            }

            // Example: Getting online users
            Console.WriteLine("   Fetching online users...");
            var onlineResponse = await client.FetchOnlineAsync();
            if (onlineResponse.Success && onlineResponse.Users != null)
            {
                Console.WriteLine($"   ✓ Online users: {onlineResponse.Users.Count}");
                foreach (var user in onlineResponse.Users)
                {
                    Console.WriteLine($"     - {user.Credential}");
                }
            }

            // Example: getting global variable (if exists)
            var varResponse = await client.VarAsync("your_var_id");
            Console.WriteLine($"   Variable value: {varResponse.Value}\n");

            // Example: Logging events
            Console.WriteLine("   Logging test event...");
            await client.LogAsync("Test log message from demo app");
            Console.WriteLine("   ✓ Event logged\n");

            // Example: User log-in
            LoginResponse loginResponce = await client.LoginAsync("Rakamakafo", "1234");
            Console.WriteLine(loginResponce.UserData?.Username);

            Console.WriteLine("\n=== All tests completed successfully! ===");
            Console.WriteLine("=== Demo completed ===");
        }
        catch (KeyAuthSetupException ex)
        {
            Console.WriteLine($"\n✗ Setup Error: {ex.Message}");
        }
        catch (KeyAuthConnectionException ex)
        {
            Console.WriteLine($"\n✗ Connection Error: {ex.Message}");
            Console.WriteLine($"   Inner Exception: {ex.InnerException?.Message}");
        }
        catch (KeyAuthAuthenticationException ex)
        {
            Console.WriteLine($"\n✗ Authentication Error: {ex.Message}");
        }
        catch (KeyAuthSignatureException ex)
        {
            Console.WriteLine($"\n✗ Signature Error: {ex.Message}");
        }
        catch (KeyAuthSslException ex)
        {
            Console.WriteLine($"\n✗ SSL Error: {ex.Message}");
        }
        catch (KeyAuthException ex)
        {
            Console.WriteLine($"\n✗ KeyAuth Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Unexpected Error: {ex}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
