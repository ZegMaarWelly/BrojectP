using ConsoleTables;

static class Movies
{

    static private RunningMovieLogic runningmovieLogic = Factory.runningmovieLogic;
    static private AccountsLogic accountsLogic = Factory.accountsLogic;
    
    
    
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  __  __         _       ___                          _   _          \r\n |  \\/  |_____ _(_)___  | _ \\___ ___ ___ _ ___ ____ _| |_(_)___ _ _  \r\n | |\\/| / _ \\ V / / -_) |   / -_|_-</ -_) '_\\ V / _` |  _| / _ \\ ' \\ \r\n |_|  |_\\___/\\_/|_\\___| |_|_\\___/__/\\___|_|  \\_/\\__,_|\\__|_\\___/_||_|\r\n                                                                     ");
        Console.ResetColor();
        Console.WriteLine(" > Enter [1] to see the movies running today.");
        Console.WriteLine(" > Enter [2] to see all the available movies.");
        Console.WriteLine(" > Enter [3] to go back to menu");
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
        else if (movie_input == "2")
        {
            Console.Clear();

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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  __  __         _       ___                          _   _          \r\n |  \\/  |_____ _(_)___  | _ \\___ ___ ___ _ ___ ____ _| |_(_)___ _ _  \r\n | |\\/| / _ \\ V / / -_) |   / -_|_-</ -_) '_\\ V / _` |  _| / _ \\ ' \\ \r\n |_|  |_\\___/\\_/|_\\___| |_|_\\___/__/\\___|_|  \\_/\\__,_|\\__|_\\___/_||_|\r\n                                                                     ");
            Console.ResetColor();
            List<RunningMovieModel> running_movie_list = See_Movies_On_A_Date(date);
            Console.WriteLine("");

            // Asks the user for the number of their movie.
            int movie_input = -1;
            bool movie_success = false;
            while (!movie_success)
            {
                Console.WriteLine("Type the number of the movie you want to pick");
                try
                {
                    movie_input = Convert.ToInt32(Console.ReadLine()!) - 1;
                    if (movie_input + 1 > running_movie_list.Count() || movie_input < 0)
                    {
                        Console.WriteLine("Invalid number; ");
                        continue;
                    }
                    movie_success = true;
                    

                }
                //Catches any type of exception.
                catch
                {
                    Console.WriteLine("Invalid number; please enter a correct number");
                }

            }

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