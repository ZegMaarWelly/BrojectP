public class CinemaInfo
{
    public static void Info()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("  _  _ _      _       ___ _                       ___     _   _              _            \r\n | || (_)__ _| |_    / __(_)_ _  ___ _ __  __ _  | _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  \r\n | __ | / _` | ' \\  | (__| | ' \\/ -_) '  \\/ _` | |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ \r\n |_||_|_\\__, |_||_|  \\___|_|_||_\\___|_|_|_\\__,_| |_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|\r\n        |___/                                                                            ");
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
                Thread.Sleep(30); 
            }
            Console.WriteLine();
        }
        Console.ResetColor();
        Console.WriteLine("Press enter to go back to the menu screen.");
        Console.ReadLine();
        Console.Clear();
        //Menu.Start();
    }
}
