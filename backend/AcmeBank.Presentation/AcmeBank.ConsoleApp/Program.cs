using System;
using AcmeBank.Application.Services;

namespace AcmeBank.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Acme Bank");
        Console.WriteLine("Please enter your account number");
        var accountNumber = Console.ReadLine();
        Console.WriteLine("Please enter your sort code");
        var sortCode = Console.ReadLine();
        
        // Call the account service to get the account
        var accountService = new AccountService();
        //
        var account = accountService.GetAccountByNumber(accountNumber, sortCode);
    }
}
