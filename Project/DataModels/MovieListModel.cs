using System.Text.Json.Serialization;

public class MovieListModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("length")]
        public int Length { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("labels")]
        public string Labels { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }


    public MovieListModel(int id, string name, string genre, int length, int age, string labels, string summary)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Length = length;
            Age = age;
            Labels = labels;
            Summary = summary;
        }

        // This is how the string for the movie will be displayed E.G. Name: (name of movie), Genre etc...
        public override string ToString()
        {
         return $"ID: {Id}, Name: {Name}, Genre(s): {Genre}, Length: {Length} minutes, Age: {Age} and above, Parental labels: {Labels}";
        }
    }