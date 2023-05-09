using System.Globalization;

static class AdminManageMovie
{

    static private RoomLogic roomLogic = new RoomLogic();
    static private MovieListLogic movieLogic = new MovieListLogic();
    static private RunningMovieLogic runningmovieLogic = new RunningMovieLogic("empty_file");
        
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __         _       __  __                             \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |_____ _(_)___  |  \\/  |__ _ _ _  __ _ __ _ ___ _ _ \r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / _ \\ V / / -_) | |\\/| / _` | ' \\/ _` / _` / -_) '_|\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\___/\\_/|_\\___| |_|  |_\\__,_|_||_\\__,_\\__, \\___|_|  \r\n                                                                        |___/        ");
        Console.ResetColor();
        Console.WriteLine("What do you want to do? \n");
        Console.WriteLine(" > [1] to add a movie and a room to a date.");
        Console.WriteLine(" > [2] to remove a movie and a room to a date ");
        Console.WriteLine(" > [3] to change the begin and end time  ");
        Console.WriteLine(" > [4] to change the movie  ");
        Console.WriteLine(" > [5] to change the room ");
        Console.WriteLine(" > [6] to change the date ");
        Console.WriteLine(" > [7] to see all the movies on a date");
        Console.WriteLine(" > [8] to go back \n");
        Console.WriteLine("");
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
        else if (manage_choice == "2")
        {
            Console.Clear();
            Delete_RunningMovie();
        }
        else if (manage_choice == "3")
        {
            Console.Clear();
            Change_Start_And_End_Time();

        }
        else if (manage_choice == "4")
        {
            Console.Clear();
            Change_Movie();

        }
        else if (manage_choice == "5")
        {
            Console.Clear();
            Change_Room();

        }
        else if (manage_choice == "6")
        {
            Console.Clear();
            Change_Date();
        }
        else if (manage_choice == "7")
        {
            Console.Clear();
            See_All_Movies_On_A_Date();
        }
        else if(manage_choice == "8")
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
            
        }
    }

    
    
    


    // Prints the list of all the running movies on a given date.
    static public void Get_Running_Movie_List(string your_date)
    {
        

        runningmovieLogic = new RunningMovieLogic(your_date);

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
            Start();
        }
    }


    // Gets the running movie based on a given date and movie name.
    static public RunningMovieModel Get_Running_Movie_To_Be_Changed(string your_date)
    {
        

        runningmovieLogic = new RunningMovieLogic(your_date);

        // Prints all the available movies on a date.
        Get_Running_Movie_List(your_date);

        //Asks the user which movie they want to have changed.
        Console.WriteLine("What movie do you want to have changed?");
        Console.WriteLine("Movie: ");
        string movie_name = Console.ReadLine()!;
        Console.Clear();

        // Returns a list with all the movies on a date with the same name.
        List<RunningMovieModel> runningmovie_list = runningmovieLogic.Return_RunningMovie_List_Based_On_Movie(movie_name);


        // Prints the list.
        Console.WriteLine($"Running Movies on {your_date} with the name {movie_name}: \n");
        foreach (RunningMovieModel runningmovie in runningmovie_list)
        {
            Console.WriteLine($"{runningmovie_list.IndexOf(runningmovie) + 1}|Movie: {runningmovie.Movie.Name}| " +
                $"Time: [{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}]| Room: {runningmovie.Room.ID}\n");
        }
        // If list is empty.
        if (runningmovie_list.Count == 0)
        {
            Console.WriteLine($"There are no movies with the name {movie_name} running on {your_date}\n");
            Start();
        }

        // Asks the user which running movie they want to change.
        Console.WriteLine("\n Which Movie do you want to change?");
        int to_be_changed_id = -1;
        bool to_be_changed_success = false;
        while (!to_be_changed_success)
        {
            Console.WriteLine("Enter the number of your movie: ");
            try
            {
                to_be_changed_id = Convert.ToInt32(Console.ReadLine());
                to_be_changed_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number; please enter a correct number");
            }
        }

        RunningMovieModel your_running_movie = runningmovie_list[to_be_changed_id - 1];
        return your_running_movie;
    }
    
    
    // Prints the list of all the movies available.
    static public void Get_Movie_List()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach (MovieListModel movie in movie_list)
        {
            Console.WriteLine($"{movie.Id}| {movie.Name}");
        }
    }

    // Asks the user for their movie.
    static public MovieListModel Get_Movie_From_Name()
    {
        
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

    // gets the string of a date.
    static public string Get_String_Date()
    {
        // Asks the user for their date
        Console.WriteLine("On which date is the movie?\n");
        Console.WriteLine("Date: [YYYY-MM-DD]");
        string your_date = Console.ReadLine()!;
        Console.Clear();
        return your_date;
    }

    // Asks the user for their date.
    static public DateTime Get_Date()
    {
        
        //Console.WriteLine("Which date do you want to add?");
        Console.WriteLine("Your date: [YYYY-MM-DD]");
        string dateString = Console.ReadLine()!;
        DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        return date;

    }

    // Asks the user for the start date of the movie.
    static public DateTime Get_Start_Time(DateTime date)
    {
        Console.WriteLine("Your start time: [HH:MM]");
        string start_string = Console.ReadLine()!;
        DateTime start_date = DateTime.ParseExact(start_string, "HH:mm", CultureInfo.InvariantCulture);

        DateTime correct_start_date= new DateTime(date.Year, date.Month, date.Day, start_date.Hour, start_date.Minute, start_date.Second);

        return correct_start_date;
    }
    
    // Asks the user for the end date of the movie.
    static public DateTime Get_End_Time(DateTime date)
    {
        
        Console.WriteLine("Your end time: [HH:MM]");
        string start_string = Console.ReadLine()!;
        DateTime start_date = DateTime.ParseExact(start_string, "HH:mm", CultureInfo.InvariantCulture);

        DateTime correct_start_date = new DateTime(date.Year, date.Month, date.Day, start_date.Hour, start_date.Minute, start_date.Second);

        return correct_start_date;
    }


    // Deletes a running movie from the list (and the json file)
    static public void Delete_RunningMovie()
    {
        // Gets the date in a string.
        string your_date = Get_String_Date();


        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.WriteLine("Your Movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]");

        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to delete the movie? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("your changes have been discarded");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            // If choice is yes, it will change the begin and end time to the json file.
            else if (confirmation_input == "Y")
            {
                Console.Clear();
                runningmovieLogic.Delete_From_List(running_movie);
                Console.WriteLine("Your changes have been made!");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    // Changes the start and the end time of a running movie.
    static public void Change_Start_And_End_Time()
    {

        // Gets the date in a string.
        string your_date = Get_String_Date();
        

        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.WriteLine("Current Movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]");

        // Asks the user for the start time of the movie.
        Console.WriteLine("\n\n You are now adding a new begin time \n\n");
        DateTime begin_time = Get_Start_Time(running_movie.Date);
        Console.Clear();

        // Asks the user for the end time of the movie.
        Console.WriteLine("You are now adding a end time \n\n");
        DateTime end_time = Get_End_Time(running_movie.Date);
        Console.Clear();

        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{begin_time.ToString("HH:mm")}-{end_time.ToString("HH:mm")}]");
        bool confirmation_success = false;
        while(!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("your changes have been discarded");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            // If choice is yes, it will change the begin and end time to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Begin_Time(begin_time,running_movie);
                runningmovieLogic.Change_End_Time(end_time, running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();


            }   
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
    

    static public void Change_Movie()
    {
        // Gets the date in a string.
        string your_date = Get_String_Date();


        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.WriteLine("Current Movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]");

        // Asks the user for the moviee.
        Console.WriteLine("\n\n You are now changing the  movie \n\n");
        MovieListModel movie = Get_Movie_From_Name();

        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        Console.WriteLine($"Movie: {movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]");
        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("your changes have been discarded");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            // If choice is yes, it will change the movie to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Movie(movie, running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();


            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    static public void Change_Room()
    {
        // Gets the date in a string.
        string your_date = Get_String_Date();


        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.WriteLine("Current Movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]| Room: {running_movie.Room.ID} ");

        // Asks the user for the room of the movie.
        Console.WriteLine("\n\n You are now changing the room \n\n");
        RoomModel room = Get_Room_From_Id();

        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}] Room: {room.ID}");
        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("your changes have been discarded");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            // If choice is yes, it will change the room to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Room(room, running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();


            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }


    static public void Change_Date()
    {
        // Gets the date in a string.
        string your_date = Get_String_Date();


        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.WriteLine("Current Movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]|" +
            $" Date: {running_movie.Date.ToString("yyyy-MM-dd")} ");

        // Asks the user for the date of the movie.
        Console.WriteLine("\n\n You are now changing the date \n\n");
        DateTime date = Get_Date();

        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        Console.WriteLine($"Movie: {running_movie.Movie.Name} | Time: [{running_movie.Begin_Time.ToString("HH:mm")}-{running_movie.End_Time.ToString("HH:mm")}]" +
            $"Date: {date}");


        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("your changes have been discarded");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();
            }
            // If choice is yes, it will change the date to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Date(date, running_movie);
                runningmovieLogic.Delete_From_List(running_movie);
                string date_string = date.ToString("yyyy-MM-dd");
                runningmovieLogic = new RunningMovieLogic(date_string);
                runningmovieLogic.Add_To_List(running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Console.WriteLine("now returning to the menu....\n\n");
                Start();


            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    // See all the running movies running on a certain date.
    static public void See_All_Movies_On_A_Date()
    {
        string date = Get_String_Date();
        Get_Running_Movie_List(date);

        // A while loop asking the user to press ENTER. only leaves when enter is pressed.
        while (true)
        {
            Console.WriteLine($"\nPress [Enter] to go back to the Admin Manage Movie Menu \n ");

            var readkey = Console.ReadKey();
            if (readkey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Start();

            }
            else
            {
                Console.Clear();
                Get_Running_Movie_List(date);
            }

        }
    }
    
    // Adds a running movie to the running movie list (and also the json file).
    static public void Add_RunningMovie()
    {

        // Asks the user for their movie.
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _   __  __         _     \r\n   /_\\  __| |__| | |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` | | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| |_|  |_\\___/\\_/|_\\___|\r\n                                         \n\n");
        Console.ResetColor();
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
        Console.WriteLine("You are now adding a room\n\n");
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
        Console.WriteLine("You are now adding a date\n\n");
        DateTime date = Get_Date();
        Console.Clear();
        string date_string = date.ToString("yyyy-MM-dd");
        RunningMovieLogic runningmovieLogic = new RunningMovieLogic(date_string);


        // Asks the user for the start time of the movie.
        Console.WriteLine("You are now adding a begin time \n\n");
        DateTime begin_time = Get_Start_Time(date);
        Console.Clear();

        // Asks the user for the end time of the movie.
        Console.WriteLine("You are now adding a end time \n\n");
        DateTime end_time = Get_End_Time(date);
        Console.Clear();

        RunningMovieModel running_movie = new(movie, room, begin_time, end_time, date);
        runningmovieLogic.Add_To_List(running_movie);


        Console.WriteLine("You have succesfully added a movie");
        Console.WriteLine("Now returning to the menu....\n\n");
        Start();
        
    }

    
}