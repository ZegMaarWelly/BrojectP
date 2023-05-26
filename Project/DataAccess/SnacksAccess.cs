using Newtonsoft.Json;

static class SnacksAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/snacks.json"));


    public static List<SnackModel> LoadAll()
    {
        //string json = File.ReadAllText(path);
        //return JsonSerializer.Deserialize<List<SnackModel>>(json);
        string json = File.ReadAllText(path);
        List<SnackModel> snacks = JsonConvert.DeserializeObject<List<SnackModel>>(json);
        return snacks;
    }


    public static void WriteAll(List<SnackModel> snacks)
    {
        //var options = new JsonSerializerOptions { WriteIndented = true };
        //string json = JsonSerializer.Serialize(snacks, options);
        //File.WriteAllText(path, json);
        string json = JsonConvert.SerializeObject(snacks, Formatting.Indented);
        File.WriteAllText(path, json);
    }



}