static class AdminMananageAccount
{
    static private AccountsLogic accountsLogic = new AccountsLogic();

    static public void Start()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?\n [1] Remove a user.\n[2] Add or remove VIP for a user.\n[3] See a list of all users.\n[4] Return to the admin menu.\n");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":

                break;
            case "2":

                break;

            case "3":
                
                break;
            case "4":
                AdminMenu.Start();
                break;

        }
    }

}