class TellerAccountMenu
{
    
    public void runMenu()
    {

        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Display Accounts");
        Console.WriteLine("2. Create Account");
        Console.WriteLine("3. Close Account");

        // User input. 

        string userInput = Console.ReadLine();

        if (userInput == "1")

        {
            // Option to display accounts.
            // Assuming you have a list of accounts to display.

            foreach (var account in accounts)
            {
                Display(account);
            }
        }
        else if (userInput == "2")
        {
            // Option to create an account.
            // You need to collect necessary information from the user to create an account.
            // Then create an account using CreateAccounts class.


            AccountType accountType;
            decimal balance;
            decimal overdrafts;
            string accountNumber;
            string sortCode;

            // Collect information from the user.

            Console.WriteLine("Enter account type (Savings/Checking): ");

            Enum.TryParse(Console.ReadLine(), out accountType); // Assume user enters valid type.
            Console.WriteLine("Enter balance: ");

            decimal.TryParse(Console.ReadLine(), out balance); // Assume user enters valid balance.
            Console.WriteLine("Enter overdrafts: ");

            decimal.TryParse(Console.ReadLine(), out overdrafts); // Assume user enters valid overdrafts.
            Console.WriteLine("Enter account number: ");

            accountNumber = Console.ReadLine(); // Assume user enters valid account number.
            Console.WriteLine("Enter sort code: ");

            sortCode = Console.ReadLine(); // Assume user enters valid sort code.

            // Create the account.

            Account newAccount = Create(accountType, balance, overdrafts, accountNumber, sortCode);

            // Optionally, you may want to add the newly created account to your list of accounts.
        }
        else if (userInput == "3")
        {
            // Option to close an account.
            // Assuming you have a list of accounts to choose from.
            // You need to select an account to close.
            // Then call Close method from CloseAccounts class.
            // Close the account.

            Close(accountToClose);
        }

        else
        {
            // Invalid option
            Console.WriteLine("Invalid option. Please choose a valid option.");

        }

    }

}


