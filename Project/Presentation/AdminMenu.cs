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
<<<<<<< Updated upstream
=======
        Console.WriteLine("Enter 1 to add/remove/change snacks.");
        Console.WriteLine("Enter 2 to add items to shopping cart TEST.");
        Console.WriteLine("Enter 3 to see a list of all registered users.");
        Console.WriteLine("Enter 4 to go the the beginning of the program.");
        Console.WriteLine("Enter 5 to add/remove movies.");
        Console.WriteLine("Enter 6 to do the screening room TEST.");
        Console.WriteLine("Enter 7 to Admin Manage Movie.");
        Console.WriteLine("Enter 8 to Quit the Program.");
>>>>>>> Stashed changes
        Console.WriteLine(" > Enter 1 to add/remove/change snacks.");
        Console.WriteLine(" > Enter 2 to add items to shopping cart TEST.");
        Console.WriteLine(" > Enter 3 to see a list of all registered users.");
        Console.WriteLine(" > Enter 4 to go the the beginning of the program.");
        Console.WriteLine(" > Enter 5 to add/remove movies.");
        Console.WriteLine(" > Enter 6 to do the screening room TEST.");
        Console.WriteLine(" > Enter 7 to Admin Manage Movie.");
        Console.WriteLine(" > Enter 8 to Quit the Program.");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            AdminMenuSnack.Start();
        }
        else if (input == "2")
        {
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
            ScreeningRoom.Start();
        }
        else if (input == "7")
        {
            Console.Clear();
            AdminManageMovie.Start();
        }
        else if (input == "8")
        {
            Environment.Exit(0);
        }
        else if (input == "9")
        {
            Console.Clear();
            Reservation.Make_Reservation(AdminManageMovie.Get_Running_Movie_To_Be_Changed("2023-04-20"));
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }

}