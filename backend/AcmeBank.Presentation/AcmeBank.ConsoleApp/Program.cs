using System;
using Npgsql;

namespace AcmeBank.ConsoleApp
{
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
                                      1. Customer accounts.
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
        // Method to display account information.
        public static void AccountInformation()
        {
            string connString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebankdb";

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); // Open the database connection

                    // Define a query to select all users.
                    string query = "SELECT * FROM users";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Execute the query and obtain a result set.
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Iterate through each record in the result set
                            {
                                // Display the fields from each record.
                                Console.WriteLine($"Name: {reader["name"]}, Email: {reader["email"]}, Phone: {reader["phone"]}, Passport Number: {reader["passport_number"]}, Address: {reader["address_line1"]} {reader["address_line2"] ?? ""}, City: {reader["city"]}, Postcode: {reader["postcode"]}, Country: {reader["country"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Main entry point of the program.
        static void Main(string[] args)
        {
            // Starts the application.
            RunProgram();
        }
    }
}
