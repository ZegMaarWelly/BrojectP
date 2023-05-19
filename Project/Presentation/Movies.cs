using ConsoleTables;

static class Movies
{

    static private RunningMovieLogic runningmovieLogic = Factory.runningmovieLogic;
    static private AccountsLogic accountsLogic = Factory.accountsLogic;
    
    
    
    static public void Start()
    {
        Console.WriteLine("> Enter 1 to see the movies running today.");
        Console.WriteLine("> Enter 2 to see all the available movies.");

        var movie_input = Console.ReadLine()!;

        if(movie_input == "1")
        {
            DateTime currentDateTime = DateTime.Now;
            Select_Movie(currentDateTime);
            Start();
        }
        else if(movie_input == "2")
        {

        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Input");
            Start();

        }
    }
    static public void Select_Movie(DateTime your_date)
    {
        Console.Clear();

        //Gets the current date in a form of a string.
        
        string date = $"{your_date.Year}-{your_date.Month:00}-{your_date.Day:00}";

        //Gets all the running movies on a current date.
        while(true)
        {
            List<RunningMovieModel> running_movie_list = See_Movies_On_A_Date(date);
            Console.WriteLine("");
            Console.WriteLine("Type the number of the movie you want to pick");
            var movie_input = Convert.ToInt32(Console.ReadLine()!) - 1;

            RunningMovieModel running_movie_to_be_watched = running_movie_list[movie_input];
            Reservation.Make_Reservation(running_movie_to_be_watched);
            break;
        }

        

    }

    //See all the movies available on a date in a form of a  table, also returns the lists of running movies.
    static public List<RunningMovieModel> See_Movies_On_A_Date(string date)
    {
        //Opens a new runningmovieLogic with todays date.
        runningmovieLogic = new RunningMovieLogic(date);

        List<RunningMovieModel> running_movie_list = runningmovieLogic.Return_RunningMovie_List();
        Console.WriteLine($"Movies available on {date}");

        //Creates a new table.
        var table = new ConsoleTable("", "Movie", "Time", "Room", "Available Seats");
        //Loops through the running movie list, and add the contents to the table.
        foreach (RunningMovieModel runningmovie in running_movie_list)
        {
            string time = $"{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}";
            table.AddRow(running_movie_list.IndexOf(runningmovie) + 1, runningmovie.Movie.Name, time, runningmovie.Room.ID, runningmovie.Room.Available_Seats);
        }
        table.Options.EnableCount = false;

        Console.WriteLine(table);
        return running_movie_list;

    }
}