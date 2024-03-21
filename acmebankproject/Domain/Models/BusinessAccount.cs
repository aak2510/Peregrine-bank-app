namespace acmebanktestproject.Domain.Models;

// //  A subclass for business-related banking accounts
// // incorporating business-specific properties and operations
// // e.g. loans/overdrafts, cheque books, etc.
//
// class BusinessAccount : Account
// {
//     //stored in database, retrieved by querying 
//     public string BusinessName { get; set; }
//     public string BusinessFirstLine { get; set; }
//     public string BusinessSecondLine { get; set; }
//     public string BusinessPostCode { get; set; }
//     public bool HasChequeBook { get; set; }
//
//
//     public BusinessAccount(string businessName, string businessFirstLine, string businessSecondLine, string businessPostCode, 
//         bool hasChequeBook, string AccountNumber, string SortCode, decimal balance, DateTime OpeningDate) : base(AccountNumber, SortCode, balance, OpeningDate)
//     {
//         this.BusinessName = businessName;
//         this.BusinessFirstLine = businessFirstLine;
//         this.BusinessSecondLine = businessSecondLine;   
//         this.BusinessPostCode = businessPostCode;
//         this.HasChequeBook = hasChequeBook;
//
//     }
//
//
//     private bool yearlyTimer()
//     {
//         // Check to see if it has been a year since the account was made
//         return true;
//     }
//
//     public decimal chequeBookCharge()
//     {
//         if (HasChequeBook && yearlyTimer)
//         {
//             Balance--;
//         }
//     }
//
//
// }
