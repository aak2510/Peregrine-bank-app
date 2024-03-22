using AcmeBank.Application.Interfaces;
using AcmeBank.Domain.Models;
using System;
using System.Collections.Generic;

namespace AcmeBank.ConsoleApp;

public class UserLoginHandler
{
    // A private read-only field of type IUserAppService. This service is used to verify user credentials.
    private readonly IUserAppService _userAppService;

    // The constructor for the UserLoginHandler class. It takes an instance of IUserAppService as a parameter.
    // The passed in IUserAppService instance is assigned to the private field _userAppService.
    public UserLoginHandler(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    // This method handles the login process for a user.
    public User HandleLogin()
    {
        Console.WriteLine("Please enter the customer's Passport Number:");
        string passportNumber = Console.ReadLine()?.Trim() ?? "";

        Console.WriteLine("Please enter the first line of the customer's address:");
        string addressLine1 = Console.ReadLine()?.Trim() ?? "";

        List<User> users;
        if (_userAppService.VerifyPassportNumber(passportNumber, out users) && users.Count > 0)
        {
            User user = users[0];
            if (_userAppService.VerifyAddress(user, addressLine1))
            {
                // Fetch security question for the verified user
                string securityQuestion = _userAppService.GetSecurityQuestion(user, user.UserId);
                if (!string.IsNullOrEmpty(securityQuestion))
                {
                    // Ask the user to answer the security question
                    Console.WriteLine($"Please answer the security question: {securityQuestion}");
                    string securityAnswer = Console.ReadLine()?.Trim() ?? "";

                    // Verify the security question's answer
                    if (_userAppService.VerifySecurityQuestion(user, user.UserId, securityQuestion, securityAnswer))
                    {
                        Console.WriteLine("Security question answered correctly. Login successful.");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect answer to security question.");
                    }
                }
                else
                {
                    Console.WriteLine("No security question found for user.");
                }
            }
        }

        Console.WriteLine("Login failed.");
        return null;
    }
}
