// Represents the customer in the bank
// including attributes like name, ID, Contact Information, etc.


namespace AcmeBank.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public User(int userid, string name, string email, string phone, string passportNumber, 
                        string addressLine1, string addressLine2, string city, 
                        string postcode, string country)
        {
            UserId = userid;
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
        

        // Additional functionalities related to Customer can be added here
        // For example: UpdateInformation, DeactivateAccount, etc.
    }
}
