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
        Console.WriteLine(" > [1] add/remove/change snacks.");
        Console.WriteLine(" > [2] change prices");
        Console.WriteLine(" > [3] admin manage accounts.");
        Console.WriteLine(" > [4] go the the beginning of the program.");
        Console.WriteLine(" > [5] add/remove/change movies.");
        Console.WriteLine(" > [6] admin manage movie.");
        Console.WriteLine(" > [7] add a movie room");
        Console.WriteLine(" > [8] Quit the Program.");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            AdminMenuSnack.Start();
        }
        else if (input == "2")
        {
            Console.Clear();
            AdminPrices.Start();
        }
        else if (input == "3")
        {
            AdminMananageAccount.Start();
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
            Console.Clear();
            AdminRoom.Start();
        }
        else if (input == "8")
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