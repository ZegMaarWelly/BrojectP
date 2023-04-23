static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("|__|. _ |_   /  . _  _ _  _   |__)_ |_|_ _ _ _| _  _  \r\n|  ||(_)| )  \\__|| )(-|||(_|  | \\(_)|_|_(-| (_|(_|||| \r\n     _/                                               ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Enter 1 to login");
        Console.WriteLine("Enter 2 to add a new account");
        Console.WriteLine("Enter 3 for Cinema Info");

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
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}