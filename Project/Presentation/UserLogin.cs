
static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        while (true) 
        {
        Console.Clear();
        int loginAttempts = 0;
        while (loginAttempts < 3)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("  _   _               _              _      \r\n | | | |___ ___ _ _  | |   ___  __ _(_)_ _  \r\n | |_| (_-</ -_) '_| | |__/ _ \\/ _` | | ' \\ \r\n  \\___//__/\\___|_|   |____\\___/\\__, |_|_||_|\r\n                               |___/        ");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("> Please enter your email address: ");
            string email = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("\r\n  _   _               ___                              _ \r\n | | | |___ ___ _ _  | _ \\__ _ _______ __ _____ _ _ __| |\r\n | |_| (_-</ -_) '_| |  _/ _` (_-<_-< V  V / _ \\ '_/ _` |\r\n  \\___//__/\\___|_|   |_| \\__,_/__/__/\\_/\\_/\\___/_| \\__,_|\r\n                                                         \r\n");
            Console.ResetColor();
            Console.WriteLine("> Please enter your password:  ");
            string password = Console.ReadLine();
            Console.Clear();
            AccountModel acc = accountsLogic.CheckLogin(email, password);
            if (email == "Admin" && password == "Admin" || email == "A" && password == "A" )
            {
                AdminMenu.Start();
            }
            else if (acc != null)
            {
                MenuSnack.Start();
            }
            else
            {
                loginAttempts++;
                Console.WriteLine("No account found with that email and password");
                Console.WriteLine($"You have {3 - loginAttempts} attempts left.");
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
        Console.WriteLine("You have reached the maximum number of login attempts. You are locked for 30 seconds.");
        Thread.Sleep(30000);
        }
    }
}