// A subclass of Account, specific to personal banking accounts
// with properties and behaviors unique to personal accounts.
// e.g interest rates, overdrafts, etc.

using Npgsql;

class PersonalAccount
{
    //Store the user details
    private User _user;

    private NpgsqlConnection _conn;
    // Query database and populate fields;

    #region Constructors

    public PersonalAccount(User user, NpgsqlConnection conn)
    {
        _user = user;
        _conn = conn;
    }

    #endregion
    
    
    

    // Open personal account
    /*
     * MUST have:
     * Registered user account
     * must supply customer id to search for passport and driver license details of user account
     * opening balance >= £1
     *
     */
    public void OpenPersonalAccount()
    {
        // is there a customer account?
        if (this._user == null)
        {
            //Search for user
        }
        else
        {
            //start creation process
            //overdraft?
            //opening balance?
            //Generate sort and account number  
            //if above is okay then double check details 
            //if still okay create
        }
    }
    

    // view account 

    // close account

    //
}