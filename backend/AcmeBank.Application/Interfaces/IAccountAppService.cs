using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IAccountAppService
    {
        List<User> VerifyPassportNumber(string passportNumber);

        bool VerifyAddress(User user, string addressLine1, string addressLine2, string city, string postcode, string country);
    }
}