using System;

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
        Console.WriteLine("  _  _ _      _       ___ _                       ___     _   _              _            \r\n | || (_)__ _| |_    / __(_)_ _  ___ _ __  __ _  | _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  \r\n | __ | / _` | ' \\  | (__| | ' \\/ -_) '  \\/ _` | |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ \r\n |_||_|_\\__, |_||_|  \\___|_|_||_\\___|_|_|_\\__,_| |_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|\r\n        |___/                                                                            ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("> Enter [1] to login");
        Console.WriteLine("> Enter [2] to add a new account");
        Console.WriteLine("> Enter [3] for Cinema Info");
        Console.WriteLine("> Enter [4] to go to the movies");

        

        string input = Console.ReadLine();
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
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
        Console.WriteLine("  _  _ _      _       ___ _                       ___     _   _              _            \r\n | || (_)__ _| |_    / __(_)_ _  ___ _ __  __ _  | _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  \r\n | __ | / _` | ' \\  | (__| | ' \\/ -_) '  \\/ _` | |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ \r\n |_||_|_\\__, |_||_|  \\___|_|_||_\\___|_|_|_\\__,_| |_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|\r\n        |___/                                                                            ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("> Enter [1] to log out ");
        Console.WriteLine("> Enter [2] for Cinema Info");
        Console.WriteLine("> Enter [3] to go to the movies");
        Console.WriteLine("> Enter [4] to see reservations");

        if (accountsLogic.CheckAccountAdmin())
        {
            Console.WriteLine("> Enter [5] to go to admin Menu");
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