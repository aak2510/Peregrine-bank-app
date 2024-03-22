using AcmeBank.Application.Services;
using AcmeBank.Application.Interfaces;
using System;

namespace AcmeBank.ConsoleApp;

public class TellerLoginHandler
{
    
    private readonly ITellerAppService _tellerAppService;

    public TellerLoginHandler(ITellerAppService tellerAppService)
    {
        _tellerAppService = tellerAppService;
    }

    public bool Login()
    {
        int maxLogInAttempt = 3;

        do
        {
            Console.Write("Please enter your email: ");
            string inputEmail = Console.ReadLine()?.ToLower().Trim() ?? "";
                
            Console.Write("Please enter your password: ");
            string inputPassword = Console.ReadLine()?.Trim() ?? "";

            if (_tellerAppService.VerifyTeller(inputEmail, inputPassword))
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                maxLogInAttempt -= 1;
                if (maxLogInAttempt == 0)
                {
                    Console.WriteLine("Too many attempts - you have been locked out.");
                    return false;
                }
                Console.WriteLine($"Username or password is incorrect. You have {maxLogInAttempt} attempts left, please try again.\n");
            }
        } while (true);
    }
}

    
