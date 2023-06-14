namespace UnitTesting
{

   

    [TestClass]
    public class MovieListLogicTests
    {
        private MovieListLogic _movieListLogic = new();

        
        

        [TestMethod]
        public void Return_By_Genre_Successful()
        {
            string genre = "Action";
            List<MovieListModel> movies = _movieListLogic.Return_By_Genre(genre);

           
            foreach(var movie in movies)
            {
                Assert.IsTrue(movie.Genre.Contains(genre));
            }
        }

        [TestMethod]
        public void Add_To_List_Successful()
        {
            MovieListModel movie = new MovieListModel(55, "Test Movie", "Action", 120, 12, "PG-13","sum");
            int initialCount = _movieListLogic.Return_Movie_List().Count;

            _movieListLogic.Add_To_List(movie);

            Assert.AreEqual(initialCount + 1, _movieListLogic.Return_Movie_List().Count);
        }

        [TestMethod]
        public void Z_Delete_From_List_Should_Remove_Movie_From_List()
        {
            int initialCount = _movieListLogic.Return_Movie_List().Count;

            MovieListModel movie = _movieListLogic.Return_Movie_List()[initialCount-1];

            _movieListLogic.Delete_From_List(movie);

            Assert.AreEqual(initialCount - 1, _movieListLogic.Return_Movie_List().Count);
        }

        [TestMethod]
        public void Find_Movie_Name_Successful()
        {
            string movieName = "Test Movie";
            MovieListModel movie = _movieListLogic.Find_Movie(movieName);

            Assert.AreEqual(movie.Name, movieName);
        }

        [TestMethod]
        public void Find_Movie_ID_Successful()
        {
            int movieId = 1;
            MovieListModel movie = _movieListLogic.Find_Movie(movieId);

            Assert.AreEqual(movie.Id,movieId);
        }

        [TestMethod]
        public void Update_Movie_Name_Successful()
        {
            
            string newValue = "New Movie Name";
            MovieListModel movie = _movieListLogic.Find_Movie(55);

            // Act
            _movieListLogic.Update_Movie_Name(newValue, movie);

            // Assert
            MovieListModel updatedMovie = _movieListLogic.Find_Movie(movie.Id);
            Assert.AreEqual(newValue, updatedMovie.Name);
        }

        [TestMethod]
        public void Update_Movie_Genre_Successful()
        {
            
            string newValue = "New Genre";
            MovieListModel movie = _movieListLogic.Find_Movie(55);

            _movieListLogic.Update_Movie_Genre(newValue, movie);

      
            MovieListModel updatedMovie = _movieListLogic.Find_Movie(movie.Id);
            Assert.AreEqual(newValue, updatedMovie.Genre);
        }

        [TestMethod]
        public void Update_Movie_Length_Successful()
        {
            
            int newValue = 150;
            MovieListModel movie = _movieListLogic.Find_Movie(55);
   

            _movieListLogic.Update_Movie_Length(newValue, movie);


            MovieListModel updatedMovie = _movieListLogic.Find_Movie(movie.Id);
            Assert.AreEqual(newValue, updatedMovie.Length);
        }

        [TestMethod]
        public void Update_Movie_Age_Should_Update_Movie_Age()
        {
           
            int newValue = 16;
            MovieListModel movie = _movieListLogic.Find_Movie(55);

         
            _movieListLogic.Update_Movie_Age(newValue, movie);

      
            MovieListModel updatedMovie = _movieListLogic.Find_Movie(movie.Id);
            Assert.AreEqual(newValue, updatedMovie.Age);
        }

        [TestMethod]
        public void Update_Movie_Labels_Successful()
        {
           
            string newValue = "New Labels";
            MovieListModel movie = _movieListLogic.Find_Movie(55);

       
            _movieListLogic.Update_Movie_Labels(newValue, movie);

            MovieListModel updatedMovie = _movieListLogic.Find_Movie(movie.Id);
            Assert.AreEqual(newValue, updatedMovie.Labels);
        }

    }

}