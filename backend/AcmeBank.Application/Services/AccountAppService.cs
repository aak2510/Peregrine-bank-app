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
            GetUserAccounts();
            if (_accounts.Count > 0)
            {
                StringBuilder menu = new StringBuilder();
                foreach (var account in _accounts)
                {
                    menu.AppendLine($"{account.AccountNumber} - {account.AccountType}: Balance {account.Balance}");
                }
                return menu.ToString();
            }
            else
            {
                return "No accounts found.";
            }
        }

        public string ReturnAccountByUserSelection(sbyte selection)
        {
            if (selection - 1 < _accounts.Count)
            {
                var selectedAccount = _accounts[selection - 1];
                return $"Selected Account {selectedAccount.AccountNumber}: Balance {selectedAccount.Balance}";
            }
            return "Invalid selection.";
        }

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