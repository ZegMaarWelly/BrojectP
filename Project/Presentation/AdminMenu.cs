using ConsoleTables;

static class AdminMenu
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __              \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |___ _ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / -_) ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\___|_||_\\_,_|\r\n                                               ");
        Console.ResetColor();
        Console.WriteLine("What do you want to do?.");
        Console.WriteLine(" > [1  add/remove/change snacks.");
        Console.WriteLine(" > [2] add items to shopping cart TEST.");
        Console.WriteLine(" > [3] see a list of all registered users.");
        Console.WriteLine(" > [4] go the the beginning of the program.");
        Console.WriteLine(" > [5] add/remove movies.");
        Console.WriteLine(" > [6] Admin Manage Movie.");
        Console.WriteLine(" > [7] Quit the Program.");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            AdminMenuSnack.Start();
        }
        else if (input == "2")
        {
            Console.Clear();
            MenuSnack.Start();
        }
        else if (input == "3")
        {
            Console.Clear();
            List<AccountModel> Account_list = accountsLogic.Return_Account_List();
            //foreach (AccountModel account in Account_list)
            //{
            //    Console.WriteLine(account);
            //}
            ConsoleTable.From<AccountModel>(Account_list).Write(Format.Alternative);
            Console.WriteLine(" > Press 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
            AdminMenu.Start();
        }
        else if (input == "4")
        {
            Console.Clear() ;
            Menu.Menu_When_Logged_In();
        }
        else if (input == "5")
        {
            Console.Clear();
            AdminMovieList.Start();
        }
        else if (input == "6")
        {
            Console.Clear();
            AdminManageMovie.Start();
        }
        else if (input == "7")
        {
            Environment.Exit(0);
        }
        //else if (input == "9")
        //{
        //    Console.Clear();
        //    Reservation.Make_Reservation(AdminManageMovie.Get_Running_Movie_To_Be_Changed("2023-04-20"));
        //}
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }

}