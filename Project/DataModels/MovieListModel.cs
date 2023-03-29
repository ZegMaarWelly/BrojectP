using System.Text.Json.Serialization;

class MovieListModel
    {
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

        public MovieListModel(string name, string genre, int length, int age, string labels)
        {
            Name = name;
            Genre = genre;
            Length = length;
            Age = age;
            Labels = labels;
        }

        // This is how the string for the movie will be displayed E.G. Name: (name of movie), Genre etc...
        public override string ToString()
        {
            return $"Name: {Name}, Genre(s): {Genre}, Length: {Length} minutes, Age: {Age} and above, Parental labels: {Labels}";
        }
    }