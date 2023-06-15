using ConsoleTables;
using System;

public class AdminPrices
{
    static private RoomLogic roomLogic = Factory.roomLogic;
    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        ___     _           \r\n   /_\\  __| |_ __ (_)_ _   | _ \\_ _(_)__ ___ ___\r\n  / _ \\/ _` | '  \\| | ' \\  |  _/ '_| / _/ -_|_-<\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_| |_| |_\\__\\___/__/\r\n                                                ");
        Console.ResetColor();
        Console.WriteLine("What do you want to do?.");
        Console.WriteLine(" > [1] Change the prices of the seats of a room");
        Console.WriteLine(" > [2] See current prices of a room");
        Console.WriteLine(" > [3] Go back");
        var input = Console.ReadLine()!;

        if(input == "1")
        {
            Console.Clear();
            Change_Prices();
            Console.WriteLine("Successfully changed!\nNew list:");
            Print_Room_And_Price();

            Console.WriteLine("[ENTER] to go back.");
            Console.ReadKey();
            Console.Clear();
            Start();

        }
        else if (input == "2")
        {
            Console.Clear();

            Print_Room_And_Price();
            Console.WriteLine("[ENTER] to go back.");
            Console.ReadKey();
            Console.Clear();
            Start();
        }
        else if (input == "3")
        {
            Console.Clear();
            AdminMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid Input");
            Start();
        }
    }

    static public void Print_Room_And_Price()
    {
        var table = new ConsoleTable("Room_ID", "Total_Seats", "Price");
        //Loops through  list, and add the contents to the table.
        foreach (var room in roomLogic.Return_Room_List())
        {
            table.AddRow(room.ID,room.Total_Seats,room.Price_Per_Seat);
        }
        table.Options.EnableCount = false;

        Console.WriteLine(table);
        
    }
    static public void Change_Prices()
    {
        Print_Room_And_Price();
        bool id_bool = false;
        int your_id = 0;
        RoomModel room = default;
        while(!id_bool)
        {
            Console.WriteLine("\n\nType the id of the room you want to pick.\nTo leave press B\n");
            string input_room = Console.ReadLine().ToUpper();
            if(input_room == "B")
            {
                Start();
            }
            try
            {
                
                //Converts it into a number.
                your_id= Convert.ToInt32(input_room);
                room = roomLogic.Find_Room(your_id);
                if(room == null)
                {
                    Console.Write("This ID does not exist.");
                }
                else
                {
                    id_bool = true;
                }


            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number, please enter a correct number");
            }
        }

        Console.Clear();
        Console.WriteLine("Current Room: ");
        var table = new ConsoleTable("Room_ID", "Total_Seats", "Price");
        table.AddRow(room.ID, room.Total_Seats, room.Price_Per_Seat);
        table.Options.EnableCount = false;
        Console.WriteLine(table);

        bool price_bool = false;
        double price = 0;
        while(!price_bool)
        {
            Console.WriteLine("\n Your new price:");
            string input_room = Console.ReadLine()!;
            try
            {
                //Converts it into a number.
                price= Convert.ToDouble(input_room);
                if (price < 0)
                {
                    Console.Write("You can't make the price that low!");
                }
                else
                {
                    price_bool = true;
                }


            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number, please enter a correct number");
            }
        }
        roomLogic.Change_Price(price, room);
        







    }


}