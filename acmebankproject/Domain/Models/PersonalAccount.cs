// A subclass of Account, specific to personal banking accounts
// with properties and behaviors unique to personal accounts.
// e.g interest rates, overdrafts, etc.

using Npgsql;

class PersonalAccount
{
    //Store the user details
    private int _userId;
    private User _user;
    private string? _userName;

    private NpgsqlConnection _conn;
    // Query database and populate fields;

    #region Constructors - Create and View/Edit
    
    // Create Personal Account constructor
    public PersonalAccount(User user)
    {
        this._user = user;
    }
    // View/Edit Personal Account Constructor
    
    // testing database constructor
    public PersonalAccount(int user_id)
    {
        string connString = "Server=localhost;Port=5432;User Id=acme;Password=password123;Database=acme";
        this._conn = new NpgsqlConnection(connString);
        this._userId = user_id;
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
            Console.WriteLine("there is no user object.");
            Console.WriteLine("lets try with userid");
            this.SearchDBWithObjectsUserID();
            
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
    public void DisplayUserPersonalAccountById()
    {
        //query
        //string query
        
    }

    // close account

    //Search database methods

    private void SearchDBWithObjectsUserID()
    {
        this._conn.Open();
        string query = $"SELECT * FROM users WHERE user_id = {this._userId}";
        var cmd = new NpgsqlCommand(query, this._conn);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader["name"]}");
        }
    }
}