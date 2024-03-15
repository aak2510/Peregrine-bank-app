
class Program
{
      

    public static bool tellerLogIn()
    {
        // replace information with database query
        string name = "teller";
        string password = "password";
        int maxLogInAttempt = 3;
        bool inputSuccess = false;

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
                inputSuccess = true;
                return true;

                // Run function to go to Nikhils section

            }
            else
            {
                maxLogInAttempt -= 1;
                if (maxLogInAttempt == 0)
                {
                    Console.WriteLine("Too many attempts - you have been locked out");
                    return false;
                }
                // Message to let user know that input is incorrect
                Console.WriteLine($"Username or password is incorrect. You have {maxLogInAttempt} attempts left, please try again.\n");

            }

            
        } while (!inputSuccess);
        return true;
    }
    static void Main(string[] args)
    {
        //Console.WriteLine("Welcome to Acme Bank");
        //Console.WriteLine("Please enter your account number");
        //var accountNumber = Console.ReadLine();
        //Console.WriteLine("Please enter your sort code");
        //var sortCode = Console.ReadLine();

        //// Call the account service to get the account
        //var accountService = new AccountService();
        ////
        //var account = accountService.GetAccountByNumber(accountNumber, sortCode);



        Console.WriteLine(tellerLogIn());




        // If sucessfull user log in then ask for customer credentails and check if an account exists
        // If it doesn then 

    }
}
