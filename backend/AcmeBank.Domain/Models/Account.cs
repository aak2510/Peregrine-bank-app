// // Banking App - Implementation of Display Accounts, Create Accounts and Close Accounts. 
// // Display Account Details - Type of Account, Balance, Overdrafts, Account Number, Sort Code, Account Actions.
// // Create Account Details - Create Instance of New Account Using Constraints Given.
// // Close Account Details - Delete Accounts. 

using System;

//public enum AccountType
//{
//    Savings,
//    Checking,

//    // Add more account types if needed. 
//}

public class Account
{
    public AccountType AccountType { get; set; }
    public decimal Balance { get; set; }
    public decimal Overdrafts { get; set; }
    public string AccountNumber { get; set; }
    public string SortCode { get; set; }
    public string[] Actions { get; set; }

    // Constructor.
    public Account(AccountType accountType, decimal balance, decimal overdrafts, string accountNumber, string sortCode)
    {
        AccountType = accountType;
        Balance = balance;
        Overdrafts = overdrafts;
        AccountNumber = accountNumber;
        SortCode = sortCode;
        Actions = new string[0]; // Initialize actions array.
    }

    public void Display(Account account)
    {
        Console.WriteLine("Type of Account: " + account.AccountType);
        Console.WriteLine("Balance: " + account.Balance);
        Console.WriteLine("Overdrafts: " + account.Overdrafts);
        Console.WriteLine("Account Number: " + account.AccountNumber);
        Console.WriteLine("Sort Code: " + account.SortCode);
        Console.WriteLine("Account Actions: ");

        foreach (string action in account.Actions)
        {
            Console.WriteLine("- " + action);
        }

    }

    public Account Create(AccountType accountType, decimal balance, decimal overdrafts, string accountNumber, string sortCode)
    {
        // Create an instance of the Account class with the provided parameters.

        Account newAccount = new Account(accountType, balance, overdrafts, accountNumber, sortCode);

        return newAccount;

    }

    public void Close(Account account)
    {
        // Perform any necessary cleanup or validation before closing the account.

        Console.WriteLine("Closing account with account number: " + account.AccountNumber);

        // You may want to remove the account from a list of active accounts or mark it as closed.

    }

//public class DisplayAccounts
//{
//    public void Display(Account account)
//    {
//        Console.WriteLine("Type of Account: " + account.AccountType);
//        Console.WriteLine("Balance: " + account.Balance);
//        Console.WriteLine("Overdrafts: " + account.Overdrafts);
//        Console.WriteLine("Account Number: " + account.AccountNumber);
//        Console.WriteLine("Sort Code: " + account.SortCode);
//        Console.WriteLine("Account Actions: ");

//        foreach (string action in account.Actions)
//        {
//            Console.WriteLine("- " + action);
//        }
//    }
//}

//public class CreateAccounts
//{
//    public Account Create(AccountType accountType, decimal balance, decimal overdrafts, string accountNumber, string sortCode)
//    {
//        // Create an instance of the Account class with the provided parameters.

//        Account newAccount = new Account(accountType, balance, overdrafts, accountNumber, sortCode);

//        return newAccount;

//    }
//}

//public class CloseAccounts
//{
//    public void Close(Account account)
//    {
//        // Perform any necessary cleanup or validation before closing the account.

//        Console.WriteLine("Closing account with account number: " + account.AccountNumber);

//        // You may want to remove the account from a list of active accounts or mark it as closed.

//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        DisplayAccounts displayAccounts = new DisplayAccounts();
//        CreateAccounts createAccounts = new CreateAccounts();
//        CloseAccounts closeAccounts = new CloseAccounts();

//        Console.WriteLine("Choose an option:");
//        Console.WriteLine("1. Display Accounts");
//        Console.WriteLine("2. Create Account");
//        Console.WriteLine("3. Close Account");

//        // User input. 

//        string userInput = Console.ReadLine();

//        if (userInput == "1")

//        {
//            // Option to display accounts.
//            // Assuming you have a list of accounts to display.

//            foreach (var account in accounts)
//            {
//                displayAccounts.Display(account);
//            }
//        }
//        else if (userInput == "2")
//        {
//            // Option to create an account.
//            // You need to collect necessary information from the user to create an account.
//            // Then create an account using CreateAccounts class.

//            AccountType accountType;
//            decimal balance;
//            decimal overdrafts;
//            string accountNumber;
//            string sortCode;

//            // Collect information from the user.

//            Console.WriteLine("Enter account type (Savings/Checking): ");

//            Enum.TryParse(Console.ReadLine(), out accountType); // Assume user enters valid type.
//            Console.WriteLine("Enter balance: ");

//            decimal.TryParse(Console.ReadLine(), out balance); // Assume user enters valid balance.
//            Console.WriteLine("Enter overdrafts: ");

//            decimal.TryParse(Console.ReadLine(), out overdrafts); // Assume user enters valid overdrafts.
//            Console.WriteLine("Enter account number: ");

//            accountNumber = Console.ReadLine(); // Assume user enters valid account number.
//            Console.WriteLine("Enter sort code: ");

//            sortCode = Console.ReadLine(); // Assume user enters valid sort code.

//            // Create the account.

//            Account newAccount = createAccounts.Create(accountType, balance, overdrafts, accountNumber, sortCode);

//            // Optionally, you may want to add the newly created account to your list of accounts.
//        }
//        else if (userInput == "3")
//        {
//            // Option to close an account.
//            // Assuming you have a list of accounts to choose from.
//            // You need to select an account to close.
//            // Then call Close method from CloseAccounts class.
//            // Close the account.

//            closeAccounts.Close(accountToClose);
//        }

//        else
//        {
//            // Invalid option
//            Console.WriteLine("Invalid option. Please choose a valid option.");

//        }
//    }
}
