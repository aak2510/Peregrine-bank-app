using Npgsql;
using BCrypt.Net;
using AcmeBank.Application.Interfaces;

namespace AcmeBank.Application.Services;

// This class implements the ITellerAppService interface and is responsible for verifying teller credentials.
public class TellerAppService : ITellerAppService
{
    // A private field to store the connection string for the database.
    private readonly string _connectionString;

    // The constructor for the TellerAppService class.
    // The connection string for the PostgreSQL database is assigned to the _connectionString field.
    public TellerAppService()
    {
        _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebankdb";
    }

    // This method verifies the teller's credentials by checking them against the database.
    public bool VerifyTeller(string email, string password)
    {
        // If the email or password is null or empty, the method returns false.
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            return false;
        }

        // A new connection to the PostgreSQL database is created using the connection string.
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            // The connection to the database is opened.
            conn.Open();

            // The SQL query to be executed is defined. It selects the teller_id, email, and password from the tellers table where the email and password match the provided values.
            string query = @"
            SELECT teller_id, email, password
            FROM tellers
            WHERE email = @email;
        ";

            // A new command is created with the SQL query and the database connection.
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                // The email and password parameters are added to the command.
                cmd.Parameters.AddWithValue("@email", email);
                
                // The command is executed and the results are read.
                using (var reader = cmd.ExecuteReader())
                {
                    // If a row is returned, the teller's email is found in the database, the conditional 'if' returns true.
                    if (reader.Read())
                    {
                        // Takes in the entered password and compares it against the storedHash for that user
                        var storedHash = reader["password"].ToString();
                        return BCrypt.Net.BCrypt.Verify(password, storedHash);
                    }

                }
            }
        }
        return false;
    }
}
