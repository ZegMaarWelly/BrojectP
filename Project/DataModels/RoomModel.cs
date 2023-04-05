using System.Text.Json.Serialization;
class RoomModel
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("map")]
    public List<string> Map { get; set; }

    [JsonPropertyName("total_seats")]
    public int Total_Seats{ get; set; }

    [JsonPropertyName("available_seats")]
    public int Available_Seats { get; set; }

    public RoomModel(int id, List<string> map, int total_seats, int available_seats)
    {
        ID = id;
        Map = map;
        Total_Seats = total_seats;
        Available_Seats = available_seats;
    }

    public override string ToString()
    {
        return $"ID: {ID}  MAP: {Map} Total Seats: {Total_Seats}  Available Seats: {Available_Seats}";
    }
}




