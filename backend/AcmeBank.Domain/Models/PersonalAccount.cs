// A subclass of Account, specific to personal banking accounts
// with properties and behaviors unique to personal accounts.
// e.g interest rates, overdrafts, etc.

using Npgsql;
using NpgsqlTypes;
using AcmeBank.Domain.Models;

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
        this.setQueries();
    }
    public PersonalAccount(int user_id, int account_id)
    {
        string connString = "Server=localhost;Port=5432;User Id=acme;Password=password123;Database=acme";
        this._connectionString = connString;
        this._userId = user_id;
        this._accountId = account_id;
        this.setQueries();
    }
    #endregion

    private void setQueries()
    {
        //Add withdrawal query
        string query = """
                        START TRANSACTION;
                        UPDATE personal_accounts
                        SET account_balance = account_balance - @withdrawal
                        WHERE user_id = @userid AND account_id = @accountid AND account_balance > @minaccountbalance;
                        IF (row_affected_by_update > 0) THEN 
                            INSERT INTO transactions (personal_account_id, amount, transaction_type)
                            VALUES (@accountid, @withdrawal, 'withdrawal');
                        END IF;
                        COMMIT;
                        """;
        string queryDescription = "DoWithdrawal";
        this._queries.Add(queryDescription,query);
        //Add GetAccountBalanceView
        query = """
                SELECT p.account_balance, p.overdraft, u.name
                FROM personal_accounts p
                INNER JOIN users u
                ON p.user_id = u.user_id
                WHERE u.user_id = @userid AND p.account_id = @accountid
                ORDER BY p.user_id
                LIMIT 1000;
                """;
        queryDescription = "GetAccountBalanceView";
        this._queries.Add(queryDescription,query);
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
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("userid", this._userId.ToString());
        parameters.Add("accountid", this._accountId.ToString());
        List<string> result = RunQueryAccountBalance(this._queries["GetAccountBalanceView"], parameters);
        Console.WriteLine($"account has £{result[0]}");
        // how much to withdraw?
        decimal maxWithdrawal = this._userBalance + 1500.00m;
        Console.Write($"""
                          How much does the customer wish to withdraw?
                          Max is {maxWithdrawal}
                          Withdraw Amount: £
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
            if (parseSuccessful)
            {
                parameters.Add("minaccountbalance", (-this._userBalance+1500.00m).ToString());
                parameters.Add("withdrawal", amountToWithdraw.ToString().Replace(".00", ""));
                RunQueryWithdraw(this._queries["DoWithdrawal"], parameters); //bool withdrawSuccessful = 
                Console.WriteLine("Withdraw attempted");
                
            }
            
        }
        
        // return success of failure
    }

    private List<string> RunQueryAccountBalance(string query, Dictionary<string, string> parameters)
    {
        List<string> results = new List<string>();
        using (var conn = new NpgsqlConnection(this._connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                //loop through parameters
                foreach (KeyValuePair<string,string> param in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + param.Key, int.Parse(param.Value) );
                }

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
                            return results;
                        }
                    }
                    
                }

                
                //return reader to be processed by origin method
                return results;

                
            }
        }
    }

    private void RunQueryWithdraw(string query, Dictionary<string, string> parameters)
    {
        List<string> results = new List<string>();
        using (var conn = new NpgsqlConnection(this._connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                //loop through parameters
                foreach (KeyValuePair<string,string> param in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + param.Key, int.Parse(param.Value) );
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.RecordsAffected);
                        // decimal readerDecimalParseValue;
                        // this._userBalance = Decimal.TryParse(reader["account_balance"].ToString(), out readerDecimalParseValue) ? readerDecimalParseValue : 0;
                        //
                        // results.Add(reader["account_balance"].ToString());
                        // if (reader["overdraft"] != null && reader["overdraft"].Equals(true))
                        // {
                        //     this._hasOverdraft = true;
                        //     return results;
                        // }
                    }
                    
                }

                
                //return reader to be processed by origin method
                //return results;

                
            }
        }
    }
}