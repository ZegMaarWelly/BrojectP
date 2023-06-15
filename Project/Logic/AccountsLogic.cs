using System.Text.RegularExpressions;
using System;
using System.Security.Principal;

//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic : IAccountsLogic
{
    static private List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get;  set; }

    public AccountsLogic()
    {
        _accounts = AccountsAccess.LoadAll();
    }
    public List<AccountModel> Return_Account_List()
    {
        _accounts = AccountsAccess.LoadAll();
        return _accounts;
    }

    public AccountModel Return_Current_User()
    {
        return CurrentAccount!;
    }

   

    public void LogOut()
    {
        CurrentAccount = null;
    }

    public bool CheckAccountAdmin()
    {
        if (CurrentAccount.EmailAddress == "Admin" && CurrentAccount.Password == "Admin"
            || CurrentAccount.EmailAddress == "A" && CurrentAccount.Password == "A")
        {
            return true;
        }
        else
        {
            return false;
        }
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

    public void Delete_From_List(AccountModel account)
    {
        _accounts.Remove(account);
        AccountsAccess.WriteAll(_accounts);
    }

    public void Add_To_List(AccountModel newAccount)
    {
        _accounts.Add(newAccount);
        AccountsAccess.WriteAll(_accounts);
    }
    
    // Checks if password meets security requirements
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

    // verifies if password contains symbols
    public bool PasswordSymbolChecker(string password)
    {
        string pattern = @"[\p{P}\p{S}]";
        bool hasSymbols = Regex.IsMatch(password, pattern);
        return hasSymbols;
    }

    // verifies if email contains an @ symbol or has a valid suffix
    public bool EmailVerification(string email)
    {
        // Check for exactly one @ symbol
        int atSymbolCount = email.Count(c => c == '@');
        if (atSymbolCount != 1)
            return false;

        // Check if email ends with .com, .net, or .nl
        bool endsWithValidDomain = Regex.IsMatch(email, @"\.(com|net|nl)$");
        if (!endsWithValidDomain)
            return false;

        bool hasNoSpaces = email.Contains(" ");
        if (hasNoSpaces)
            return false;

        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        bool hasSymbols = Regex.IsMatch(email, pattern);
        if (!hasSymbols)
            return false;
        
        return true;
    }


    //gets the age of the user from their date of birth and returns it.
    public int Age_Of_Current_User()
    {
        var date_of_birth = CurrentAccount.Date_Of_Birth;
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - date_of_birth.Year;
        if (currentDate.Month < date_of_birth.Month || (currentDate.Month == date_of_birth.Month && currentDate.Day < date_of_birth.Day))
        {
            age--;
        }

        return age;
    }

    // Checks if the email adress argument is already an existing email in the list.
    public bool Existing_Account(string email)
    {
        bool It_Exist = false;
        foreach(var account in _accounts)
        {
            if(account.EmailAddress == email)
            {
                It_Exist = true;
            }
        }
        return It_Exist;
    }

    public AccountModel Find_User(string email)
    {
        foreach (AccountModel user in _accounts)
        {
            if (user.EmailAddress == email)
            {
                return user;
            }
        }
        return null;
    }

    public void Update_User_VIP(bool value, AccountModel user)
    {
        user.Vip = value;
        int accountsindex = _accounts.IndexOf(user);
        _accounts[accountsindex] = user;
        AccountsAccess.WriteAll(_accounts);
    }

    // Checks if a given user's name is in the list and returns the opposite of their VIP status
    public AccountModel Return_User_VIP(string email)
    {
        foreach (AccountModel user in _accounts)
        {
            if (user.EmailAddress == email)
            {
                user.Vip = !user.Vip;
                return user;
            }
        }
        return null;
    }
}

