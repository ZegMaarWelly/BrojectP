using Newtonsoft.Json;
using System.Text.Json;


static class MovieListAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/movielist.json"));


    public static List<MovieListModel> LoadAll()
    {
        //    string json = File.ReadAllText(path);
        //    return JsonSerializer.Deserialize<List<MovieListModel>>(json);
        string json = File.ReadAllText(path);
        List<MovieListModel> movies = JsonConvert.DeserializeObject<List<MovieListModel>>(json);
        return movies;
    }


    public static void WriteAll(List<MovieListModel> movies)
    {
        //var options = new JsonSerializerOptions { WriteIndented = true };
        //string json = JsonSerializer.Serialize(movies, options);
        //File.WriteAllText(path, json);
        string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}