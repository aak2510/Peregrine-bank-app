using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IAccountAppService
    {
        List<Account> VerifyPassport(string passportNumber);
        
        bool VerifyAddress
    }
}