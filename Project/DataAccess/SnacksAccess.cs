using System.Text.Json;

static class SnacksAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/snacks.json"));


    public static List<SnackModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<SnackModel>>(json);
    }


    public static void WriteAll(List<SnackModel> snacks)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(snacks, options);
        File.WriteAllText(path, json);
    }



}