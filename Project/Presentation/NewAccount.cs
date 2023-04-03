
static class NewAccount
{ 
    public static void Start()
    {
        int id = AccountModel.GetNextId();
        Console.WriteLine("Enter your Email address: ");
        string? emailAddress = Console.ReadLine();
        Console.WriteLine("Enter your Password: ");
        string? password = Console.ReadLine();
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
                   AccountsAccess.LoadAll();
                   AccountModel newAcc = new AccountModel(id, emailAddress, password, fullName, vip: false);
                   AccountsLogic.Add_To_List(newAcc);
                   Console.WriteLine("account has been added :)");
                   Menu.Start();
                } 
            
        }

    }        
    
}