
public class ScreeningRoom
{
    public static void screening_room_small()
    {
        bool[] test = { true, true, true, true, true, true, true, true};
        List<bool> row = new List<bool>(test);
        string row_start = "##";
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (row[i] = true)
                {
                    string row_string = row_string + "O";
                    Console.WriteLine(row_string);
                }
            }
        }
            
        


    }
}

