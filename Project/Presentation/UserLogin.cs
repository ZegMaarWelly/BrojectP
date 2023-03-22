using System.Security.Cryptography.X509Certificates;

static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.Clear();
        int loginAttempts = 0;
        while (loginAttempts < 3)
        {
            Console.WriteLine("Please enter your email address: ");
            string email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your password: ");
            string password = Console.ReadLine();
            Console.Clear();
            AccountModel acc = accountsLogic.CheckLogin(email, password);
            if (acc != null)
            {
                Console.WriteLine("Welcome back " + acc.FullName);
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
        Console.WriteLine("You have reached the maximum number of login attempts. Please contact customer support of our Cinema.");
    }
}