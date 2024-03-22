using AcmeBank.Application.Interfaces;
using AcmeBank.Domain.Models;
using Npgsql;

namespace AcmeBank.Application.Services;

public class AccountAppService : IAccountAppService
{
    private readonly string _connectionString;

    public AccountAppService()
    {
        _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebankdb";
    }

    public bool CreateAccount(Account account)
    {
        if (account == null)
        {
            return false;
        }

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            
            // need to merge teller menu to this file
//             string query = @"
// INSERT INTO accounts (user_id, account_type, balance, currency"
        }
    }
}

// __________________________________________________________________________________________________________________________________

// Nikhil Code Below

// using AcmeBank.Application.Interfaces;
// using AcmeBank.Domain.Models;
// using Npgsql;
// using System;

// namespace AcmeBank.Application.Services
// {
//     // This class provides functionality to create an account in the AcmeBank system.
//     public class AccountAppService : IAccountAppService
//     {
//         // Connection string for the PostgreSQL database.
//         private readonly string _connectionString;

//         // Constructor to initialize the connection string.
//         public AccountAppService()
//         {
//             _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebankdb";
//         }

//         // Method to create an account for a user with specified details.
//         public bool CreateAccount(int userId, string accountType, decimal balance, string currency)
//         {
//             try
//             {
//                 // Establishing a connection to the PostgreSQL database.
//                 using (var conn = new NpgsqlConnection(_connectionString))
//                 {
//                     conn.Open();

//                     // SQL query to insert account details into the 'accounts' table and retrieve the generated account ID.
//                     string query = @"
//                         INSERT INTO accounts (user_id, account_type, balance, currency)
//                         VALUES (@UserId, @AccountType, @Balance, @Currency)
//                         RETURNING account_id";

//                     // Creating a command object with the SQL query and connection.
//                     using var cmd = new NpgsqlCommand(query, conn);
                    
//                     // Adding parameters to the command representing user ID, account type, balance, and currency.
//                     cmd.Parameters.AddWithValue("UserId", userId);
//                     cmd.Parameters.AddWithValue("AccountType", accountType);
//                     cmd.Parameters.AddWithValue("Balance", balance);
//                     cmd.Parameters.AddWithValue("Currency", currency);

//                     // Executing the command to insert the account details and retrieving the generated account ID.
//                     int accountId = (int)cmd.ExecuteScalar();
                    
//                     // Displaying a success message with the generated account ID.
//                     Console.WriteLine($"Account created successfully. Account ID: {accountId}");

//                     // Returning true to indicate that the account creation was successful.
//                     return true;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handling any exceptions that might occur during account creation and displaying an error message.
//                 Console.WriteLine($"Error creating account: {ex.Message}");
                
//                 // Returning false to indicate that the account creation failed.
//                 return false;
//             }
//         }
//     }
// }

