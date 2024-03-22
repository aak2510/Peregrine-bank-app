using System;
using Npgsql;

class Program
    {
        // This method is the entry point for running the program.
        public static void RunProgram()
        {
            Console.WriteLine(@"
                Welcome to Acme Bank!
                This is the teller login screen. Please enter your username and password when prompted.
                You only have 3 attempts before being locked out.
            ");

            // If successful user login, then ask for customer credentials and check if an account exists.
            if (TellerLogIn())
            {
                TellerMenu();
            }
            else
            {
                // If teller login reaches max attempts, then we assume they would be locked out and have to ask IT team to reset password.
                Console.WriteLine("Please contact the IT administration team.");
            }
        }

        // Handles the login logic for the teller.
        public static bool TellerLogIn()
        {
            // Placeholder information for login, replace with database query.
            string name = "teller";
            string password = "password";
            int maxLogInAttempt = 3;

            do
            {
                // Ask user for username, not case sensitive, so we convert to the same case.
                Console.Write("Please enter your username: ");
                string inputUsername = Console.ReadLine()?.ToLower().Trim() ?? "";
                // Password IS case sensitive, so we don't change case.
                Console.Write("Please enter your password: ");
                string inputPassword = Console.ReadLine()?.Trim() ?? "";

                // Placeholder logic for checking credentials, replace with actual database check.
                if (inputUsername == name && inputPassword == password)
                {
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

            } while (true); // Loop continues until a valid login or lockout.
        }

        // Displays the main menu to the teller after a successful login.
        public static void TellerMenu()
        {
            do
            {
                Console.WriteLine(@"
                    ==========================================================
                                      Teller - Main menu
                          Please choose one of the following options:
                                      1. User accounts.
                                      2. Sign out/Exit the system.
                ");

                Console.Write(@"Please choose option ""1"" or ""2"": ");
                if (int.TryParse(Console.ReadLine(), out int menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            // Placeholder for handling customer accounts.
                            AccountInformation();
                            break;
                        case 2:
                            // Exiting the program for now, but in a real application, you might want to log out the user.
                            return;
                        default:
                            Console.WriteLine("Unknown option, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
            } while (true); // Loop continues until the user decides to exit.
        }

        // Placeholder for displaying account information, requires implementation.
        public static void AccountInformation()
        {
            // This method would interact with the banking system to retrieve and display account information.
            Console.WriteLine("Account information feature is not implemented yet.");
        }

        // Main entry point of the program.
        static void Main(string[] args)
        {
            // Starts the application.
            //RunProgram();
            System.Console.WriteLine("helloworld");
            PersonalAccount acc = new PersonalAccount(1,1);
            acc.WithdrawMoney();

        }
    }

