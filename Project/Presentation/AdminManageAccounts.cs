using ConsoleTables;

static class AdminMananageAccount
{
    static private AccountsLogic accountsLogic = new AccountsLogic();

    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __                             _                      _      \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |__ _ _ _  __ _ __ _ ___    /_\\  __ __ ___ _  _ _ _| |_ ___\r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / _` | ' \\/ _` / _` / -_)  / _ \\/ _/ _/ _ \\ || | ' \\  _(_-<\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\__,_|_||_\\__,_\\__, \\___| /_/ \\_\\__\\__\\___/\\_,_|_||_\\__/__/\r\n                                                 |___/                                       ");
        Console.ResetColor();
        Console.WriteLine("\n\nWhat would you like to do?\n [1] Remove a user.\n [2] Add or remove VIP for a user.\n [3] See a list of all users.\n [4] Return to the admin menu.\n");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Remove_User();
                break;

            case "2":
                Manage_VIP();
                break;

            case "3":
                List_of_Users();
                break;

            case "4":
                AdminMenu.Start();
                break;

        }
    }

    public static void List_of_Users()
    {
        Console.Clear();
        List<AccountModel> Account_list = accountsLogic.Return_Account_List();
        ConsoleTable.From<AccountModel>(Account_list).Write(Format.Alternative);
        Console.WriteLine(" > Press [Enter] to return to the admin manage accounts menu");
        Console.ReadLine();
        Console.Clear();
        Start();
    }

    public static void Remove_User()
    {
        Console.Clear();
        List<AccountModel> Account_list = accountsLogic.Return_Account_List();
        ConsoleTable.From<AccountModel>(Account_list).Write(Format.Alternative);
        Console.WriteLine("Which user would you like to remove? (Please provide their email adress)\n");

        AccountModel selected_account = null;
        string email = Console.ReadLine();
        selected_account = accountsLogic.Find_User(email);
        if( email == null )
        {
            Console.WriteLine("\nUser was not found, press any key to admin manage accounts menu");
            Console.ReadKey();
            Start();
        }
        else
        {
            Console.WriteLine($"\nAre you sure you wish to delete {selected_account.FullName}'s account? (Y/N)\n");
            while (true) 
            {
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "Y":
                        accountsLogic.Delete_From_List(selected_account);
                        Console.WriteLine($"{selected_account.FullName} has been deleted from the list. Press any key to return to admin manage accounts menu\n");
                        Console.ReadKey();
                        Start();
                        break;

                    case "N":
                        Console.WriteLine("Deletion canceled. Press any key to return to admin manage accounts menu\n");
                        Console.ReadKey();
                        Start();
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again\n");
                        break;
                }
            }
        }
    }

    public static void Manage_VIP()
    {
        Console.Clear();
        List<AccountModel> Account_list = accountsLogic.Return_Account_List();
        ConsoleTable.From<AccountModel>(Account_list).Write(Format.Alternative);
        Console.WriteLine("Which user's VIP status would you like to change? (Please provide their email adress)\n");

        AccountModel selected_account = null;
        string email = Console.ReadLine();
        selected_account = accountsLogic.Find_User(email);
        if (email == null)
        {
            Console.WriteLine("\nUser was not found, press any key to admin manage accounts menu");
            Console.ReadKey();
            Start();
        }
        else
        {
            accountsLogic.Return_User_VIP(email);
            Console.WriteLine($"\nAre you sure you want to swap {selected_account.FullName}'s VIP status to {selected_account.Vip}? (Y/N)\n");
            while (true) 
            {
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "Y":
                        bool new_vip_status = selected_account.Vip;
                        accountsLogic.Update_User_VIP(new_vip_status, selected_account);
                        Console.WriteLine($"{selected_account.FullName}'s VIP status has been changed to {selected_account.Vip}. Press any key to return to admin manage accounts menu\n");
                        Console.ReadKey();
                        Start();
                        break;

                    case "N":
                        Console.WriteLine("Deletion canceled. Press any key to return to admin manage accounts menu\n");
                        Console.ReadKey();
                        Start();
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again\n");
                        break;
                }
            }
        }
    }
}