using System.Text.Json.Serialization;
class SnackModel
{
    [JsonPropertyName("name")]
    public string  Name { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("type_of_food")]
    public string Type_Of_Food { get; set; }

    [JsonPropertyName("allergies")]
    public string Allergies { get; set; }

    public  SnackModel(string name, double price, string type_of_food, string allergies)
    {
        Name = name;
        Price = price;
        Type_Of_Food = type_of_food;
        Allergies = allergies;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Type of Food: {Type_Of_Food}, Allergies: {Allergies}";
    }
}




