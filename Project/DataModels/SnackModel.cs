using System.Text.Json.Serialization;
class SnackModel
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("name")]
    public string  Name { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("type_of_food")]
    public string Type_Of_Food { get; set; }

    [JsonPropertyName("allergies")]
    public string Allergies { get; set; }

    public  SnackModel(int id, string name, double price, string type_of_food, string allergies)
    {
        ID = id;
        Name = name;
        Price = price;
        Type_Of_Food = type_of_food;
        Allergies = allergies;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Price: {Price}, Type of Food: {Type_Of_Food}, Allergies: {Allergies}";
    }
}




