
public class ScreeningRoom
{
    public static void Main()
    {
        screening_room_small();
    }
    public static void screening_room_small()
    {
        bool[] test = {false, true, true, true, true, true, true, true};
        List<bool> row = new List<bool>(test);
        string first_row_string = "##";
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (row[j] == true)
                {
                    first_row_string = first_row_string + "O";
                }
                else
                {
                    first_row_string = first_row_string + "X";
                }
            }
            first_row_string = first_row_string + "##";
            Console.WriteLine(first_row_string);
            first_row_string = "##";
        }
    }
}

