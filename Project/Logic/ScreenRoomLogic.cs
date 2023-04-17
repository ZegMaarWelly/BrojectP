using System.Runtime.CompilerServices;

class ScreenRoomLogic
{

    public static void screening_room_small()
    {
        List<string> screening_room = new List<string>
            {"14|     O O O O O O O O    ",
             "13|   O O O O O O O O O O  ",
             "12|   O O O O O O O O O O  ",
             "11| O O O O O O O O O O O O",
             "10| O O O O O O O O O O O O",
             "09| O O O O O O O O O O O O",
             "08| O O O O O O O O O O O O",
             "07| O O O O O O O O O O O O",
             "06| O O O O O O O O O O O O",
             "05| O O O O O O O O O O O O",
             "04| O O O O O O O O O O O O",
             "03|   O O O O O O O O O O  ",
             "02|     O O O O O O O O    ",
             "01|     O O O O O O O O    ",
             "  x————————————————————————",
             "    1 2 3 4 5 6 7 8 9 1 1 1",
             "                      0 1 2"};

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
            Console.WriteLine("Selecteer een rij:");
            var input_row = Convert.ToInt32(Console.ReadLine());
            var row = (screening_room.Count - input_row - 3);
            Console.WriteLine("Selecteer een stoel:");
            var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
            var your_line = screening_room[row];
            if (your_line[input_column] == 'O')
            {

                your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");

                screening_room[row] = your_line;
                Console.Clear();
                Console.WriteLine($"U heeft stoel {input_column / 2 - 1} op rij {input_row} geselecteerd, wilt u deze stoel reserveren?");
                Thread.Sleep(3000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Deze stoel is niet beschikbaar, kies alstublieft een beschikbare stoel");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }
    }



    public static void screening_room_medium()
    {
        bool cont = true;
        List<string> screening_room = new List<string>
                {"19|   O O O O O O O O O O O O O O O O   ",
                 "18|   O O O O O O O O O O O O O O O O   ",
                 "17|   O O O O O O O O O O O O O O O O   ",
                 "16|   O O O O O O O O O O O O O O O O   ",
                 "15|   O O O O O O O O O O O O O O O O   ",
                 "14|   O O O O O O O O O O O O O O O O   ",
                 "13| O O O O O O O O O O O O O O O O O O ",
                 "12| O O O O O O O O O O O O O O O O O O ",
                 "11| O O O O O O O O O O O O O O O O O O ",
                 "10| O O O O O O O O O O O O O O O O O O ",
                 "09| O O O O O O O O O O O O O O O O O O ",
                 "08|   O O O O O O O O O O O O O O O O   ",
                 "07|   O O O O O O O O O O O O O O O O   ",
                 "06|   O O O O O O O O O O O O O O O O   ",
                 "05|     O O O O O O O O O O O O O O     ",
                 "04|     O O O O O O O O O O O O O O     ",
                 "03|     O O O O O O O O O O O O O O     ",
                 "02|       O O O O O O O O O O O O       ",
                 "01|       O O O O O O O O O O O O       ",
                 "  x————————————————————————-------------",
                 "    1 2 3 4 5 6 7 8 9 1 1 1 1 1 1 1 1 1 ",
                 "                      0 1 2 3 4 5 6 7 8 "};

        while (cont == true)
        {
            foreach (var chair_row in screening_room)
            {
                for (int i = 0; i < chair_row.Length; i += 2) // increment by 2 to skip spaces between chairs
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
                    Console.Write(chair_row[i] + " "); // print each chair with a space between them
                }
                Console.WriteLine(); // move to the next row
            }
            Console.WriteLine("Selecteer een rij:");
            var input_row = Convert.ToInt32(Console.ReadLine());
            var row = (screening_room.Count - input_row - 3);
            Console.WriteLine("Selecteer een stoel:");
            var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
            var your_line = screening_room[row];
            if (your_line[input_column] == Convert.ToChar("O"))
            {
                your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");
                screening_room[row] = your_line;
                Console.Clear();
                Console.WriteLine($"U heeft stoel {input_column / 2 - 1} op rij {input_row} geselecteerd, wilt u deze stoel reserveren?");
                Thread.Sleep(3000);
                cont = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Deze stoel is niet beschikbaar, kies alstublieft een beschikbare stoel");
                Thread.Sleep(3000);
                Console.Clear();
            }

        }
    }

    public static void screening_room_large()
    {
        bool cont = true;
        List<string> screening_room = new List<string>
                {"20|         O O O O O O O O O O O O O O O O O O O O O O         ",
                 "19|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "18|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "17|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "16|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "15|     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
                 "14|   O O O O O O O O O O O O O O O O O O O O O O O O O O O O   ",
                 "13| O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
                 "12| O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
                 "11| O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
                 "10| O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
                 "09| O O O O O O O O O O O O O O O O O O O O O O O O O O O O O O ",
                 "08|   O O O O O O O O O O O O O O O O O O O O O O O O O O O O   ",
                 "07|     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
                 "06|     O O O O O O O O O O O O O O O O O O O O O O O O O O     ",
                 "05|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "04|       O O O O O O O O O O O O O O O O O O O O O O O O       ",
                 "03|           O O O O O O O O O O O O O O O O O O O O           ",
                 "02|               O O O O O O O O O O O O O O O O               ",
                 "01|                 O O O O O O O O O O O O O O O               ",
                 "  x————————————————————————-------------------------------------",
                 "    1 2 3 4 5 6 7 8 9 1 1 1 1 1 1 1 1 1 1 2 2 2 2 2 2 2 2 2 2 3 ",
                 "                      0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 "};

        while (cont == true)
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
            Console.WriteLine("Selecteer een rij:");
            var input_row = Convert.ToInt32(Console.ReadLine());
            var row = (screening_room.Count - input_row - 3);
            Console.WriteLine("Selecteer een stoel:");
            var input_column = (Convert.ToInt32(Console.ReadLine()) - 1) * 2 + 4;
            var your_line = screening_room[row];
            if (your_line[input_column] == Convert.ToChar("O"))
            {
                your_line = your_line.Remove(input_column, 1).Insert(input_column, "X");
                screening_room[row] = your_line;
                Console.Clear();
                Console.WriteLine($"U heeft stoel {input_column / 2 - 1} op rij {input_row} geselecteerd, wilt u deze stoel reserveren?");
                Thread.Sleep(3000);
                cont = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Deze stoel is niet beschikbaar, kies alstublieft een beschikbare stoel");
                Thread.Sleep(3000);
                Console.Clear();
            }

        }
    }
}