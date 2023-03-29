static class AdminMenu
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("What do you want to do?.");
        Console.WriteLine("Enter 1 to add/remove/change snacks.");
        Console.WriteLine("Enter 2 to add items to shopping cart test.");
        Console.WriteLine("Enter 3 to see a list of all registered users.");
        Console.WriteLine("Enter 4 to go the the beginning of the program.");
        Console.WriteLine("Enter 5 to add/remove movies.");
        Console.WriteLine("Enter 5 to Quit the Program.");

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
            foreach (AccountModel account in Account_list)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
            AdminMenu.Start();
        }
        else if (input == "4")
        {
            Console.Clear() ;
            Menu.Start();
        }
        else if (input == "5")
        {
            Console.Clear();
            AdminMovieList.Start();
        }
        else if (input == "6")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}