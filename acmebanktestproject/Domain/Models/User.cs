public class User
{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public User(string name, string email, string phone, string passportNumber, 
                        string addressLine1, string addressLine2, string city, 
                        string postcode, string country)
        {
            Name = name;
            Email = email;
            Phone = phone;
            PassportNumber = passportNumber;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Postcode = postcode;
            Country = country;
        }

        // Example method to validate customer information
        // This method can be expanded based on specific validation requirements
        public bool ValidateInformation()
        {
            // Basic validation example: Ensure no required fields are empty
            bool isValid = !string.IsNullOrWhiteSpace(Name) &&
                           !string.IsNullOrWhiteSpace(Email) &&
                           !string.IsNullOrWhiteSpace(Phone) &&
                           !string.IsNullOrWhiteSpace(PassportNumber) &&
                           !string.IsNullOrWhiteSpace(AddressLine1) &&
                           !string.IsNullOrWhiteSpace(City) &&
                           !string.IsNullOrWhiteSpace(Postcode) &&
                           !string.IsNullOrWhiteSpace(Country);

            // Additional validation logic can be added here

            return isValid;
        }

        // Additional functionalities related to Customer can be added here
        // For example: UpdateInformation, DeactivateAccount, etc.
}