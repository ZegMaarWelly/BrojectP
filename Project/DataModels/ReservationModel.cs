using System.Text.Json.Serialization;
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



}




