public class AdminRoom
{
    static private RoomLogic roomLogic = Factory.roomLogic;
    public static void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _   _  _               ___ _                       ___                \r\n   /_\\  __| |__| | | \\| |_____ __ __  / __(_)_ _  ___ _ __  __ _  | _ \\___  ___ _ __  \r\n  / _ \\/ _` / _` | | .` / -_) V  V / | (__| | ' \\/ -_) '  \\/ _` | |   / _ \\/ _ \\ '  \\ \r\n /_/ \\_\\__,_\\__,_| |_|\\_\\___|\\_/\\_/   \\___|_|_||_\\___|_|_|_\\__,_| |_|_\\___/\\___/_|_|_|\r\n                                                                                     ");
        Console.ResetColor();
        int rows = 0;
        int chairs = 0;
        bool switch1 = true;
        while (switch1 == true)
        {
            if (rows <= 0 || rows > 20)
            {
                Console.WriteLine("\n > How many rows would you like to have in the room. (max 20)");
                rows = Convert.ToInt32(Console.ReadLine());

            }
            if (chairs <= 0 || chairs > 30)
            {
                Console.WriteLine("\n > How many chairs would you like per row? (Max 30)");
                chairs = Convert.ToInt32(Console.ReadLine());
            }
            if (rows > 0 && rows <= 30 && chairs > 0 && chairs <= 30)
            {
                switch1 = false;
            }
            Console.WriteLine("Your measurements for the room are not available.");
        }
        roomLogic.Add_Room(chairs, rows);
    }
}