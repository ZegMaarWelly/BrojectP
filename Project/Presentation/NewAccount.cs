
using System.Globalization;

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
                if(!accountsLogic.Existing_Account(emailAddress))
                {
                    ValidEmail = true;
                }
                else
                {
                    Console.WriteLine($"There is already someone registered with the emailadress {emailAddress}");
                }
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

        static DateTime Get_Date()
        {
            DateTime date = default;
            bool while_loop = true;
            while (while_loop)
            {
                // Asks the user for their date
                string your_date = Console.ReadLine()!;
                try
                {
                    date = DateTime.ParseExact(your_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    if(date > DateTime.Now)
                    {
                        Console.WriteLine("You can't be born in the future, stupid!");
                    }
                    else
                    {
                        while_loop = false;
                    }
                }
                //Catches any type of exception.
                catch
                {
                    Console.WriteLine("Invalid date, please enter a correct date");
                }
            }
            return date.Date;
        }

        Console.WriteLine("\n > Enter your date of birth: \n (YYYY-MM-DD) ");
        DateTime date_of_birth = Get_Date();
         
        Console.WriteLine("\n > Enter your Full Name (first and last name): ");
        string? fullName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\n > Would you like to use our VIP services? (Y/N)");
            string? input = Console.ReadLine();
            string lowerInput = input.ToLower();
            bool vip = false;
            
                if (lowerInput == "y")
                {
                    vip = true;
                }
                else if (lowerInput == "n")
                {
                    vip = false;
                }
                while (lowerInput == "y" || lowerInput == "n")
                {
                   
                   AccountModel newAcc = new AccountModel(id, emailAddress, password, date_of_birth, fullName, vip);
                   accountsLogic.Add_To_List(newAcc);
                   Console.WriteLine("\nYour account has been succesfully created\n > Press any button to return to the main menu");
                    Console.ReadKey();
                Menu.Menu_When_Logged_In();
                } 
            
        }

    }        
    
}