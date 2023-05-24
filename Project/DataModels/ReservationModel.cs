﻿using System.Text.Json.Serialization;
using System.Xml.Linq;

class ReservationModel
{
    [JsonPropertyName("running_movie")]
    public RunningMovieModel Running_Movie { get; set; }

    [JsonPropertyName("account")]
    public AccountModel Account { get; set; }

    [JsonPropertyName("seats")]
    public List<string> Seats { get; set; }

    [JsonPropertyName("snacks")]
    public List<CountedSnackModel> Snacks { get; set; }



    public ReservationModel(RunningMovieModel running_movie, AccountModel account, List<string> seats, List<CountedSnackModel> snacks)
    {
        Running_Movie = running_movie;
        Account = account;
        Seats = seats;
        Snacks = snacks;
    }


    public int Calculate(string my_string)
    {
        int totalLength = 40;
        int remainingSpace = totalLength - my_string.Length - 2; // Subtracting 2 for the border characters "| "
        int padding = remainingSpace / 2;
        return padding;
    }
    public override string ToString()
    {



        //string[] names = { "John Doe", "Jane Smith", "Michael DHDGRDDFGFDGFAFGGRDDGGDDSFDFCVB D GJohnson" };
        //int totalLength = 40;

        //foreach (string name in names)
        //{
        //    int remainingSpace = totalLength - name.Length - 2; // Subtracting 2 for the border characters "| "
        //    int padding = remainingSpace / 2;

        //    string formattedString = $"| {name.PadLeft(padding + name.Length).PadRight(totalLength - 1)} |";
        //    Console.WriteLine(formattedString);
        //}
        int totalLength = 40;
        int padding = 0;

        string snackstring =  $"|      |---------------------------|      |\n";
        foreach(var snack in Snacks)
        {
            snackstring += $"| {(snack.Quantity + "X  "+ snack.Snack.Name  ).PadLeft(Calculate((snack.Quantity + "X  " + snack.Snack.Name)) + (snack.Quantity + "X  " + snack.Snack.Name).Length).PadRight(totalLength - 1)} |\n";
        }




        return

            $"|-----------------------------------------|\n" +
            $"|                                         |\n" +
            $"| {"High Cinema Rotterdam".PadLeft(Calculate("High Cinema Rotterdam") + "High Cinema Rotterdam".Length).PadRight(totalLength - 1)} |\n" +
            $"| {"Rotterdam Wijnhaven 107".PadLeft(Calculate("Rotterdam Wijnhaven 107") + "Rotterdam Wijnhaven 107".Length).PadRight(totalLength - 1)} |\n" +
            $"|-----------------------------------------|\n" +
            $"|                                         |\n" +
            $"|                                         |\n" +
            $"| {Running_Movie.Movie.Name.PadLeft(Calculate(Running_Movie.Movie.Name) + Running_Movie.Movie.Name.Length).PadRight(totalLength - 1)} |\n" +
            $"|                                         |\n" +
            $"| {("Room: " + Running_Movie.Room.ID).PadLeft(Calculate(("Room: " + Running_Movie.Room.ID)) + ("Room: " + Running_Movie.Room.ID).Length).PadRight(totalLength - 1)} |\n" +
            $"| {string.Join(", ", Seats).PadLeft(Calculate(string.Join(", ", Seats)) + string.Join(", ", Seats).Length).PadRight(totalLength - 1)} |\n" +
            $"|                                         |\n" +
            $"{snackstring}" +
            $"|-----------------------------------------|\n " +
            $"\n\n\n\n\n\n";
    }

}




