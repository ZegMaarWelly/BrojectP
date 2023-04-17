using System.Text.Json;

static class RunningMovieAccess
{




    public static List<RunningMovieModel> LoadAll(string name)
    {
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, $@"DataSources/dates/{name}.json"));

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<RunningMovieModel>>(json);
        }
        else
        {
            CreateJsonFile(path);

            // Return an empty list
            return new List<RunningMovieModel>();
        }
    }


    public static void WriteAll(List<RunningMovieModel> snacks, string name)
    {
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, $@"DataSources/{name}.json"));
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(snacks, options);
        File.WriteAllText(path, json);
    }
    public static void CreateJsonFile(string filePath)
    {
        // Create an empty list of runningmovieModel objects
        var runningmovies = new List<RunningMovieModel>();

        // Serialize the empty list to JSON
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(runningmovies, options);

        // Write the JSON to a file, overwriting any existing content
        File.WriteAllText(filePath, json);
    }




}