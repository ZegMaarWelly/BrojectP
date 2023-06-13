using System.Text.Json.Serialization;
public class RunningMovieModel
{
    [JsonPropertyName("movie")]
    public MovieListModel Movie { get; set; }

    [JsonPropertyName("room")]
    public RoomModel Room { get; set; }

    [JsonPropertyName("begin_time")]
    public DateTime Begin_Time { get; set; }

    [JsonPropertyName("end_time")]
    public DateTime End_Time { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }


    public RunningMovieModel(MovieListModel movie,RoomModel room, DateTime begin_time, DateTime end_time, DateTime date)
    {
        Movie = movie;
        Room = room;
        Begin_Time = begin_time;
        End_Time = end_time;
        Date = date;
    }

    public override string ToString()
    {
        return $"Movie: {Movie}\n Room {Room}\n Begin Time: {Begin_Time} \n End Time: {End_Time}";
    }


}




