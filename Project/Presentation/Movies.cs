using ConsoleTables;
using System.Globalization;

static class Movies
{

    static private RunningMovieLogic runningmovieLogic = Factory.runningmovieLogic;
    static private AccountsLogic accountsLogic = Factory.accountsLogic;



    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("> [1] See the movies running today.");
        Console.WriteLine("> [2] See movie on another date.");
        Console.WriteLine("> [3] Go back to menu");
        var movie_input = Console.ReadLine()!;

        if (movie_input == "1")
        {
            DateTime currentDateTime = DateTime.Now;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
            Console.ResetColor();
            Console.WriteLine("");
            Select_Movie(currentDateTime);
            Start();
        }
        else if (movie_input == "2")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
            Console.ResetColor();
            Console.WriteLine("");
            var next_date = Get_Date();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
            Console.ResetColor();
            Console.WriteLine("");
            Select_Movie(next_date);
            Start();
        }
        else if (movie_input == "3")
        {
            Console.Clear();
            if (accountsLogic.Return_Current_User() != null)
            {

                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Menu.Menu_When_Logged_In();
            }
            else
            {

                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Menu.Start();
            }
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


        //Gets the current date in a form of a string.

        string date = $"{your_date.Year}-{your_date.Month:00}-{your_date.Day:00}";

        //Gets all the running movies on a current date.
        while (true)
        {
            List<RunningMovieModel> running_movie_list = See_Movies_On_A_Date(date);
            Console.WriteLine("");

            // Asks the user for the number of their movie.
            int movie_input = -1;
            bool movie_success = false;
            while (!movie_success)
            {

                Console.WriteLine("Type the number of the movie you want to pick.\nTo leave press B, to change date press C");
                string input_movie = Console.ReadLine()!.ToUpper();

                //if account is not logged in.
                if (accountsLogic.Return_Current_User() == null)
                {
                    Console.Clear();
                    Console.WriteLine("You are not logged in yet.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Going back to menu....");
                    Thread.Sleep(1000);
                    Menu.Start();
                }
                // if input is C, you get to change to date.
                if (input_movie == "C")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
                    Console.ResetColor();
                    Console.WriteLine("");
                    var next_date = Get_Date();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("  __  __         _        \r\n |  \\/  |_____ _(_)___ ___\r\n | |\\/| / _ \\ V / / -_|_-<\r\n |_|  |_\\___/\\_/|_\\___/__/\r\n                          ");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Select_Movie(next_date);
                }
                //if input is B, you get back to the menu.
                if (input_movie == "B")
                {
                    Start();
                }

                try
                {
                    //Converts it into a number.
                    movie_input = Convert.ToInt32(input_movie) - 1;
                    if (movie_input + 1 > running_movie_list.Count() || movie_input + 1 <= 0)
                    {
                        Console.WriteLine("Invalid number. ");
                        continue;
                    }
                    if (running_movie_list[movie_input].Begin_Time < DateTime.Now)
                    {
                        Console.WriteLine("This movie has already started.\n");
                        continue;
                    }
                    if (accountsLogic.Age_Of_Current_User() <= running_movie_list[movie_input].Movie.Age)
                    {
                        Console.WriteLine("You are too young to watch this movie.\n");
                        continue;
                    }
                    movie_success = true;


                }
                //Catches any type of exception.
                catch
                {
                    Console.WriteLine("Invalid number, please enter a correct number");
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
            if (runningmovie.Begin_Time >= DateTime.Now)
            {
                string time = $"{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}";
                table.AddRow(running_movie_list.IndexOf(runningmovie) + 1, runningmovie.Movie.Name, time, runningmovie.Room.ID, runningmovie.Room.Available_Seats);
            }
        }
        table.Options.EnableCount = false;

        Console.WriteLine(table);
        return running_movie_list;

    }

    // gets the string of a date.
    static public DateTime Get_Date()
    {


        bool movie_success = false;
        string your_date = "";
        DateTime date = default;
        while (!movie_success)
        {
            // Asks the user for their date
            Console.WriteLine("On which date is the movie?\n");
            Console.WriteLine("Date: [YYYY-MM-DD]");
            your_date = Console.ReadLine()!;
            try
            {
                //Converts the input into a datetime
                date = DateTime.ParseExact(your_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                movie_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number; please enter a correct number");
            }

        }
        Console.Clear();
        return date;
    }
}