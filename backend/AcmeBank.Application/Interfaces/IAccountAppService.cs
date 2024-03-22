using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IAccountAppService
    {
        bool VerifyPassportNumber(string passportNumber, out List<User> users);

        bool VerifyAddress(User user, string addressLine1, string addressLine2, string city, string postcode,
            string country);
    }
}