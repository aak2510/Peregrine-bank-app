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
        // Prompting the user to enter their passport number.
        // Reading the user's input, trimming any leading or trailing white spaces, and handling potential null values.
        Console.WriteLine("Please enter the customer's Passport Number:");
        string passportNumber = Console.ReadLine()?.Trim() ?? "";

        // Prompting the user to enter the first line of their address.
        // Reading the user's input, trimming any leading or trailing white spaces, and handling potential null values.
        Console.WriteLine("Please enter the first line of the customer's address:");
        string addressLine1 = Console.ReadLine()?.Trim() ?? "";

        // A list to store the users that match the entered passport number.
        List<User> users;
        // If the entered passport number is verified by the _userAppService and there is at least one matching user,
        if (_userAppService.VerifyPassportNumber(passportNumber, out users) && users.Count > 0)
        {
            // The first matching user is selected - will only be one matching user as passport numbers are unique.
            User user = users[0];
            // If the entered address matches the selected user's address,
            if (_userAppService.VerifyAddress(user, addressLine1))
            {
                // Inform the user of successful login and return the verified user.
                Console.WriteLine("Login successful.");
                return user;
            }
        }

        // If the login attempt was unsuccessful, inform the user and return null.
        Console.WriteLine("Login failed.");
        return null;
    }
}
