using System.Text.Json;

static class ReservationAccess
{




    public static List<ReservationModel> LoadAll(string name)
    {
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, $@"DataSources/reservations/{name}.json"));

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<ReservationModel>>(json);
        }
        else
        {
            CreateJsonFile(path);

            // Return an empty list
            return new List<ReservationModel>();
        }
    }


    public static void WriteAll(List<ReservationModel> snacks, string name)
    {
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, $@"DataSources/reservations/{name}.json"));
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(snacks, options);
        File.WriteAllText(path, json);
    }
    public static void CreateJsonFile(string filePath)
    {
        // Create an empty list of runningmovieModel objects
        var runningmovies = new List<ReservationModel>();

        // Serialize the empty list to JSON
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(runningmovies, options);

        // Write the JSON to a file, overwriting any existing content
        File.WriteAllText(filePath, json);
    }




}