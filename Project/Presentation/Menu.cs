static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role

    static private AccountsLogic accountsLogic = Factory.accountsLogic;
    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  _  _ _      _     ");
        Console.ResetColor();
        Console.Write("  ___ _                     ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ___     _   _              _            ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\n | || (_)__ _| |_   ");
        Console.ResetColor();
        Console.Write(" / __(_)_ _  ___ _ __  __ _  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("| _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  ");
        Console.Write("\n | __ | / _` | ' \\  ");
        Console.ResetColor();
        Console.Write("| (__| | ' \\/ -_) '  \\/ _` |");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(" |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ ");
        Console.Write("\n |_||_|_\\__, |_||_|");
        Console.ResetColor();
        Console.Write("  \\___|_|_||_\\___|_|_|_\\__,_| ");
        Console.ForegroundColor= ConsoleColor.DarkGreen;
        Console.Write("|_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|");
        Console.Write("\n        |___/      \n");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("> [1] login with an existing account");
        Console.WriteLine("> [2] add a new account");
        Console.WriteLine("> [3] Cinema Info");
        Console.WriteLine("> [4] go to the movies");

        

        string input = Console.ReadLine();
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
            Console.Clear();
            NewAccount.Start();
        }
        else if (input == "3")
        {
            Console.Clear();
            CinemaInfo.Info();
            Start();
            
        }
        else if (input == "4")
        {
            Console.Clear();
            Movies.Start();
            Thread.Sleep(1000);
            Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }

    static public void Menu_When_Logged_In()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  _  _ _      _     ");
        Console.ResetColor();
        Console.Write("  ___ _                     ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ___     _   _              _            ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\n | || (_)__ _| |_   ");
        Console.ResetColor();
        Console.Write(" / __(_)_ _  ___ _ __  __ _  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("| _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  ");
        Console.Write("\n | __ | / _` | ' \\  ");
        Console.ResetColor();
        Console.Write("| (__| | ' \\/ -_) '  \\/ _` |");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(" |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ ");
        Console.Write("\n |_||_|_\\__, |_||_|");
        Console.ResetColor();
        Console.Write("  \\___|_|_||_\\___|_|_|_\\__,_| ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("|_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|");
        Console.Write("\n        |___/      \n");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("> [1] to log out ");
        Console.WriteLine("> [2] for Cinema Info");
        Console.WriteLine("> [3] to go to the movies");
        Console.WriteLine("> [4] to see reservations");

        if (accountsLogic.CheckAccountAdmin())
        {
            Console.WriteLine("> [5] go to admin Menu");
        }
        User.CurrentUser();

        string input = Console.ReadLine();
        if (input == "1")
        {
            accountsLogic.LogOut();
            Start();
        }
        else if (input == "2")
        {
            CinemaInfo.Info();
            Menu_When_Logged_In();
        }
        else if (input == "3")
        {
            Console.Clear();
            Movies.Start();
            Thread.Sleep(1000);
            Menu_When_Logged_In();
        }
        else if (input == "4")
        {
            Console.Clear();
            Reservation.See_Reservations();
            Thread.Sleep(1000);
            Menu_When_Logged_In();
        }
        else if (input == "5" && accountsLogic.CheckAccountAdmin())
        {
            
            
            Console.Clear();
            //Thread.Sleep(1000);
            AdminMenu.Start();
            Menu_When_Logged_In();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Menu_When_Logged_In();
        }
    }
    
}