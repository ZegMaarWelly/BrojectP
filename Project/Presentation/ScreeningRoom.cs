
public class ScreeningRoom
{
    public static void Start()
    {
        screening_room_small();
    }
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
            foreach (var test in screening_room)
            {
                Console.WriteLine(test);
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

        while (true)
        {
            foreach (var test in screening_room)
            {
                Console.WriteLine(test);
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

        while (true)
        {
            foreach (var test in screening_room)
            {
                Console.WriteLine(test);
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