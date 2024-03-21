using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IAccountAppService
    {
        List<Account> VerifyPassport(string passportNumber);
        
        bool VerifyAddress(string addressLine1, string addressLine2, string city, string postcode, string country);
    }
}