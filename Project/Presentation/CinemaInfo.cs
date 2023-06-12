public class CinemaInfo
{
    public static void Info()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  _  _ _      _     ");
        Console.ResetColor();
        Console.Write("  ___ _                     ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("  ___     _   _              _            ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("\n | || (_)__ _| |_   ");
        Console.ResetColor();
        Console.Write(" / __(_)_ _  ___ _ __  __ _  ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("| _ \\___| |_| |_ ___ _ _ __| |__ _ _ __  ");
        Console.Write("\n | __ | / _` | ' \\  ");
        Console.ResetColor();
        Console.Write("| (__| | ' \\/ -_) '  \\/ _` |");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write(" |   / _ \\  _|  _/ -_) '_/ _` / _` | '  \\ ");
        Console.Write("\n |_||_|_\\__, |_||_|");
        Console.ResetColor();
        Console.Write("  \\___|_|_||_\\___|_|_|_\\__,_| ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("|_|_\\___/\\__|\\__\\___|_| \\__,_\\__,_|_|_|_|");
        Console.Write("\n        |___/      \n\n");
        Console.ResetColor();
        string[] infoLines = new string[]
            {
                "This is our Cinema named 'High Cinema Rotterdam'.",
                "It is located at Wijnhaven 107 in the bustling city of Rotterdam.",
                "We provide movies in 2D, 3D, 4D and IMAX quality.",
                "We also provide snacks and drinks for our customers to go alongside with the best movie experience of your life.",
                "For further information, do not hesitate to contact our lovely customer support.",
                "With kind regards,",
                "",
                "Project group 4. :)"
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
        Console.WriteLine("\nPress any key to go back to the menu screen.");
        Console.ReadKey();
        Console.Clear();
        //Menu.Start();
    }
}
