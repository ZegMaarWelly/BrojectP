using System.Text.Json.Serialization;

class MovieListModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genre")]
        public double Genre { get; set; }

        [JsonPropertyName("length")]
        public string Length { get; set; }

        [JsonPropertyName("age")]
        public string Age { get; set; }

        [JsonPropertyName("labels")]
        public string Labels { get; set; }

        public MovieListModel(string name, string genre, int length, int age, string labels)
        {
            Name = name;
            Genre = genre;
            Length = length;
            Labels = labels;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Genre: {Genre}, Length: {Length}, Labels: {Labels}";
        }
    }