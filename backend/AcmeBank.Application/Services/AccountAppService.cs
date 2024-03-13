using AcmeBank.Domain.Models;
using AcmeBank.Domain.Interfaces;

namespace AcmeBank.Application.Services;

public class AccountService
{
    // need to define interface
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public Account GetAccountByNumber(string accountNumber)
    {
        // Need to make a call to the db to get the account
        // should call infrastrcutre layer to access db
        return _accountRepository.GetAccountByNumber(accountNumber);
    }
}