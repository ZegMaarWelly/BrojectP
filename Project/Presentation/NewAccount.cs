
static class NewAccount
{
    static private AccountsLogic accountsLogic = Factory.accountsLogic;
    public static void Start()
    {   
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  __  __      _           _            _                      _   \r\n |  \\/  |__ _| |_____    /_\\  _ _     /_\\  __ __ ___ _  _ _ _| |_ \r\n | |\\/| / _` | / / -_)  / _ \\| ' \\   / _ \\/ _/ _/ _ \\ || | ' \\  _|\r\n |_|  |_\\__,_|_\\_\\___| /_/ \\_\\_||_| /_/ \\_\\__\\__\\___/\\_,_|_||_\\__|\r\n                                                                  ");
        Console.ResetColor();
        bool passwordSecure = false;
        int id = AccountModel.GetNextId();
        bool ValidEmail = false;
        string emailAddress;
        do
        {
            Console.WriteLine("\n > Enter your Email address: ");
            emailAddress = Console.ReadLine();
            if (accountsLogic.EmailVerification(emailAddress))
            {
                ValidEmail = true;
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid email address.");
            }

        } while (!ValidEmail);

        string password;
        do
        {
            Console.WriteLine("\n > Enter your Password: ");
            Console.WriteLine(" Passwords must consist of 8 character and contain at least 1 digit and special symbol");
            password = Console.ReadLine();
            if (accountsLogic.CheckPasswordSecurity(password))
            {
                passwordSecure = true;
            }

        } while (passwordSecure == false);
 
        Console.WriteLine("\n > Enter your Full Name (first and last name): ");
        string? fullName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\n > Would you like to use our VIP services? (Y/N)");
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
                while (lowerInput == "y" || lowerInput == "n")
                {
                   
                   AccountModel newAcc = new AccountModel(id, emailAddress, password, fullName, vip: false);
                   accountsLogic.Add_To_List(newAcc);
                   Console.WriteLine("\nYour account has been succesfully created\n > Press any button to return to the main menu");
                    Console.ReadKey();
                   Menu.Start();
                } 
            
        }

    }        
    
}