using AcmeBank.Domain.Models;
using AcmeBank.Domain.Interfaces;
using System.Collections.Generic; 
using System.Text;

namespace AcmeBank.Application.Services
{
    public class AccountMenu
    {
        private Customer _customer;
        private List<Account> _accounts = new List<Account>();
        private readonly IAccountService _accountService;

        public AccountMenu(Customer customer, IAccountService accountService)
        {
            _customer = customer;
            _accountService = accountService;
        }
        
        public string ReturnAccountsMenu()
        {
            // should call function that calls database to retrieve userid, passport/driving license and address
            GetUserAccounts();
            // should verify if the passport/driving license or address is valid
            // also checks that it returns a non empty results
            if (_accounts.Count > 0)
            {
                StringBuilder menu = new StringBuilder();
                
                foreach (var account in _accounts)
                {
                    menu.AppendLine($"{account.AccountNumber} - {account.AccountType}: Balance {account.Balance}");
                }
                return menu.ToString();
            }
            // if no accounts found
            else
            {
                return "No accounts found.";
            }
        }
        
        
        // method to create new account for user
        
        // method to delete account for user
        
        // returns all accounts in their name (account detials, sort code) based on user id retrieved above
        public string ReturnAccountByUserSelection(sbyte selection)
        {
            // returns account details based on user selection
            if (selection - 1 < _accounts.Count)
            {
                var selectedAccount = _accounts[selection - 1];
                return $"Selected Account {selectedAccount.AccountNumber}: Balance {selectedAccount.Balance}";
            }
            return "Invalid selection.";
        }
        
        // method to login to specific account and return more details specific to that account
        
        // Seperate method to take actions within the account such as deposit, withdraw, transfer
        
        // method to logout of account

        protected void GetUserAccounts()
        {
            var searchResults = _accountService.GetAccountsByUserID(_customer.ID);
            if (searchResults != null && searchResults.Count > 0)
            {
                _accounts = searchResults;
            }
        }
    }
}