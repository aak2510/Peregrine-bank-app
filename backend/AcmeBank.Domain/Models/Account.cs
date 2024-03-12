namespace AcmeBank.Domain.Models;
public abstract class Account
{
    public string AccountNumber { get; set; }
    public string SortCode { get; set; }
    public decimal Balance { get; set; }
    public DateTime OpeningDate { get; set; }
    
    protected Account(string accountNumber, string sortCode)
    {
        AccountNumber = accountNumber;
        SortCode = sortCode;
        OpeningDate = DateTime.Now;
    }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
    }
}