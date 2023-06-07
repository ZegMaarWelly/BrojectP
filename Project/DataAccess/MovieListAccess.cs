using Newtonsoft.Json;

static class MovieListAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/movielist.json"));

    public static List<MovieListModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        List<MovieListModel> movies = JsonConvert.DeserializeObject<List<MovieListModel>>(json);
        return movies;
    }

    public static void WriteAll(List<MovieListModel> movies)
    {
        string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}