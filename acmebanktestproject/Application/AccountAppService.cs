using System.Collections.Generic; 
using System.Text;

namespace acmebanktestproject.Application;

    public class AccountMenu
    {
        private User _customer;
        private List<Account> _accounts = new List<Account>();
        //private readonly IAccountService _accountService;

        public AccountMenu(User customer)
        {
            _customer = customer;
        }
        
        
        public string ReturnAccountsMenu()
        {
            // Calls function that calls database to retrieve userid, passport/driving license and address
            GetUserAccounts();
            // Should verify if the passport/driving license or address is valid
            // Also checks that it returns a non-empty results
            if (_accounts.Count > 0)
            {
                StringBuilder menu = new StringBuilder();
                
                foreach (var account in _accounts)
                {
                    // Displays account number, type, and balance
                    menu.AppendLine($"{account.AccountNumber} - {account.AccountType}: Balance {account.Balance}");
                }
                return menu.ToString();
            }
            else
            {
                // If no accounts are found, returns this message
                return "No accounts found.";
            }
        }
        
        // Method to create a new account for user
        // TODO: Implement account creation logic
        
        // Method to delete an account for a user
        // TODO: Implement account deletion logic
        
        // Returns all accounts in their name (account details, sort code) based on user id retrieved above
        public string ReturnAccountByUserSelection(sbyte selection)
        {
            // Returns account details based on user selection
            if (selection - 1 < _accounts.Count)
            {
                var selectedAccount = _accounts[selection - 1];
                return $"Selected Account {selectedAccount.AccountNumber}: Balance {selectedAccount.Balance}";
            }
            // If the selection is invalid, returns this message
            return "Invalid selection.";
        }
        
        // Method to login to a specific account and return more details specific to that account
        // TODO: Implement login functionality
        
        // Separate method to take actions within the account such as deposit, withdraw, transfer
        // TODO: Implement account transaction functionalities
        
        // Method to logout of account
        // TODO: Implement logout functionality

        protected void GetUserAccounts()
        {
            // Retrieves user accounts from the database based on the user's ID
            // var searchResults = _accountService.GetAccountsByUserID(_customer.ID);
            // if (searchResults != null && searchResults.Count > 0)
            //{
              //  _accounts = searchResults;
            //}
        }
    }
