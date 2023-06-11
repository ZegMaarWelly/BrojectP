
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTesting
{
   
    
    [TestClass]
    public class RunningMovieLogicTests
    {
        private RunningMovieLogic _runningMovieLogic = new("2024-06-10");
        private MovieListLogic _movielistLogic = new();
        private RoomLogic _roomLogic = new();
        private DateTime date = new DateTime(2024, 06, 10);
        

       

        [TestMethod]
        //Adds a running movie to the list and checks if the list has increased in size.
        public void Add_To_List_Successful()
        {
            MovieListModel movie = _movielistLogic.Return_Movie_List()[1];
            RoomModel room = _roomLogic.Return_Room_List()[1];
            DateTime begintime = date.AddMinutes(600);
            RunningMovieModel newRunningMovie = new(movie, room,begintime,begintime.AddMinutes(movie.Length), date);
            int initialCount = _runningMovieLogic.Return_RunningMovie_List().Count;


            _runningMovieLogic.Add_To_List(newRunningMovie);


            Assert.AreEqual(initialCount + 1, _runningMovieLogic.Return_RunningMovie_List().Count);
        }

        [TestMethod]
        //Deletes a running movie from the list and checks if the list has decreased in size.
        public void Z_Delete_From_List_Successful()
        {
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeDeleted = runningMovieList[runningMovieList.Count - 1];
            int initialCount = runningMovieList.Count;

            _runningMovieLogic.Delete_From_List(movieToBeDeleted);

            Assert.AreEqual(initialCount - 1 , _runningMovieLogic.Return_RunningMovie_List().Count);


        }

        [TestMethod]

        //Changes the movie of the running movie and checks if the movie has indeed changed.
        public void Change_Movie_Successful()
        {

            MovieListModel newMovie = _movielistLogic.Return_Movie_List()[5];
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged= runningMovieList[runningMovieList.Count - 1];


            _runningMovieLogic.Change_Movie(newMovie, movieToBeChanged);

            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];
           
            Assert.AreEqual(newMovie,movieIsChanged.Movie);
        }

        [TestMethod]

        //Changes the room  of the running movie and checks if the room has indeed changed.
        public void Change_Room_Successful()
        {

            RoomModel newRoom = _roomLogic.Return_Room_List()[5];
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged = runningMovieList[runningMovieList.Count - 1];


            _runningMovieLogic.Change_Room(newRoom, movieToBeChanged);

            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];

            Assert.AreEqual(newRoom, movieIsChanged.Room);
        }

        [TestMethod]

        //Changes the date of the running movie and checks if the date has indeed changed.
        public void Change_Date_Successful()
        {

            DateTime newDate = DateTime.Now;
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged = runningMovieList[runningMovieList.Count - 1];


            _runningMovieLogic.Change_Date(newDate, movieToBeChanged);

            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];

            Assert.AreEqual(newDate, movieIsChanged.Date);
        }

        [TestMethod]

        //Changes the begin time of the running movie and checks if the begin time has indeed changed.
        public void Change_Begin_Time_Successful()
        {

            DateTime newBeginTime = DateTime.Now.AddMinutes(666);
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged = runningMovieList[runningMovieList.Count - 1];


            _runningMovieLogic.Change_Begin_Time(newBeginTime, movieToBeChanged);

            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];

            Assert.AreEqual(newBeginTime, movieIsChanged.Begin_Time);
        }

        [TestMethod]

        //Changes the begin time of the running movie and checks if the begin time has indeed changed.
        public void Change_End_Time_Successful()
        {

            DateTime newEndTime = DateTime.Now.AddMinutes(766);
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged = runningMovieList[runningMovieList.Count - 1];


            _runningMovieLogic.Change_End_Time(newEndTime, movieToBeChanged);

            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];

            Assert.AreEqual(newEndTime, movieIsChanged.End_Time);
        }

        [TestMethod]

        //Checks if the Populate function adds a running movie to the running movie list.
        public void Populate_Successful()
        {
            
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            int initialCount = runningMovieList.Count;

            _runningMovieLogic.Populate(date);

            Assert.AreEqual(initialCount + 1, _runningMovieLogic.Return_RunningMovie_List().Count);

        }


        [TestMethod]

        //Changes the running movie from the Roomid, Movie and start date and checks wether the running movie has changed.
        public void Change_Running_Movie_From_RoomIDMovieStarDate_Successful()
        {
            List<RunningMovieModel> runningMovieList = _runningMovieLogic.Return_RunningMovie_List();
            RunningMovieModel movieToBeChanged= runningMovieList[runningMovieList.Count - 1];
            movieToBeChanged.Room.Available_Seats = 0; 
 

            _runningMovieLogic.Change_Running_Movie_From_RoomIDMovieStarDate(movieToBeChanged);
            RunningMovieModel movieIsChanged = runningMovieList[runningMovieList.Count - 1];

            Assert.AreEqual(movieToBeChanged, movieIsChanged);
        }


    }
}