using AcmeBank.Application.Interfaces;
using AcmeBank.Domain.Models;
using System;
using System.Collections.Generic;

namespace AcmeBank.ConsoleApp
{
    public class UserLoginHandler
    {
        private readonly IUserAppService _userAppService;

        public UserLoginHandler(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public User HandleLogin()
        {
            Console.WriteLine("Please enter the customer's Passport Number:");
            string passportNumber = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine("Please enter the first line of the customer's address:");
            string addressLine1 = Console.ReadLine()?.Trim() ?? "";

            List<User> users;
            if (_userAppService.VerifyPassportNumber(passportNumber, out users) && users.Count > 0)
            {
                // Assuming we're only interested in the first matched user
                User user = users[0];
                if (_userAppService.VerifyAddress(user, addressLine1))
                {
                    Console.WriteLine("Login successful.");
                    return user;
                }
            }

            Console.WriteLine("Login failed.");
            return null;
        }
    }
}