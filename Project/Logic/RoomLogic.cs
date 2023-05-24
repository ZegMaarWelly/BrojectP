class RoomLogic
{
    private List<RoomModel> _rooms;


    public RoomLogic()
    {
        _rooms = RoomAccess.LoadAll();
    }

    public List<RoomModel> Return_Room_List()
    {
        return _rooms;
    }

    public void Add_To_List(RoomModel room)
    {
        _rooms.Add(room);
        RoomAccess.WriteAll(_rooms);
    }

    public RoomModel Find_Room(int id)
    {
        foreach (RoomModel room in _rooms)
        {
            if (room.ID == id)
            {
                return room;
            }
        }
        return null;
    }

    public void Update_list(List<string> scr_room,RoomModel room)
    {
        room.Map = scr_room;
        int roomindex = _rooms.IndexOf(room);
        _rooms[roomindex] = room;
        RoomAccess.WriteAll(_rooms);
    }

    public int Avalaibleseats(RoomModel room)
    {
        int seats = room.Available_Seats;
        return seats;
    }

    // makes a new room for the amdin
    public void Add_Room(int row, int column)
    {
        List<string> alphabet_String = new List<string> { "Z", "Y", "X", "W", "V", "U", "T", "S", "R", "Q", "P", "O", "N", "M", "L", "K", "J", "I", "H", "G", "F", "E", "D", "C", "B", "A" };

        int total_available = row * column;

        List<string> room = new();
        string row_string = "";
        for (int i = 0; i < row; i++)
        {
            row_string = row_string + " O";
        }

        int lastIndex = alphabet_String.Count - 1;
        int rangeStartIndex = lastIndex - column + 1;

        List<string> alphabet_for_the_list = alphabet_String.GetRange(rangeStartIndex, column);

        for (int j = 0; j < column; j++)
        {
            room.Add($"{alphabet_for_the_list[j]} |{row_string}");
        }

        string line = "   x";
        for (int i = 0; i < row; i++)
        {
            line = line + "--";
        }
        room.Add(line);

        string first_row_of_numbers = "    ";
        string second_row_of_numbers = "    ";
        for (int i = 0; i < row; i++)
        {
            string row_string2 = Convert.ToString(i + 1);
            if (i < 9)
            {
                first_row_of_numbers = first_row_of_numbers + "  ";
                second_row_of_numbers = second_row_of_numbers + $" {row_string2[0]}";
            }

            else
            {
                first_row_of_numbers = first_row_of_numbers + $" {row_string2[0]}";
                second_row_of_numbers = second_row_of_numbers + $" {row_string2[1]}";
            }

        }
        room.Add(first_row_of_numbers);
        room.Add(second_row_of_numbers);


       
        int id = Find_Next_ID();
        RoomModel real_room = new(id, room, total_available, total_available);
        Add_To_List(real_room);

    }
    public static int Find_Next_ID()
    {
        return RoomAccess.LoadAll().Select(a => a.ID).Max() + 1;
    }

}
