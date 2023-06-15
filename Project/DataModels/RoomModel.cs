using System.Text.Json.Serialization;
public class RoomModel
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("map")]
    public List<string> Map { get; set; }

    [JsonPropertyName("total_seats")]
    public int Total_Seats{ get; set; }

    [JsonPropertyName("available_seats")]
    public int Available_Seats { get; set; }
    [JsonPropertyName("price_per_seat")]
    public double Price_Per_Seat { get; set; }

    public RoomModel(int id, List<string> map, int total_seats, int available_seats, double price_per_seat)
    {
        ID = id;
        Map = map;
        Total_Seats = total_seats;
        Available_Seats = available_seats;
        Price_Per_Seat = price_per_seat;
    }

    public override string ToString()
    {
        return $"ID: {ID} \n  MAP: {Map} \n Total Seats: {Total_Seats} \n Available Seats: {Available_Seats}";
        //return $"ID: {ID} ";
    }

    
}




