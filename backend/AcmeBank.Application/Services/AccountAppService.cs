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