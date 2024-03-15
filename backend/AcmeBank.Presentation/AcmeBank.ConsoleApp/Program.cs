
class Program
{
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


        //store username as lowercase
        string name = "teller".ToLower();
        string password = "password";
        int logInCount = 0;
        // Check that log-in credentials are correct, if they are then proceed, else repeat until they enter the correct username and password.
        bool inputSuccess = false;

        
        do
        {
            // Ask user for username, not case sensitive, so we convert to the same case
            Console.Write("Please enter your username: ");
            string inputUsername = Console.ReadLine().ToLower().Trim();
            // Password IS case sensitive, so we don't change case
            Console.Write("Please enter your password: ");
            string inputPassword = Console.ReadLine().Trim();

            // Only leave the log in page if BOTH username and password are the same
            if (inputUsername == name && inputPassword == password)
            {
                inputSuccess = true;
                Console.WriteLine();
            }
            else
            {
                logInCount += 1;
                // Message to let user know that input is incorrect
                Console.WriteLine("Username or password is incorrect, please try again.\n");
      
            }

            if(logInCount == 3)
            {
                Console.WriteLine("Too many attempts");
                inputSuccess = true;
            }
        } while (!inputSuccess);


    }
}
