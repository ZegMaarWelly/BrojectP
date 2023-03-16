static class AdminMenu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Enter 1 to add/remove/change snacks");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            AdminMenuSnack.Start();
        }
        else if (input == "2")
        {
            Console.WriteLine("This feature is not yet implemented");
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}