using AcmeBank.Application.Interfaces;

namespace AcmeBank.ConsoleApp;

// This class is responsible for handling the login process of a teller.
public class TellerLoginHandler
{
    // A private read-only field of type ITellerAppService. This service is used to verify teller credentials.
    private readonly ITellerAppService _tellerAppService;

    // The constructor for the TellerLoginHandler class. It takes an instance of ITellerAppService as a parameter.
    // The passed in ITellerAppService instance is assigned to the private field _tellerAppService.
    public TellerLoginHandler(ITellerAppService tellerAppService)
    {
        _tellerAppService = tellerAppService;
    }

    // This method handles the login process for a teller.
    public bool Login()
    {
        // Maximum number of login attempts is set to 3.
        int maxLogInAttempt = 3;

        // A loop that continues until a successful login or maximum attempts reached.
        do
        {
            
            
            // Prompting the teller to enter their email.
            // Reading the teller's input, converting it to lower case, trimming any leading or trailing white spaces, and handling potential null values.
            Console.WriteLine("""
                                  ==========================================================
                                                  Teller - Login
                                        Please enter your credentials to log in
                                           1. Please Enter your Email Address
                                  ==========================================================
                              """);
            string inputEmail = Console.ReadLine()?.ToLower().Trim() ?? "";
                
            // Prompting the teller to enter their password.
            // Reading the teller's input, trimming any leading or trailing white spaces, and handling potential null values.
            Console.WriteLine("""
                                  ==========================================================
                                                  Teller - Login
                                        Please enter your credentials to log in
                                           2. Please Enter your Password
                                  ==========================================================
                              """);
            string inputPassword = Console.ReadLine()?.Trim() ?? "";

            // If the entered email and password are verified by the _tellerAppService,
            if (_tellerAppService.VerifyTeller(inputEmail, inputPassword))
            {
                // Inform the teller of successful login and return true, indicating a successful login.
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                // If the login attempt was unsuccessful, decrease the number of remaining login attempts.
                maxLogInAttempt -= 1;
                // If all login attempts have been used,
                if (maxLogInAttempt == 0)
                {
                    // Inform the teller they have been locked out and return false, indicating an unsuccessful login.
                    Console.WriteLine("Too many attempts - you have been locked out.");
                    return false;
                }
                // If there are still remaining login attempts, inform the teller of the unsuccessful login and the remaining attempts.
                Console.WriteLine($"Username or password is incorrect. You have {maxLogInAttempt} attempts left, please try again.\n");
            }
        } while (true); // The loop continues indefinitely until a return statement is reached.
    }
}