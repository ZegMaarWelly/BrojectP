
public static class UserLogin 
{
    static public AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        while (true) 
        {
        Console.Clear();
        int loginAttempts = 0;
            // this code makes use of a while loop so that you have 3 tries to log in, then it locks the console app for 30 seconds.
        while (loginAttempts < 3)
        {
                //asks for inputs to log in
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("  _   _               _              _      \r\n | | | |___ ___ _ _  | |   ___  __ _(_)_ _  \r\n | |_| (_-</ -_) '_| | |__/ _ \\/ _` | | ' \\ \r\n  \\___//__/\\___|_|   |____\\___/\\__, |_|_||_|\r\n                               |___/        ");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine(" > Please enter your email address: ");
            string email = Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.WriteLine("  _   _               ___                              _ \r\n | | | |___ ___ _ _  | _ \\__ _ _______ __ _____ _ _ __| |\r\n | |_| (_-</ -_) '_| |  _/ _` (_-<_-< V  V / _ \\ '_/ _` |\r\n  \\___//__/\\___|_|   |_| \\__,_/__/__/\\_/\\_/\\___/_| \\__,_|\r\n                                                         \r\n");
            Console.ResetColor();
            Console.WriteLine(" > Please enter your password:  ");
            string password = Console.ReadLine();
            Console.Clear();
            bool acc = Isloginvalid(email, password);
            if (IsAdmin(email, password))
            {
                    Menu.Menu_When_Logged_In();
            }
            else if (acc == true)
            {
                Menu.Menu_When_Logged_In();
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
    // checks for Admin if he's loggin in if it is you get send to the admin menu.
    public static bool IsAdmin(string email, string password)
    {
        return (email == "Admin" && password == "Admin") || (email == "A" && password == "A");
    }
    //checks for valid login credentials and based on that you can log in or not.
    public static bool Isloginvalid(string email, string password)
    {
        return accountsLogic.CheckLogin(email, password) != null;
    }
}