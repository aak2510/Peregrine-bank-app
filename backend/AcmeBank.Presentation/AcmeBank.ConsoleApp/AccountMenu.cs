namespace DefaultNamespace;

// // Account Menu Class Handles interactions that the teller has while operating on an account. Maybe a separate Menu Superclass should exist?
 protected class AccountMenu
 {
     // Stores the customer object to easily make calls to the database
     private Customer _customer = new Customer();
     
     // Stores the accounts information
     private List<Account> _accounts = new List<Account>();
     
     // AccountAppService should be injected. for now it is saved here
     private AccountService _accountService = new AccountService(IAccountRepository accountRepository);
     
     // Default constructor
    public AccountMenu(Customer customer)
     {
         this._customer = customer;
     }
     
     // Display Accounts menu
     public string ReturnAccountsMenu()
     {
        //have we got accounts yet?
         this.GetUserAccounts();
         if (this._accounts)
         {
             //Loop through accounts and add them to a Stringbuilder which returns the string
         }
         else
        {
             return false;
         }
         
     }
     
     // Display Single Account menu
     public string ReturnAccountByUserSelection(sbyte selection)
    {
         //if 
         //if list it bigger that selection. assume list item exists
         if (selection-1 < this._accounts.Count)
         {
            //
         }
     }

    protected void GetUserAccounts()
    {
        //Assume the teller is logged in and hasn't moved away from desk
        //Get accounts
        var searchResults = this._accountService.GetAccountsByUserID(user.ID);
        // if result not empty
        if (searchResults != "No results from database!")
        {
            //populate accounts
            PopulateAccounts(searchResults);
        }
    }
}