
static class NewAccount
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    public static void Start()
    {       
        bool passwordSecure = false;
        int id = AccountModel.GetNextId();
        bool ValidEmail = false;
        string emailAddress;
        do
        {
            Console.WriteLine("Enter your Email address: ");
            emailAddress = Console.ReadLine();
            if (accountsLogic.EmailVerification(emailAddress))
            {
                ValidEmail = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid email address.");
            }

        } while (!ValidEmail);

        string password;
        do
        {
            Console.WriteLine("Enter your Password: ");
            password = Console.ReadLine();
            if (accountsLogic.CheckPasswordSecurity(password))
            {
                passwordSecure = true;
            }

        } while (passwordSecure == false);
 
        Console.WriteLine("Enter your Full Name (first and last name): ");
        string? fullName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Would you like to use our VIP services? (y/n)");
            Console.WriteLine("There will be extra charges.");
            string? input = Console.ReadLine();
            string lowerInput = input.ToLower();
            
                if (lowerInput == "y")
                {
                    bool vip = true;
                }
                else if (lowerInput == "n")
                {
                    bool vip = false;
                }
                while (lowerInput != "y" || lowerInput == "n")
                {
                   
                   AccountModel newAcc = new AccountModel(id, emailAddress, password, fullName, vip: false);
                   accountsLogic.Add_To_List(newAcc);
                   Console.WriteLine("account has been added :)");
                   Menu.Start();
                } 
            
        }

    }        
    
}