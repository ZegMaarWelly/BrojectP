
using System.Data;
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
            else if (input_row is "O") { indrow = 15; }
            else if (input_row is "P") { indrow = 16; }
            else if (input_row is "Q") { indrow = 17; }
            else if (input_row is "R") { indrow = 18; }
            else if (input_row is "S") { indrow = 19; }
            else if (input_row is "T") { indrow = 20; }
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
                else if (input_row is "O") { indrow = 15; }
                else if (input_row is "P") { indrow = 16; }
                else if (input_row is "Q") { indrow = 17; }
                else if (input_row is "R") { indrow = 18; }
                else if (input_row is "S") { indrow = 19; }
                else if (input_row is "T") { indrow = 20; }
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


    //make a new room for the admin.
    public static void AddRoom()
    {
        //takes the inputs for the room
        RoomLogic addRoom = new RoomLogic();
        int room_ID = Find_Next_ID();
        int rows = 0;
        int chairs = 0;
        bool switch1 = true;
        while (switch1 == true)
        {
            if (rows <= 0 || rows > 20)
            { 
                Console.WriteLine("How many rows would you like to have in the room. (max 20)");
                rows = Convert.ToInt32(Console.ReadLine());
                
            }
            if (chairs <= 0 || chairs > 30)
            {
                Console.WriteLine("How many chairs would you like per row? (Max 30)");
                chairs = Convert.ToInt32(Console.ReadLine());
            }
            if (rows > 0 && rows <=30 && chairs > 0 && chairs <= 30) 
            { 
                switch1 = false;
            }
        Console.WriteLine("Your measurements for the room are not available.");
        }
        
        int available_Seats = rows * chairs;
        rows += 1;
        chairs += 1;
        //initialized the room
        char[][] roomLayout = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            roomLayout[i] = new char[chairs];
            for (int j = 0; j < chairs; j++)
            {
                roomLayout[i][j] = 'O';
            }
        }

        // Fill in the top and bottom borders
        roomLayout = AddBorder(roomLayout, chairs);

        // Fill in the row labels
        roomLayout = AddRowLabels(roomLayout, rows);
        
        // Fill in the column labels
        roomLayout = AddColumnLabels(roomLayout, chairs);

        // Convert the room layout to string representation
        List<string> roomList = new List<string>();
        for (int i = 0; i < roomLayout.Length; i++)
        {
            string rowLabel = roomLayout[i][0].ToString();
            string rowContent = string.Join(" ", roomLayout[i].Skip(1));
            string row = $"{rowLabel} | {rowContent}";
            roomList.Add(row);
        }


        RoomModel room = new RoomModel(room_ID, roomList, available_Seats, available_Seats);

        addRoom.Add_To_List(room);

    }
    private static char[][] AddBorder(char[][] roomLayout, int chairs)
    {
        char[] borderRow = new char[chairs + 2];
        Array.Fill(borderRow, ' ');

        roomLayout = InsertRowAtTop(roomLayout, borderRow);
        roomLayout = InsertRowAtBottom(roomLayout, borderRow);

        return roomLayout;
    }

    private static char[][] AddRowLabels(char[][] roomLayout, int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            roomLayout[i + 1][0] = (char)(65 + i);
        }

        return roomLayout;
    }

    private static char[][] AddColumnLabels(char[][] roomLayout, int chairs)
    {
        char[] colLabelsRow = new char[chairs + 2];
        colLabelsRow[0] = ' ';
        colLabelsRow[chairs + 1] = ' ';

        for (int i = 1; i <= chairs; i++)
        {
            string label = i.ToString("D2");
            colLabelsRow[i] = label[0];
            colLabelsRow[i + 1] = label[1];
        }

        roomLayout[roomLayout.Length - 2] = colLabelsRow;

        return roomLayout;
    }

    private static char[][] InsertRowAtTop(char[][] roomLayout, char[] row)
    {
        char[][] newLayout = new char[roomLayout.Length + 1][];
        Array.Copy(roomLayout, 0, newLayout, 1, roomLayout.Length);
        newLayout[0] = row;
        return newLayout;
    }

    private static char[][] InsertRowAtBottom(char[][] roomLayout, char[] row)
    {
        char[][] newLayout = new char[roomLayout.Length + 1][];
        Array.Copy(roomLayout, newLayout, roomLayout.Length);
        newLayout[newLayout.Length - 1] = row;

        return newLayout;
        
    }


    // get the the highest ID in the json file and add 1 more
    public static int Find_Next_ID()
    {
        return RoomAccess.LoadAll().Select(a => a.ID).Max() + 1;
    }
}



