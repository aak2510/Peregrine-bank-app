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
    private bool _hasOverdraft;
    private decimal _userBalance;

    private string _connectionString;
    
    private Dictionary<string,string> _queries = new Dictionary<string, string>();

    
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

    private void setQueries()
    {
        string query1 = """
                        START TRANSACTION;
                        UPDATE personal_accounts
                        SET account_balance = account_balance - 150
                        WHERE user_id = 1 AND account_id = 2 AND account_balance > 150;
                        IF (row_affected_by_update > 0) THEN 
                            INSERT INTO transactions (personal_account_id, amount, transaction_type)
                            VALUES (2, 150, 'withdrawal');
                        END IF;
                        
                        COMMIT;
                        """;
        string queryDescription1 = "withdrawal";
        this._queries.Add(queryDescription1,query1);
    }
    
    

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
                        SELECT p.account_balance, p.overdraft, u.name
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
        decimal maxWithdrawal = this._userBalance + 1500.00m;
        Console.WriteLine($"""
                          How much does the customer wish to withdraw?
                          Max is {maxWithdrawal}\n
                          """);
        
        // Check again and withdraw
        string input = Console.ReadLine();
        decimal amountToWithdraw;
        bool parseSuccessful = false;
        if (input != null && input != ""){
            do
            { 
                parseSuccessful = Decimal.TryParse(input, out amountToWithdraw);
            } while (!parseSuccessful);
            //now withdraw 
            
        }
        
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
                        decimal readerDecimalParseValue;
                        this._userBalance = Decimal.TryParse(reader["account_balance"].ToString(), out readerDecimalParseValue) ? readerDecimalParseValue : 0;
                        
                        results.Add(reader["account_balance"].ToString());
                        if (reader["overdraft"] != null && reader["overdraft"].Equals(true))
                        {
                            this._hasOverdraft = true;
                        }
                        
                    }
                }
            }
        }

        return results;
    }
}