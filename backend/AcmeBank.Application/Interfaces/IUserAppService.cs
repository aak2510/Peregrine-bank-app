using AcmeBank.Domain.Models;
using System.Collections.Generic;

namespace AcmeBank.Application.Interfaces
{
    public interface IUserAppService
    {
        bool VerifyPassportNumber(string passportNumber, out List<User> users);

        bool VerifyAddress(User user, string addressLine1);
    }
}