using Npgsql;

    public class AccountAppService : IAccountAppService
    {
        private readonly string _connectionString;

        public AccountAppService()
        {
            _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=9596;Database=acmebanktestdb";
        }

        public List<User> VerifyPassportNumber(string passportNumber)
        {
            var users = new List<User>();

            if (!string.IsNullOrEmpty(passportNumber))
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT id, name, email, phone, passport_number, address_line1, address_line2, city, postcode, country
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
            }

            return users;
        }

        public bool VerifyAddress(User user, string addressLine1, string addressLine2, string city, string postcode, string country)
        {
            // Check AddressLine1
            bool isAddressLine1Valid = string.Equals(user.AddressLine1, addressLine1, StringComparison.OrdinalIgnoreCase);

            // Check AddressLine2, accounting for nulls on both sides
            bool isAddressLine2Valid = (user.AddressLine2 == null && addressLine2 == null) ||
                                       (user.AddressLine2 != null && user.AddressLine2.Equals(addressLine2, StringComparison.OrdinalIgnoreCase));

            // Similar checks for City, Postcode, and Country
            bool isCityValid = string.Equals(user.City, city, StringComparison.OrdinalIgnoreCase);
            bool isPostcodeValid = string.Equals(user.Postcode, postcode, StringComparison.OrdinalIgnoreCase);
            bool isCountryValid = string.Equals(user.Country, country, StringComparison.OrdinalIgnoreCase);

            // If all parts of the address are valid, return true
            return isAddressLine1Valid && isAddressLine2Valid && isCityValid && isPostcodeValid && isCountryValid;
        }
        
        

    }
