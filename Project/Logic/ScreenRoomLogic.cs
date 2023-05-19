
using System.Runtime.CompilerServices;

class ScreenRoomLogic
{
    static private RoomLogic roomLogic = new RoomLogic();
    static private RunningMovieLogic runningmovieLogic = new RunningMovieLogic("2023-04-20");
    
    // A copy of screening_room method. Its somewhat the same but now it works with the reservation file.
    public static (List<string>, string) screening_room_reservation(List<string> map)
    {
        //List<string> screening_room = new List<string>
        //    {"N |     O O O O O O O O    ",
        //     "M |   O O O O O O O O O O  ",
        //     "L |   O O O O O O O O O O  ",
        //     "K | O O O O O O O O O O O O",
        //     "J | O O O O O O O O O O O O",
        //     "I | O O O O O O O O O O O O",
        //     "H | O O O O O O O O O O O O",
        //     "G | O O O O O O O O O O O O",
        //     "F | O O O O O O O O O O O O",
        //     "E | O O O O O O O O O O O O",
        //     "D | O O O O O O O O O O O O",
        //     "C |   O O O O O O O O O O  ",
        //     "B |     O O O O O O O O    ",
        //     "A |     O O O O O O O O    ",
        //     "  x————————————————————————",
        //     "    1 2 3 4 5 6 7 8 9 1 1 1",
        //     "                      0 1 2"};

        
        List<string> screening_room = map;

        while (true)
        {
            foreach (var chair_row in screening_room)
            {
                for (int i = 0; i < chair_row.Length; i += 2)
                {
                    if (chair_row[i] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (chair_row[i] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (chair_row[i] == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(chair_row[i] + " ");
                }
                Console.WriteLine();
            }

            Console.Clear();


            foreach (var chair_row in screening_room)
            {
                for (int i = 0; i < chair_row.Length; i += 2)
                {
                    if (chair_row[i] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (chair_row[i] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (chair_row[i] == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(chair_row[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Select a row:");
            var input_row = Console.ReadLine();
            int indrow = 0;
            if (input_row is "A") { indrow = 1; }
            else if (input_row is "B") { indrow = 2; }
            else if (input_row is "C") { indrow = 3; }
            else if (input_row is "D") { indrow = 4; }
            else if (input_row is "E") { indrow = 5; }
            else if (input_row is "F") { indrow = 6; }
            else if (input_row is "G") { indrow = 7; }
            else if (input_row is "H") { indrow = 8; }
            else if (input_row is "I") { indrow = 9; }
            else if (input_row is "J") { indrow = 10; }
            else if (input_row is "K") { indrow = 11; }
            else if (input_row is "L") { indrow = 12; }
            else if (input_row is "M") { indrow = 13; }
            else if (input_row is "N") { indrow = 14; }
            var row = (screening_room.Count - indrow - 3);
            Console.WriteLine("Select a chair:");
            var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
            var your_line = screening_room[row];
            if (your_line[input_column] == 'O')
            {
                Console.Clear();
                Console.WriteLine($"You chose chair {input_column / 2 - 1} on row {indrow} , do you want to confirm this chair place?");
                Console.WriteLine("Y/N");
                string conf = Console.ReadLine();
                conf.ToUpper();
                if (conf == "Y")
                {
                    your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");

                    screening_room[row] = your_line;
                    Console.Clear();
                    Console.WriteLine($"You have selected this chair {input_column / 2 - 1} on row {indrow}.");
                    Thread.Sleep(500);
                    Console.Clear();
                    string string_seat = $"{input_row}-{Convert.ToString(input_column / 2 -1)}";
                    Console.WriteLine(string_seat);
                    return (screening_room, string_seat);

                }
                else if (conf == "N")
                {
                    Console.Clear();
                    Console.WriteLine($"You did not confirm chair {input_column / 2 - 1} on row {indrow}.");
                    Thread.Sleep(500);
                    Console.Clear();
                    screening_room_reservation(screening_room);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("This chair is not available, please select an empty chair.");
                Thread.Sleep(300);
                Console.Clear();
                //screening_room_reservation(screening_room);
            }


        }
    }


    public static void screening_room()
    {

        //List<string> screening_room = new List<string>
        //    {"N |     O O O O O O O O    ",
        //     "M |   O O O O O O O O O O  ",
        //     "L |   O O O O O O O O O O  ",
        //     "K | O O O O O O O O O O O O",
        //     "J | O O O O O O O O O O O O",
        //     "I | O O O O O O O O O O O O",
        //     "H | O O O O O O O O O O O O",
        //     "G | O O O O O O O O O O O O",
        //     "F | O O O O O O O O O O O O",
        //     "E | O O O O O O O O O O O O",
        //     "D | O O O O O O O O O O O O",
        //     "C |   O O O O O O O O O O  ",
        //     "B |     O O O O O O O O    ",
        //     "A |     O O O O O O O O    ",
        //     "  x————————————————————————",
        //     "    1 2 3 4 5 6 7 8 9 1 1 1",
        //     "                      0 1 2"};

        Console.WriteLine("What room ID do you want to use.");
        int ID = Convert.ToInt32(Console.ReadLine());
        RoomModel room = roomLogic.Find_Room(ID);
        List<string> screening_room = room.Map;

        while (true)
        {
            foreach (var chair_row in screening_room)
            {
                for (int i = 0; i < chair_row.Length; i += 2)
                {
                    if (chair_row[i] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (chair_row[i] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (chair_row[i] == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(chair_row[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("How many chairs do you want to select?");
            var num_chairs = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            Console.Clear();
            while (num_chairs > count)
            {
                foreach (var chair_row in screening_room)
                {
                    for (int i = 0; i < chair_row.Length; i += 2)
                    {
                        if (chair_row[i] == 'O')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (chair_row[i] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (chair_row[i] == ' ')
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.Write(chair_row[i] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Select a row:");
                var input_row = Console.ReadLine();
                int indrow = 0;
                if (input_row is "A") { indrow = 1; }
                else if (input_row is "B") { indrow = 2; }
                else if (input_row is "C") { indrow = 3; }
                else if (input_row is "D") { indrow = 4; }
                else if (input_row is "E") { indrow = 5; }
                else if (input_row is "F") { indrow = 6; }
                else if (input_row is "G") { indrow = 7; }
                else if (input_row is "H") { indrow = 8; }
                else if (input_row is "I") { indrow = 9; }
                else if (input_row is "J") { indrow = 10; }
                else if (input_row is "K") { indrow = 11; }
                else if (input_row is "L") { indrow = 12; }
                else if (input_row is "M") { indrow = 13; }
                else if (input_row is "N") { indrow = 14; }
                var row = (screening_room.Count - indrow - 3);
                Console.WriteLine("Select a chair:");
                var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
                var your_line = screening_room[row];
                if (your_line[input_column] == 'O')
                {
                    Console.Clear();
                    Console.WriteLine($"You chose chair {input_column / 2 - 1} on row {indrow} , do you want to confirm this chair place?");
                    Console.WriteLine("Y/N");
                    string conf = Console.ReadLine();
                    conf.ToUpper();
                    if (conf == "Y")
                    {
                        your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");

                        screening_room[row] = your_line;
                        Console.Clear();
                        Console.WriteLine($"You have selected this chair {input_column / 2 - 1} on row {indrow}.");
                        Thread.Sleep(5000);
                        Console.Clear();
                        count++;
                        roomLogic.Update_list(screening_room, room);
                    }
                    else if (conf == "N")
                    {
                        Console.Clear();
                        Console.WriteLine($"You did not confirm chair {input_column / 2 - 1} on row {indrow}.");
                        Thread.Sleep(5000);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("This chair is not available, please select an empty chair.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }

        }
    }
}



//    public static void screening_room_medium()
//    {

//        List<string> screening_room = new List<string>
//                {"S |   O O O O O O O O O O O O O O O O   ",
//                 "R |   O O O O O O O O O O O O O O O O   ",
//                 "Q |   O O O O O O O O O O O O O O O O   ",
//                 "P |   O O O O O O O O O O O O O O O O   ",
//                 "O |   O O O O O O O O O O O O O O O O   ",
//                 "N |   O O O O O O O O O O O O O O O O   ",
//                 "M | O O O O O O O O O O O O O O O O O O ",
//                 "L | O O O O O O O O O O O O O O O O O O ",
//                 "K | O O O O O O O O O O O O O O O O O O ",
//                 "J | O O O O O O O O O O O O O O O O O O ",
//                 "I | O O O O O O O O O O O O O O O O O O ",
//                 "H |   O O O O O O O O O O O O O O O O   ",
//                 "G |   O O O O O O O O O O O O O O O O   ",
//                 "F |   O O O O O O O O O O O O O O O O   ",
//                 "E |     O O O O O O O O O O O O O O     ",
//                 "D |     O O O O O O O O O O O O O O     ",
//                 "C |     O O O O O O O O O O O O O O     ",
//                 "B |       O O O O O O O O O O O O       ",
//                 "A |       O O O O O O O O O O O O       ",
//                 "  x————————————————————————-------------",
//                 "    1 2 3 4 5 6 7 8 9 1 1 1 1 1 1 1 1 1 ",
//                 "                      0 1 2 3 4 5 6 7 8 "};

//        while (true)
//        {
//            foreach (var chair_row in screening_room)
//            {
//                for (int i = 0; i < chair_row.Length; i += 2)
//                {
//                    if (chair_row[i] == 'O')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                    }
//                    else if (chair_row[i] == 'X')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                    }
//                    else if (chair_row[i] == ' ')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    Console.Write(chair_row[i] + " ");
//                }
//                Console.WriteLine();
//            }
//            Console.WriteLine("How many chairs do you want to select?");
//            var num_chairs = Convert.ToInt32(Console.ReadLine());
//            int count = 0;
//            Console.Clear();
//            while (num_chairs > count)
//            {
//                foreach (var chair_row in screening_room)
//                {
//                    for (int i = 0; i < chair_row.Length; i += 2)
//                    {
//                        if (chair_row[i] == 'O')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Green;
//                        }
//                        else if (chair_row[i] == 'X')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Red;
//                        }
//                        else if (chair_row[i] == ' ')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Black;
//                        }
//                        else
//                        {
//                            Console.ForegroundColor = ConsoleColor.White;
//                        }
//                        Console.Write(chair_row[i] + " ");
//                    }
//                    Console.WriteLine();
//                }
//                Console.WriteLine("Select a row:");
//                var input_row = Console.ReadLine();
//                int indrow = 0;
//                if (input_row is "A") { indrow = 1; }
//                else if (input_row is "B") { indrow = 2; }
//                else if (input_row is "C") { indrow = 3; }
//                else if (input_row is "D") { indrow = 4; }
//                else if (input_row is "E") { indrow = 5; }
//                else if (input_row is "F") { indrow = 6; }
//                else if (input_row is "G") { indrow = 7; }
//                else if (input_row is "H") { indrow = 8; }
//                else if (input_row is "I") { indrow = 9; }
//                else if (input_row is "J") { indrow = 10; }
//                else if (input_row is "K") { indrow = 11; }
//                else if (input_row is "L") { indrow = 12; }
//                else if (input_row is "M") { indrow = 13; }
//                else if (input_row is "N") { indrow = 14; }
//                else if (input_row is "O") { indrow = 15; }
//                else if (input_row is "P") { indrow = 16; }
//                else if (input_row is "Q") { indrow = 17; }
//                else if (input_row is "R") { indrow = 18; }
//                else if (input_row is "S") { indrow = 19; }
//                var row = (screening_room.Count - indrow - 3);
//                Console.WriteLine("Select a chair:");
//                var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
//                var your_line = screening_room[row];
//                if (your_line[input_column] == 'O')
//                {
//                    Console.Clear();
//                    Console.WriteLine($"You chose chair {input_column / 2 - 1} on row {indrow} , do you want to confirm this chair place?");
//                    Console.WriteLine("Y/N");
//                    string conf = Console.ReadLine();
//                    conf.ToUpper();
//                    if (conf == "Y")
//                    {
//                        your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");

//                        screening_room[row] = your_line;
//                        Console.Clear();
//                        Console.WriteLine($"You have selected chair {input_column / 2 - 1} on row {indrow}.");
//                        Thread.Sleep(5000);
//                        Console.Clear();
//                        count++;
//                    }
//                    else if (conf == "N")
//                    {
//                        Console.Clear();
//                        Console.WriteLine($"You did not confirm chair {input_column / 2 - 1} on row {indrow}.");
//                        Thread.Sleep(5000);
//                        Console.Clear();
//                    }
//                }
//                else
//                {
//                    Console.Clear();
//                    Console.WriteLine("This chair is not available, please select an empty chair.");
//                    Thread.Sleep(3000);
//                    Console.Clear();
//                }
//            }
//        }
//    }

//    public static void screening_room_large()
//    {
//        List<string> screening_room = new List<string>
//                {"T |         O O O O O O O O O O O O O O O O O O O O O O         ",
//                 "S |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "R |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "Q |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "P |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "O |     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
//                 "N |   O O O O O O O O O O O O O O O O O O O O O O O O O O O O   ",
//                 "M | O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
//                 "L | O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
//                 "K | O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
//                 "J | O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
//                 "I | O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
//                 "H |   O O O O O O O O O O O O O O O O O O O O O O O O O O O O   ",
//                 "G |     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
//                 "F |     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
//                 "E |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "D |       O O O O O O O O O O O O O O O O O O O O O O O O       ",
//                 "C |           O O O O O O O O O O O O O O O O O O O O           ",
//                 "B |               O O O O O O O O O O O O O O O O               ",
//                 "A |                 O O O O O O O O O O O O O O O               ",
//                 "  x————————————————————————-------------------------------------",
//                 "    1 2 3 4 5 6 7 8 9 1 1 1 1 1 1 1 1 1 1 2 2 2 2 2 2 2 2 2 2 3 ",
//                 "                      0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 "};

//        while (true)
//        {
//            foreach (var chair_row in screening_room)
//            {
//                for (int i = 0; i < chair_row.Length; i += 2)
//                {
//                    if (chair_row[i] == 'O')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                    }
//                    else if (chair_row[i] == 'X')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                    }
//                    else if (chair_row[i] == ' ')
//                    {
//                        Console.ForegroundColor = ConsoleColor.Black;
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    Console.Write(chair_row[i] + " ");
//                }
//                Console.WriteLine();
//            }
//            Console.WriteLine("How many chairs do you want to select?");
//            var num_chairs = Convert.ToInt32(Console.ReadLine());
//            int count = 0;
//            Console.Clear();
//            while (num_chairs > count)
//            {
//                foreach (var chair_row in screening_room)
//                {
//                    for (int i = 0; i < chair_row.Length; i += 2)
//                    {
//                        if (chair_row[i] == 'O')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Green;
//                        }
//                        else if (chair_row[i] == 'X')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Red;
//                        }
//                        else if (chair_row[i] == ' ')
//                        {
//                            Console.ForegroundColor = ConsoleColor.Black;
//                        }
//                        else
//                        {
//                            Console.ForegroundColor = ConsoleColor.White;
//                        }
//                        Console.Write(chair_row[i] + " ");
//                    }
//                    Console.WriteLine();
//                }
//                Console.WriteLine("Select a row:");
//                var input_row = Console.ReadLine();
//                int indrow = 0;
//                if (input_row is "A") { indrow = 1; }
//                else if (input_row is "B") { indrow = 2; }
//                else if (input_row is "C") { indrow = 3; }
//                else if (input_row is "D") { indrow = 4; }
//                else if (input_row is "E") { indrow = 5; }
//                else if (input_row is "F") { indrow = 6; }
//                else if (input_row is "G") { indrow = 7; }
//                else if (input_row is "H") { indrow = 8; }
//                else if (input_row is "I") { indrow = 9; }
//                else if (input_row is "J") { indrow = 10; }
//                else if (input_row is "K") { indrow = 11; }
//                else if (input_row is "L") { indrow = 12; }
//                else if (input_row is "M") { indrow = 13; }
//                else if (input_row is "N") { indrow = 14; }
//                else if (input_row is "O") { indrow = 15; }
//                else if (input_row is "P") { indrow = 16; }
//                else if (input_row is "Q") { indrow = 17; }
//                else if (input_row is "R") { indrow = 18; }
//                else if (input_row is "S") { indrow = 19; }
//                else if (input_row is "T") { indrow = 20; }
//                var row = (screening_room.Count - indrow - 3);
//                Console.WriteLine("Select a chair:");
//                var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
//                var your_line = screening_room[row];
//                if (your_line[input_column] == 'O')
//                {
//                    Console.Clear();
//                    Console.WriteLine($"You chose chair {input_column / 2 - 1} on row {indrow} , do you want to confirm this chair place?");
//                    Console.WriteLine("Y/N");
//                    string conf = Console.ReadLine();
//                    conf.ToUpper();
//                    if (conf == "Y")
//                    {
//                        your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");

//                        screening_room[row] = your_line;
//                        Console.Clear();
//                        Console.WriteLine($"You have selected this chair {input_column / 2 - 1} on row {indrow}.");
//                        Thread.Sleep(5000);
//                        Console.Clear();
//                        count++;
//                    }
//                    else if (conf == "N")
//                    {
//                        Console.Clear();
//                        Console.WriteLine($"You did not confirm chair {input_column / 2 - 1} on row {indrow}.");
//                        Thread.Sleep(5000);
//                        Console.Clear();
//                    }
//                }
//                else
//                {
//                    Console.Clear();
//                    Console.WriteLine("This chair is not available, please select an empty chair.");
//                    Thread.Sleep(3000);
//                    Console.Clear();
//                }
//            }
//        }
//    }
//}