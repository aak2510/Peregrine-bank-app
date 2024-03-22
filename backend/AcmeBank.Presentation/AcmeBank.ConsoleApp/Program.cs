using AcmeBank.Application.Interfaces;
using AcmeBank.Application.Services;
using AcmeBank.Domain.Models;
using System;

namespace AcmeBank.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assuming dependency injection setup for simplicity
            ITellerAppService tellerAppService = new TellerAppService(); // Placeholder service
            IUserAppService userAppService = new UserAppService(); // Placeholder service

            // Instantiate the login handler for teller authentication
            TellerLoginHandler tellerLoginHandler = new TellerLoginHandler(tellerAppService);

            // Attempt to authenticate the teller
            if (tellerLoginHandler.Login())
            {
                // If authentication is successful, display the main teller menu
                TellerMenu(userAppService);
            }
            else
            {
                Console.WriteLine("Teller authentication failed. Please contact the IT administration team.");
            }
        }

        private static void TellerMenu(IUserAppService userAppService)
        {
            bool exitSystem = false;
            while (!exitSystem)
            {
                Console.WriteLine("""
                    ==========================================================
                                    Teller - Main menu
                    Please choose one of the following options:
                            1. Customer accounts.
                            2. Sign out/Exit the system.
                    ==========================================================
                """);

                Console.Write("Please choose option \"1\" or \"2\": ");
                if (int.TryParse(Console.ReadLine(), out int menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            UserLogin(userAppService);
                            break;
                        case 2:
                            Console.WriteLine("Signing out.");
                            exitSystem = true;
                            break;
                        default:
                            Console.WriteLine("Unknown option, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            }
        }

        private static void UserLogin(IUserAppService userAppService)
        {
            UserLoginHandler userLoginHandler = new UserLoginHandler(userAppService);

            var verifiedUser = userLoginHandler.HandleLogin();
            if (verifiedUser != null)
            {
                Console.WriteLine("User verification successful.");
                OptionsTellerMenu(verifiedUser);
            }
            else
            {
                Console.WriteLine("User verification failed.");
            }
        }

        private static void OptionsTellerMenu(User verifiedUser)
        {
            Console.WriteLine("""
                ==========================================================
                                Options - Main menu
                Please choose one of the following options:
                        1. Create an account
                        2. Display All Accounts
                        3. Delete an account
                ==========================================================
            """);

            Console.Write("Please choose option \"1\", \"2\", or \"3\": ");
            if (int.TryParse(Console.ReadLine(), out int optionsChoice))
            {
                switch (optionsChoice)
                {
                    case 1:
                        Console.WriteLine("Placeholder for creating an account.");
                        // Placeholder logic to create an account
                        break;
                    case 2:
                        Console.WriteLine("Placeholder for displaying all accounts.");
                        // Placeholder logic to display accounts
                        break;
                    case 3:
                        Console.WriteLine("Placeholder for deleting an account.");
                        // Placeholder logic to delete an account
                        break;
                    default:
                        Console.WriteLine("Unknown option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }
    }
}