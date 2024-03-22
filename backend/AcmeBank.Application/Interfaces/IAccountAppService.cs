using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IAccountAppService
    {
        void CreateAccount(Account account);
        List<Account> GetAllAccounts();
        void DeleteAccount(int accountId);
    }
}