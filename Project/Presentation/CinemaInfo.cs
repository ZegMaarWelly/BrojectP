public class CinemaInfo
{
    public static void Info()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("|__|. _ |_   /  . _  _ _  _   |__)_ |_|_ _ _ _| _  _  \r\n|  ||(_)| )  \\__|| )(-|||(_|  | \\(_)|_|_(-| (_|(_|||| \r\n     _/                                               ");
        Console.WriteLine();
        Console.ResetColor();
        string[] infoLines = new string[]
            {
                "This is our Cinema named 'High Cinema Rotterdam'",
                "it is located at 'Rotterdam Wijnhaven 107'",
                "We got 12 cinema rooms.",
                "We provide movies in 2D, 3D, 4D and IMAX quality.",
                "We also provide snacks alongside the best movie experience of your life.",
                "For further information, Contact our customer support.",
                "With kind regards Project group 4. :)"
            };

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (string line in infoLines)
        {
            Console.Write("> ");
            foreach (char c in line)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(40); // wait 25 milliseconds before writing the next character
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.WriteLine("Press enter to go back to the menu screen.");
        Console.ReadLine();
        Console.Clear();
        Menu.Start();
    }
}
