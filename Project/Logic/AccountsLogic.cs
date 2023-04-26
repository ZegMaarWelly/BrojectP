using System.Text.RegularExpressions;

//This class is not static so later on we can use inheritance and interfaces
class AccountsLogic
{
    static private List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _accounts = AccountsAccess.LoadAll();
    }
    public List<AccountModel> Return_Account_List()
    {
        return _accounts;
    }

    public AccountModel Return_Current_User()
    {
        return CurrentAccount!;
    }

    public void UpdateList(AccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _accounts.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _accounts[index] = acc;
        }
        else
        {
            //add new model
            _accounts.Add(acc);
        }
        AccountsAccess.WriteAll(_accounts);

    }

    public AccountModel GetById(int id)
    {
        return _accounts.Find(i => i.Id == id);
    }

    public AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }

    public AccountModel AccountList()
    {
        foreach (AccountModel account in _accounts)
        {
            return account;
        }
        return null;
    }

    public void Add_To_List(AccountModel newAccount)
    {
        _accounts.Add(newAccount);
        AccountsAccess.WriteAll(_accounts);
    }

    public bool CheckPasswordSecurity(string password)
    {
        bool passwordLen = false;
        bool passwordNum = false;
        bool passwordSym = false;

        if (password.Length >= 8)
        {
            passwordLen = true;
        }
        else
        {
            Console.WriteLine("Password must be at least 8 characters long.");
        }

        if (password.Any(char.IsDigit))
        {
            passwordNum = true;
        }
        else
        {
            Console.WriteLine("Password must contain one digit.");
        }

        if (PasswordSymbolChecker(password))
        {
            passwordSym = true;
        }
        else
        {
            Console.WriteLine("Password must contain at least one symbol.");
        }

        bool totalCheck = passwordLen && passwordNum && passwordSym;
        return totalCheck;
    }

    public bool PasswordSymbolChecker(string password)
    {
        string pattern = @"[\p{P}\p{S}]";
        bool hasSymbols = Regex.IsMatch(password, pattern);
        return hasSymbols;
    }
}