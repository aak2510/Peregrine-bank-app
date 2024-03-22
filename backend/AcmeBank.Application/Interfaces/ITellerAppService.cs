namespace AcmeBank.Application.Interfaces;
public interface ITellerAppService
{
    bool VerifyTeller(string email, string password);
}