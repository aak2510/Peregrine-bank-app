using AcmeBank.Application.Services;
using AcmeBank.Domain.Models;

class Program
{
    // This method is the entry point for running the program.
    public static void RunProgram()
    {
        Console.WriteLine("""

            Welcome to Acme Bank!
            This is the teller login screen. Please enter your username and password when prompted.
            You only have 3 attempts before being locked out.

            """);

        // If successful user login, then ask for customer credentials and check if an account exists.
        if (TellerLogIn())
        {
            TellerMenu();
        }
        else
        {
            // If teller login reaches max attempts, then we assume they would be locked out and have to ask IT team to reset password.
            Console.WriteLine("Please contact the IT administration team.");
        }
    }

    // Handles the login logic for the teller.
    public static bool TellerLogIn()
    {
        // Placeholder information for login, replace with database query.
        string name = "teller";
        string password = "password";
        int maxLogInAttempt = 3;

        do
        {
            // Ask user for username, not case sensitive, so we convert to the same case.
            Console.Write("Please enter your username: ");
            string inputUsername = Console.ReadLine()?.ToLower().Trim() ?? "";
            // Password IS case sensitive, so we don't change case.
            Console.Write("Please enter your password: ");
            string inputPassword = Console.ReadLine()?.Trim() ?? "";

            // Placeholder logic for checking credentials, replace with actual database check.
            if (inputUsername == name && inputPassword == password)
            {
                return true;
            }
            else
            {
                maxLogInAttempt -= 1;
                if (maxLogInAttempt == 0)
                {
                    Console.WriteLine("Too many attempts - you have been locked out.");
                    return false;
                }
                Console.WriteLine($"Username or password is incorrect. You have {maxLogInAttempt} attempts left, please try again.\n");
            }

        } while (true); // Loop continues until a valid login or lockout.
    }

    // Displays the main menu to the teller after a successful login.
    public static void TellerMenu()
    {
        do
        {
            Console.WriteLine("""
                
                ==========================================================
                                    Teller - Main menu
                        Please choose one of the following options:
                                    1. Customer accounts.
                                    2. Sign out/Exit the system.

                """);

            Console.Write(@"Please choose option ""1"" or ""2"": ");
            if (int.TryParse(Console.ReadLine(), out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        // Placeholder for handling customer accounts.
                        customerDetailsInput();
                        break;
                    case 2:
                        // Exiting the program for now, but in a real application, you might want to log out the user.
                        return;
                    default:
                        Console.WriteLine("Unknown option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        } while (true); // Loop continues until the user decides to exit.
    }

    // Checks if customer has an account
// Checks if customer has an account
    public static void customerDetailsInput()
    {
        Console.WriteLine("When prompted, please enter the requested details of the customer to bring up their account detail:");
        AccountAppService userVerification = new AccountAppService();

        // Initialise the attempts counter.
        int attempts = 0;
        // Placeholder for the user object.
        List<User> users;

        // Loop until the user has been verified or the max attempts have been reached.
        do
        {
            Console.Write("Please enter customers Passport Number: ");
            string passportNumber = Console.ReadLine()?.ToLower().Trim() ?? "";

            // VerifyPassportNumber should return a bool and output a List<User> if true
            if (userVerification.VerifyPassportNumber(passportNumber, out users))
            {
                Console.WriteLine("User account exists.");
                // You can now work with the 'users' list
                break;
            }
            // Increment the attempts counter.
            attempts++;
            // If the user has reached the max attempts, then exit the loop.
            if (attempts == 3)
            {
                Console.WriteLine("Too many login attempts, goodbye.");
                return;
            }
            Console.WriteLine($"User account doesn't exist. You have {3 - attempts} login attempts left.  Please ensure you enter the details accurately");
        }
        while (attempts < 3);

        Console.Write("Please enter customers First Line of customer address: ");
        string firstLineAddress = Console.ReadLine()?.ToLower().Trim() ?? "";

        Console.Write("Please enter customers Second Line of customer address: ");
        string secondLineAddress = Console.ReadLine()?.ToLower().Trim() ?? "";

        Console.Write("Please enter customers city of residence: ");
        string city = Console.ReadLine()?.ToLower().Trim() ?? "";

        Console.Write("Please enter customers Postcode: ");
        string postcode = Console.ReadLine()?.ToLower().Trim() ?? "";

        Console.Write("Please enter customers country of residence: ");
        string country = Console.ReadLine()?.ToLower().Trim() ?? "";
        
        

        if (userVerification.VerifyAddress(users[0], firstLineAddress, secondLineAddress, city, postcode, country)){
            TellerMenu tm = new TellerMenu();
            tm.tellerAccountMenu();
        }
        else
        {
            Console.WriteLine("User account doesn't exist. Please make sure you have entered the details correctly.");
        }





    }


    // Main entry point of the program.
    static void Main(string[] args)
    {
        // Starts the application.
        RunProgram();
        
    }
}

