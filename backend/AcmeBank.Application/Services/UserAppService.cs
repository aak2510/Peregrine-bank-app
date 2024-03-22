using AcmeBank.Application.Interfaces;
using AcmeBank.Domain.Models;
using System;
using System.Collections.Generic;
using Npgsql;

namespace AcmeBank.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly string _connectionString;

        public UserAppService()
        {
            _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebankdb";
        }

        public bool VerifyPassportNumber(string passportNumber, out List<User> users)
        {
            users = new List<User>();

            if (string.IsNullOrEmpty(passportNumber))
            {
                return false; // Invalid passport number
            }

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            SELECT user_id, name, email, phone, passport_number, address_line1, address_line2, city, postcode, country
            FROM users
            WHERE passport_number = @passportNumber;
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@passportNumber", passportNumber);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(
                                reader.GetInt32(reader.GetOrdinal("user_id")),
                                reader["name"].ToString(),
                                reader["email"].ToString(),
                                reader["phone"].ToString(),
                                reader["passport_number"].ToString(),
                                reader["address_line1"].ToString(),
                                reader.IsDBNull(reader.GetOrdinal("address_line2"))
                                    ? null
                                    : reader["address_line2"].ToString(),
                                reader["city"].ToString(),
                                reader["postcode"].ToString(),
                                reader["country"].ToString()
                            ));
                        }
                    }
                }
            }

            return users.Count > 0;
        }


        public bool VerifyAddress(User user, string addressLine1)
        {
            // Check AddressLine1
            bool isAddressLine1Valid =
                string.Equals(user.AddressLine1, addressLine1, StringComparison.OrdinalIgnoreCase);

            // Remove other address lines for now to simplify the logic
            // (, string addressLine2, string city, string postcode, string country)
            // // Check AddressLine2, accounting for nulls on both sides
            // bool isAddressLine2Valid = (user.AddressLine2 == null && addressLine2 == null) ||
            //                            (user.AddressLine2 != null && user.AddressLine2.Equals(addressLine2, StringComparison.OrdinalIgnoreCase));
            //
            // // Similar checks for City, Postcode, and Country
            // bool isCityValid = string.Equals(user.City, city, StringComparison.OrdinalIgnoreCase);
            // bool isPostcodeValid = string.Equals(user.Postcode, postcode, StringComparison.OrdinalIgnoreCase);
            // bool isCountryValid = string.Equals(user.Country, country, StringComparison.OrdinalIgnoreCase);
            //
            // // If all parts of the address are valid, return true
            // && isAddressLine2Valid && isCityValid && isPostcodeValid && isCountryValid;
            return isAddressLine1Valid;
        }

        public string GetSecurityQuestion(User user, int userId)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
            SELECT question
            FROM SecurityQA
            WHERE user_id = @UserId;
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["question"].ToString();
                        }
                    }
                }
            }

            return null; // Return null if no security question is found
        }

        public bool VerifySecurityQuestion(User user, int userId, string securityQuestion, string securityAnswer)
        {
            if (user == null || string.IsNullOrEmpty(securityQuestion) || string.IsNullOrEmpty(securityAnswer))
            {
                return false;
            }

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
SELECT answer AS security_answer
FROM SecurityQA
WHERE user_id = @UserId AND question = @SecurityQuestion;
";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@SecurityQuestion", securityQuestion);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedAnswer = reader["security_answer"].ToString();
                            // Compare the provided answer with the stored answer
                            return securityAnswer.Equals(storedAnswer, StringComparison.Ordinal);
                        }
                    }
                }
            }

            return false; // Return false if the answer doesn't match or no question/answer pair is found
        }
    }
}