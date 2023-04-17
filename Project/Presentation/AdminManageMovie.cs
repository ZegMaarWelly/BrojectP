using System;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

static class AdminManageMovie
{

    static private RoomLogic roomLogic = new RoomLogic();
    static private MovieListLogic movieLogic = new MovieListLogic();
    //static private RunningMovieLogic runningmovieLogic = new RunningMovieLogic("2023-15-05");
        
    static public void Start()
    {
        Console.WriteLine("Current Location: Admin Manage Movie \n\n");
        Console.WriteLine("What do you want to do? \n");
        Console.WriteLine("[1] to add a movie and a room to a date.");
        Console.WriteLine("[2] to remove a movie and a room to a date n/a");
        Console.WriteLine("[3] to change the movie n/a ");
        Console.WriteLine("[4] to change the room n/a");
        Console.WriteLine("[5] to change the date n/a");
        Console.WriteLine("[6] to see all the movies on a date");
        Console.WriteLine("[7] to go back \n");
        Console.WriteLine("Your option: ");
        //DateTime date = new DateTime(2012, 5, 5);
        //Console.WriteLine(date.ToString("yyyy-MM-dd"));
        //DateTime time = new DateTime(1, 1, 1, 13, 15, 0);
        //Console.WriteLine(time.ToString("HH:mm"));


        var manage_choice = Console.ReadLine()!;
        if (manage_choice == "1")
        {
            Console.Clear();
            Add_RunningMovie();
        }
        else if (manage_choice == "6")
        {
            Console.Clear();
            Get_Running_Movie_List();
        }
        else if(manage_choice == "7")
        {
            Console.Clear();
            Console.WriteLine("Going Back to Menu \n ");
            AdminMenu.Start();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("This feature does not exist (yet) ");
            Start();
        }

    }

    // Prints the list of all the rooms available.
    static public void Get_Room_List()
    {
        List<RoomModel> room_list = roomLogic.Return_Room_List();
        Console.WriteLine("Room list: ");
        foreach (RoomModel room in room_list)
        {
            Console.WriteLine($"Room: {room.ID}| Total Seats: {room.Total_Seats}");
            //foreach (string line in room.Map)
            //{
            //    Console.WriteLine(line);
            //}
        }
    }

    // Prints the list of all the running movies on a given date.
    static public void Get_Running_Movie_List()
    {
        // Asks the user for their date
        Console.WriteLine("On which date do you want to see the movies?\n");
        Console.WriteLine("Date: ");
        string your_date = Console.ReadLine()!;
        Console.Clear();

        RunningMovieLogic runningmovieLogic = new RunningMovieLogic(your_date);

        List<RunningMovieModel> runningmovie_list = runningmovieLogic.Return_RunningMovie_List();

        // Prints the list.
        Console.WriteLine($"Running Movies on {your_date}: \n");
        foreach(RunningMovieModel runningmovie  in runningmovie_list)
        {
            Console.WriteLine($"Movie: {runningmovie.Movie.Name}| Time: [{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}]| Room: {runningmovie.Room.ID}\n");
        }
        // If list is empty.
        if(runningmovie_list.Count == 0)
        {
            Console.WriteLine($"There are no movies running on {your_date}\n");
        }

        // A while loop asking the user to press ENTER. only leaves when enter is pressed.
        while(true)
        {
            Console.WriteLine($"\nPress [Enter] to go back to the Admin Manage Movie Menu \n ");

            var readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Start();

            }

        }
    }
    
    
    // Prints the list of all the movies available.
    static public void Get_Movie_List()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach (MovieListModel movie in movie_list)
        {
            Console.WriteLine(movie);
        }
    }

    // Asks the user for their movie.
    static public MovieListModel Get_Movie_From_Name()
    {
        Console.WriteLine("You are now adding a movie to a time and a room\n\n");
        Console.WriteLine("Current movie list: ");
        Get_Movie_List();
        Console.WriteLine("\nWhich movie do you want to choose?");
        Console.WriteLine("Movie: ");
        string movie_name = Console.ReadLine()!;
        MovieListModel  movie = movieLogic.Find_Movie(movie_name);
        return movie;
    }

    // Asks the user for their room.
    static public RoomModel Get_Room_From_Id()
    {
        Console.WriteLine("You are now adding a room\n\n");
        Console.WriteLine("Current movie list: ");
        Get_Room_List();
        Console.WriteLine("\nWhich room do you want to choose?");

        int room_id = -1;
        bool room_success = false;
        while (!room_success)
        {
            Console.WriteLine("Room: ");
            try
            {
                room_id = Convert.ToInt32(Console.ReadLine());
                room_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number; please enter a correct number");
            }
        }

        RoomModel room = roomLogic.Find_Room(room_id);
        return room;
    }

    // Asks the user for their date.
    static public DateTime Get_Date()
    {
        Console.WriteLine("You are now adding a date\n\n");
        Console.WriteLine("Which date do you want to add?");
        Console.WriteLine("Your date: [YYYY-MM-DD]");
        string dateString = Console.ReadLine()!;
        DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        return date;

    }

    // Asks the user for the start date of the movie.
    static public DateTime Get_Start_Time(DateTime date)
    {
        Console.WriteLine("You are now adding a start time \n\n");
        Console.WriteLine("Your start time: [HH:MM]");
        string startString = Console.ReadLine()!;
        DateTime start_date = DateTime.ParseExact(startString, "HH:mm", CultureInfo.InvariantCulture);

        DateTime correct_start_date= new DateTime(date.Year, date.Month, date.Day, start_date.Hour, start_date.Minute, start_date.Second);

        return correct_start_date;
    }
    
    // Asks the user for the end date of the movie.
    static public DateTime Get_End_Time(DateTime date)
    {
        Console.WriteLine("You are now adding a end time \n\n");
        Console.WriteLine("Your start time: [HH:MM]");
        string startString = Console.ReadLine()!;
        DateTime start_date = DateTime.ParseExact(startString, "HH:mm", CultureInfo.InvariantCulture);

        DateTime correct_start_date = new DateTime(date.Year, date.Month, date.Day, start_date.Hour, start_date.Minute, start_date.Second);

        return correct_start_date;
    }

    static public void Add_RunningMovie()
    {

        // Asks the user for their movie.
        MovieListModel movie = Get_Movie_From_Name();
        Console.Clear();

        //If movie doesn't exist, return to menu. If movie does exist, continue.
        if(movie == null)
        {
            Console.WriteLine("Movie not found, returning to menu.");
            Start();
        }
        else
        {
            Console.WriteLine($"Movie [{movie.Name}] has been found");
        }

        // Asks the user for their room.
        RoomModel room = Get_Room_From_Id();
        Console.Clear();

        //If room doesn't exist, return to menu. If room does exist, continue.
        if (room == null)
        {
            Console.WriteLine("room not found, returning to menu.");
            Start();
        }
        else
        {
            Console.WriteLine($"Room [{room.ID}] has been found");
        }

        // Asks the user for a date.
        DateTime date = Get_Date();
        Console.WriteLine($"Date: {date}");
        Console.Clear();
        string date_string = date.ToString("yyyy-MM-dd");
        RunningMovieLogic runningmovieLogic = new RunningMovieLogic(date_string);


        // Asks the user for the start time of the movie.
        DateTime begin_time = Get_Start_Time(date);
        Console.Clear();

        // Asks the user for the end time of the movie.
        DateTime end_time = Get_End_Time(date);
        Console.Clear();

        RunningMovieModel running_movie = new(movie, room, begin_time, end_time, date);
        runningmovieLogic.Add_To_List(running_movie);
        Start();
    }

    
}