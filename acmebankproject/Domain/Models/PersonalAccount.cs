// A subclass of Account, specific to personal banking accounts
// with properties and behaviors unique to personal accounts.
// e.g interest rates, overdrafts, etc.

using Npgsql;
using NpgsqlTypes;

class PersonalAccount
{
    //Store the user details
    private int _userId;
    private User _user;
    private string? _userName;
    private int _accountId;

    private string _connectionString;
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
        this._connectionString = connString;
        this._userId = user_id;
    }
    public PersonalAccount(int user_id, int account_id)
    {
        string connString = "Server=localhost;Port=5432;User Id=acme;Password=password123;Database=acme";
        this._connectionString = connString;
        this._userId = user_id;
        this._accountId = account_id;
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
        //this._conn.Open();
        string query = $"SELECT * FROM users WHERE user_id = {this._userId}";
        //var cmd = new NpgsqlCommand(query, this._conn);
        //var reader = cmd.ExecuteReader();
        //while (reader.Read())
        //{
          //  Console.WriteLine($"{reader["name"]}");
        //}
    }
    
    // Create Transaction
    public void WithdrawMoney()
    {
        // check current balance of account with db call
        string query = """
                        SELECT p.account_balance, p.overdraft, p. u.name
                        FROM personal_accounts p
                        INNER JOIN users u
                        ON p.user_id = u.user_id
                        WHERE u.user_id = @userid AND p.account_id = @accountid
                        ORDER BY p.user_id
                        LIMIT 1000;
                        """;
        List<string> result = RunQuery(query);
        Console.WriteLine($"account has £{result[0]}");
        // how much to withdraw?
        Console.WriteLine("How much does the customer wish to withdraw?");
        // Check again and withdraw
        // return success of failure
    }

    private void DepositMoney()
    {
        
    }

    private void TransferToAccount()
    {
        
    }

    private List<string> RunQuery(string query)
    {
        List<string> results = new List<string>();
        using (var conn = new NpgsqlConnection(this._connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userid", this._userId);
                cmd.Parameters.AddWithValue("@accountid", this._accountId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(reader["account_balance"].ToString());
                    }
                }
            }
        }

        return results;
    }
}