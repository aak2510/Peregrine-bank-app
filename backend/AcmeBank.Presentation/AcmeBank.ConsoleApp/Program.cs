
class Program
{

    public static void runProgram()
    {
        Console.WriteLine("""
            

            Welcome to Acme Bank!
            This is the teller log in screen, please enter your username and password when prompted. 
            You only have 3 attempts before being locked out.


            """);

        // If sucessfull user log in then ask for customer credentails and check if an account exists
        if (tellerLogIn())
        {
            tellerMenu();
        }
        else
        {
            // If teller log in reach max attempts, then we assume they would be locked out and have to ask IT team to reset password.
            Console.WriteLine("Please contact the IT administration team.");
        }

    }

    public static bool tellerLogIn()
    {
        // replace information with database query
        string name = "teller";
        string password = "password";
        int maxLogInAttempt = 3;

        do
        {
            // Ask user for username, not case sensitive, so we convert to the same case
            Console.Write("Please enter your username: ");
            string inputUsername = Console.ReadLine().ToLower().Trim();
            // Password IS case sensitive, so we don't change case
            Console.Write("Please enter your password: ");
            string inputPassword = Console.ReadLine().Trim();

            // change to pull information from database check details from there for teller?
            if ((inputUsername is not null && inputPassword is not null) && (inputUsername == name && inputPassword == password))
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
                // Message to let user know that input is incorrect
                Console.WriteLine($"Username or password is incorrect. You have {maxLogInAttempt} attempts left, please try again.\n");

            }


        } while (true);

    }


    public static void tellerMenu()
    {
        do
        {
            Console.WriteLine("""
            
            ==========================================================
                                  Teller - Main menu
                      please choose one of the following options:
                                  1. Customer accounts.
                                  2. Sign out/Exit the system.



            """);

            Console.Write("""Please choose option "1" or "2": """);
            int? menuChoice = 0;
            string? menuOption = Console.ReadLine();
            // If successfully parsed as an int, run corresponding menu function, else an exception with be thrown and we return to the tellers main menu
            try
            {
                menuChoice = int.Parse(menuOption);
                switch (menuChoice)
                {
                    case 1:
                        // Run function for customer accounts
                        accountInformation();
                        break;
                    case 2:
                        // run function to return to main menu - this included deleting session information
                        // **************** For now we return to main menu ****************
                        runProgram();
                        break;
                    default:
                        // If there is some sort of error in the input it would be unknown here
                        // so we throw an re run the menu.
                        throw new Exception();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("You have entered an invalid input, please try again. Returning to main menu...\n\n");
            }
        } while (true);





    }

    public static void accountInformation()
    {

        // Ask customer for their credentials, if they are found within the DB then display menu options
        //if (customerCredential)
        //{
            TellerAccountMenu account = new TellerAccountMenu();
            account.runMenu();
        //}

        //Console.Write("Please enter your account number: ");
        //var accountNumber = Console.ReadLine();
        //Console.Write("Please enter your sort code: ");
        //var sortCode = Console.ReadLine();

        // TO BE COMPLETED
        //// Call the account service to get the account
        // var accountService = new AccountService();
        //var account = accountService.GetAccountByNumber(accountNumber, sortCode);
        // ========================= If correct, run Nikhils functions ================================
    }


    static void Main(string[] args)
    {
        // Use a separate function to return to main page to avoid calling Main with no args
        runProgram();
    }
}
