static class AdminMenu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Enter 1 to add/remove/change snacks");
        Console.WriteLine("Enter 2 to add items to shopping cart test");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            AdminMenuSnack.Start();
        }
        else if (input == "2")
        {
            MenuSnack.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}