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

    public RoomModel(int id, List<string> map, int total, int available)
    {
        ID = id;
        Map = map;
        Total_Seats = total;
        Available_Seats = available;
    }

    public override string ToString()
    {
        return $"ID: {ID} \n {Map}\n Total Seats: {Total_Seats} \n Available Seats: {Available_Seats}";
    }
}




