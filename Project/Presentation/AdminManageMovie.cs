using ConsoleTables;
using System.Globalization;

static class AdminManageMovie
{

    static private RoomLogic roomLogic = Factory.roomLogic;
    static private MovieListLogic movieLogic = Factory.movieLogic;
    static private RunningMovieLogic runningmovieLogic = Factory.runningmovieLogic;
    static private AccountsLogic accountsLogic = Factory.accountsLogic;

    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __         _       __  __                             \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |_____ _(_)___  |  \\/  |__ _ _ _  __ _ __ _ ___ _ _ \r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / _ \\ V / / -_) | |\\/| / _` | ' \\/ _` / _` / -_) '_|\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\___/\\_/|_\\___| |_|  |_\\__,_|_||_\\__,_\\__, \\___|_|  \r\n                                                                        |___/        ");
        Console.ResetColor();
        Console.WriteLine("What would you like to do? ");
        Console.WriteLine(" > [1] Add a movie and a room to a date");
        Console.WriteLine(" > [2] Remove a movie and a room to a date ");
        Console.WriteLine(" > [3] Change the begin and end time  ");
        Console.WriteLine(" > [4] Change the movie  ");
        Console.WriteLine(" > [5] Change the room ");
        Console.WriteLine(" > [6] Change the date ");
        Console.WriteLine(" > [7] See all the movies on a date");
        Console.WriteLine(" > [8] Populate a date with a bunch of random movies");
        Console.WriteLine(" > [9] Go back \n");
        Console.WriteLine("");


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
        else if (manage_choice == "9")
        {
            Console.Clear();
            Console.WriteLine("Going Back to Menu \n ");
            AdminMenu.Start();
        }
        else if (manage_choice == "8")
        {
            Console.Clear();
            Populate_A_Date();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("This is not one of the options!");
            Start();
        }

    }



    // Prints the list of all the rooms available.
    static public void Get_Room_List()
    {
        List<RoomModel> room_list = roomLogic.Return_Room_List();
        Console.WriteLine("Room list: ");
        //Creates a new table.
        var table = new ConsoleTable("Room ID", "Total Seats");
        //Loops through the running movie list, and add the contents to the table.
        foreach (RoomModel room in room_list)
        {
            table.AddRow(room.ID, room.Total_Seats);
        }
        table.Options.EnableCount = false;

        Console.WriteLine(table);
    }






    // Prints the list of all the running movies on a given date.
    static public void Get_Running_Movie_List(string your_date)
    {


        runningmovieLogic = new RunningMovieLogic(your_date);

        List<RunningMovieModel> runningmovie_list = runningmovieLogic.Return_RunningMovie_List();



        //Creates a new table.
        var table = new ConsoleTable("", "Movie", "Time", "Room", "Available Seats");
        //Loops through the running movie list, and add the contents to the table.
        if (runningmovie_list.Count == 0)
        {
            Console.Clear();
            Console.WriteLine($"There are no movies running on {your_date}\n");
            Start();
        }
        foreach (RunningMovieModel runningmovie in runningmovie_list)
        {
            string time = $"{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}";
            table.AddRow(runningmovie_list.IndexOf(runningmovie) + 1, runningmovie.Movie.Name, time, runningmovie.Room.ID, runningmovie.Room.Available_Seats);
        }
        table.Options.EnableCount = false;


        Console.WriteLine("Movie List: ");
        Console.WriteLine(table);
    }


    // Gets the running movie based on a given date and movie name.
    static public RunningMovieModel Get_Running_Movie_To_Be_Changed(string your_date)
    {


        runningmovieLogic = new RunningMovieLogic(your_date);

        // Prints all the available movies on a date.
        Get_Running_Movie_List(your_date);


        // Asks the user which running movie they want to change.
        Console.WriteLine("\n Which movie do you want to change?");
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

        List<RunningMovieModel> runningmovie_list = runningmovieLogic.Return_RunningMovie_List();
        RunningMovieModel your_running_movie = runningmovie_list[to_be_changed_id - 1];
        return your_running_movie;
    }


    // Prints the list of all the movies available.
    static public void Get_Movie_List()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        ConsoleTable.From<MovieListModel>(movie_list).Write(Format.Alternative);
    }

    // Asks the user for their movie.
    static public MovieListModel Get_Movie_From_Name()
    {

        Console.WriteLine("Current movie list: ");
        Get_Movie_List();
        Console.WriteLine("\nWhich movie do you want to choose?");
        Console.WriteLine("Movie: ");
        string movie_name = Console.ReadLine()!;
        MovieListModel movie = movieLogic.Find_Movie(movie_name);
        return movie;
    }

    // Asks the user for their room.
    static public RoomModel Get_Room_From_Id()
    {


        Get_Room_List();
        Console.WriteLine("\nWhich room do you want to choose?");

        int room_id = -1;
        bool room_success = false;
        while (!room_success)
        {
            Console.WriteLine("Room ID: ");
            try
            {

                room_id = Convert.ToInt32(Console.ReadLine());
                if (room_id <= roomLogic.Return_Room_List().Count || room_id > 0)
                {
                    room_success = true;
                }
                else
                {
                    Console.WriteLine("Not an available number");
                }

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number, please enter a correct number");
            }
        }

        RoomModel room = roomLogic.Find_Room(room_id);
        return room;
    }

    // gets the string of a date.
    static public string Get_String_Date()
    {


        bool movie_success = false;
        string your_date = "";
        while (!movie_success)
        {
            // Asks the user for their date
            Console.WriteLine("On which date is the movie?\n");
            Console.WriteLine("Date: [YYYY-MM-DD]");
            your_date = Console.ReadLine()!;
            try
            {
                DateTime date = DateTime.ParseExact(your_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                movie_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid date, please enter a correct date");
            }

        }
        Console.Clear();
        return your_date;
    }

    // Asks the user for their date.
    static public DateTime Get_Date()
    {

        bool movie_success = false;
        DateTime date = default;
        while (!movie_success)
        {
            // Asks the user for their date
            Console.WriteLine("Date: [YYYY-MM-DD]");
            string your_date = Console.ReadLine()!;
            try
            {
                date = DateTime.ParseExact(your_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                movie_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid date, please enter a correct date");
            }

        }
        Console.Clear();
        return date;

    }

    // Asks the user for the start date of the movie.
    static public DateTime Get_Start_Time(DateTime date)
    {
        DateTime correct_start_date;

        while (true)
        {
            Console.WriteLine("Your start time: [HH:MM]");
            string start_string = Console.ReadLine();

            try
            {
                DateTime start_date = DateTime.ParseExact(start_string, "HH:mm", CultureInfo.InvariantCulture);
                correct_start_date = new DateTime(date.Year, date.Month, date.Day, start_date.Hour, start_date.Minute, start_date.Second);
                break;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter the start time in the format [HH:MM].");
            }
        }

        return correct_start_date;
    }

   


    // Deletes a running movie from the list (and the json file)
    static public void Delete_RunningMovie()
    {

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___      _     _         __  __         _     \r\n |   \\ ___| |___| |_ ___  |  \\/  |_____ _(_)___ \r\n | |) / -_) / -_)  _/ -_) | |\\/| / _ \\ V / / -_)\r\n |___/\\___|_\\___|\\__\\___| |_|  |_\\___/\\_/|_\\___|\r\n                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        // Gets the date in a string.
        string your_date = Get_String_Date();


        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___      _     _         __  __         _     \r\n |   \\ ___| |___| |_ ___  |  \\/  |_____ _(_)___ \r\n | |) / -_) / -_)  _/ -_) | |\\/| / _ \\ V / / -_)\r\n |___/\\___|_\\___|\\__\\___| |_|  |_\\___/\\_/|_\\___|\r\n                                                ");
        Console.ResetColor();
        Console.WriteLine("");

        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine($"\n\n Do you want to delete {running_movie.Movie.Name} [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("Your changes have been discarded");
                Thread.Sleep(2000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
                Start();
            }
            // If choice is yes, it will change the begin and end time to the json file.
            else if (confirmation_input == "Y")
            {
                Console.Clear();
                runningmovieLogic.Delete_From_List(running_movie);
                Console.WriteLine("Your changes have been made!");
                Thread.Sleep(2000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___ _            _     _____ _           \r\n  / __| |_  __ _ _ _  __ _ ___  / __| |_ __ _ _ _| |_  |_   _(_)_ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\  _/ _` | '_|  _|   | | | | '  \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__\\__,_|_|  \\__|   |_| |_|_|_|_\\___|\r\n                     |___/                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        // Gets the date in a string.
        string your_date = Get_String_Date();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___ _            _     _____ _           \r\n  / __| |_  __ _ _ _  __ _ ___  / __| |_ __ _ _ _| |_  |_   _(_)_ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\  _/ _` | '_|  _|   | | | | '  \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__\\__,_|_|  \\__|   |_| |_|_|_|_\\___|\r\n                     |___/                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___ _            _     _____ _           \r\n  / __| |_  __ _ _ _  __ _ ___  / __| |_ __ _ _ _| |_  |_   _(_)_ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\  _/ _` | '_|  _|   | | | | '  \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__\\__,_|_|  \\__|   |_| |_|_|_|_\\___|\r\n                     |___/                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Current Movie: ");
        See_One_Movie(running_movie);

        // Asks the user for the start time of the movie.
        Console.WriteLine("\n\n You are now adding a new start time \n\n");
        DateTime begin_time = Get_Start_Time(running_movie.Date);
        running_movie.Begin_Time = begin_time;
        Console.Clear();

        // Asks the user for the end time of the movie.
        DateTime end_time = begin_time.AddMinutes(running_movie.Movie.Length);
        running_movie.End_Time = end_time;


        //Prints the new movie and asks the user for confirmation.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___ _            _     _____ _           \r\n  / __| |_  __ _ _ _  __ _ ___  / __| |_ __ _ _ _| |_  |_   _(_)_ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\  _/ _` | '_|  _|   | | | | '  \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__\\__,_|_|  \\__|   |_| |_|_|_|_\\___|\r\n                     |___/                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("New movie: ");
        See_One_Movie(running_movie);
        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("Your changes have been discarded");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
                Start();
            }
            // If choice is yes, it will change the begin and end time to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Begin_Time(begin_time, running_movie);
                runningmovieLogic.Change_End_Time(end_time, running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___  |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                            ");
        Console.ResetColor();
        Console.WriteLine("");
        // Gets the date in a string.
        string your_date = Get_String_Date();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___  |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                            ");
        Console.ResetColor();
        Console.WriteLine("");
        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___  |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                            ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Current Movie: ");
        See_One_Movie(running_movie);

        // Asks the user for the moviee.
        Console.WriteLine("\n\n You are now changing the  movie \n\n");
        MovieListModel movie = Get_Movie_From_Name();
        running_movie.Movie = movie;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___  |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                            ");
        Console.ResetColor();
        Console.WriteLine("");
        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        See_One_Movie(running_movie);
        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("Your changes have been discarded");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
                Start();
            }
            // If choice is yes, it will change the movie to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Movie(movie, running_movie);
                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___                \r\n  / __| |_  __ _ _ _  __ _ ___  | _ \\___  ___ _ __  \r\n | (__| ' \\/ _` | ' \\/ _` / -_) |   / _ \\/ _ \\ '  \\ \r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|_\\___/\\___/_|_|_|\r\n                     |___/                          ");
        Console.ResetColor();
        Console.WriteLine("");
        // Gets the date in a string.

        string your_date = Get_String_Date();


        // Finds your selected movie.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___                \r\n  / __| |_  __ _ _ _  __ _ ___  | _ \\___  ___ _ __  \r\n | (__| ' \\/ _` | ' \\/ _` / -_) |   / _ \\/ _ \\ '  \\ \r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|_\\___/\\___/_|_|_|\r\n                     |___/                          ");
        Console.ResetColor();
        Console.WriteLine("");

        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___                \r\n  / __| |_  __ _ _ _  __ _ ___  | _ \\___  ___ _ __  \r\n | (__| ' \\/ _` | ' \\/ _` / -_) |   / _ \\/ _ \\ '  \\ \r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|_\\___/\\___/_|_|_|\r\n                     |___/                          ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Current Movie: ");
        See_One_Movie(running_movie);

        // Asks the user for the room of the movie.
        Console.WriteLine("\n\n You are now changing the room \n\n");
        RoomModel room = Get_Room_From_Id();
        running_movie.Room = room;

        //Prints the new movie and asks the user for confirmation.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___                \r\n  / __| |_  __ _ _ _  __ _ ___  | _ \\___  ___ _ __  \r\n | (__| ' \\/ _` | ' \\/ _` / -_) |   / _ \\/ _ \\ '  \\ \r\n  \\___|_||_\\__,_|_||_\\__, \\___| |_|_\\___/\\___/_|_|_|\r\n                     |___/                          ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("New movie: ");
        See_One_Movie(running_movie);
        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {

                Console.Clear();
                Console.WriteLine("Your changes have been discarded");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
                Start();
            }
            // If choice is yes, it will change the room to the json file.
            else if (confirmation_input == "Y")
            {
                runningmovieLogic.Change_Room(room, running_movie);

                Console.Clear();
                Console.WriteLine("Your changes have been made!");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___       _       \r\n  / __| |_  __ _ _ _  __ _ ___  |   \\ __ _| |_ ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |) / _` |  _/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__,_|\\__\\___|\r\n                     |___/                         ");
        Console.ResetColor();
        Console.WriteLine("");
        // Gets the date in a string.
        string your_date = Get_String_Date();


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___       _       \r\n  / __| |_  __ _ _ _  __ _ ___  |   \\ __ _| |_ ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |) / _` |  _/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__,_|\\__\\___|\r\n                     |___/                         ");
        Console.ResetColor();
        Console.WriteLine("");
        // Finds your selected movie.
        RunningMovieModel running_movie = Get_Running_Movie_To_Be_Changed(your_date);

        //Prints your selected running movie.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___       _       \r\n  / __| |_  __ _ _ _  __ _ ___  |   \\ __ _| |_ ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |) / _` |  _/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__,_|\\__\\___|\r\n                     |___/                         ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Current Movie: ");
        See_One_Movie(running_movie);

        // Asks the user for the date of the movie.
        Console.WriteLine("\n\n You are now changing the date \n\n");
        DateTime date = Get_Date();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___       _       \r\n  / __| |_  __ _ _ _  __ _ ___  |   \\ __ _| |_ ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) | |) / _` |  _/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/\\__,_|\\__\\___|\r\n                     |___/                         ");
        Console.ResetColor();
        Console.WriteLine("");

        //Prints the new movie and asks the user for confirmation.
        Console.WriteLine("New movie: ");
        See_One_Movie(running_movie);


        bool confirmation_success = false;
        while (!confirmation_success)
        {
            Console.WriteLine("\n\n Do you want to confirm the changes? [Y/N]]\n\n");
            var confirmation_input = Console.ReadLine()!.ToUpper();

            // If choice is no, then go back to menu without any changes.
            if (confirmation_input == "N")
            {
                Console.Clear();
                Console.WriteLine("Your changes have been discarded");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
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
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___              _   _ _   __  __         _        \r\n / __| ___ ___    /_\\ | | | |  \\/  |_____ _(_)___ ___\r\n \\__ \\/ -_) -_)  / _ \\| | | | |\\/| / _ \\ V / / -_|_-<\r\n |___/\\___\\___| /_/ \\_\\_|_| |_|  |_\\___/\\_/|_\\___/__/\r\n                                                     ");
        Console.ResetColor();
        Console.WriteLine("");
        string date = Get_String_Date();

        // A while loop asking the user to press ENTER. only leaves when enter is pressed.
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  ___              _   _ _   __  __         _        \r\n / __| ___ ___    /_\\ | | | |  \\/  |_____ _(_)___ ___\r\n \\__ \\/ -_) -_)  / _ \\| | | | |\\/| / _ \\ V / / -_|_-<\r\n |___/\\___\\___| /_/ \\_\\_|_| |_|  |_\\___/\\_/|_\\___/__/\r\n                                                     ");
            Console.ResetColor();
            Console.WriteLine("");
            Get_Running_Movie_List(date);
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
            }

        }
    }

    static public void See_One_Movie(RunningMovieModel runningmovie)
    {
        //Creates a new table.
        var table = new ConsoleTable("", "Movie", "Time", "Room", "Available Seats");

        string time = $"{runningmovie.Begin_Time.ToString("HH:mm")}-{runningmovie.End_Time.ToString("HH:mm")}";
        table.AddRow(1, runningmovie.Movie.Name, time, runningmovie.Room.ID, runningmovie.Room.Available_Seats);

        table.Options.EnableCount = false;

        Console.WriteLine(table);
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
        if (movie == null)
        {
            Console.Clear();
            Console.WriteLine("Movie not found.");
            Thread.Sleep(1000);
            Console.WriteLine("Going back to menu....");
            Thread.Sleep(1000);
            Console.Clear();
            Start();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("    _      _    _   __  __         _     \r\n   /_\\  __| |__| | |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` | | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| |_|  |_\\___/\\_/|_\\___|\r\n                                         \n\n");
            Console.ResetColor();
            Console.WriteLine($"Movie [{movie.Name}] has been found");
        }

        // Asks the user for their room.

        Console.WriteLine("You are now adding a room\n\n");
        RoomModel room = Get_Room_From_Id();
        Console.Clear();

        //If room doesn't exist, return to menu. If room does exist, continue.
        if (room == null)
        {
            Console.Clear();
            Console.WriteLine("Room not found.");
            Thread.Sleep(1000);
            Console.WriteLine("Going back to menu....");
            Thread.Sleep(1000);
            Console.Clear();
            Start();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("    _      _    _   __  __         _     \r\n   /_\\  __| |__| | |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` | | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| |_|  |_\\___/\\_/|_\\___|\r\n                                         \n\n");
            Console.ResetColor();
            Console.WriteLine($"Room [{room.ID}] has been found");
        }

        // Asks the user for a date.

        Console.WriteLine("You are now adding a date\n\n");
        DateTime date = Get_Date();
        Console.Clear();
        string date_string = date.ToString("yyyy-MM-dd");
        runningmovieLogic = new RunningMovieLogic(date_string);


        // Asks the user for the start time of the movie.
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _   __  __         _     \r\n   /_\\  __| |__| | |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` | | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| |_|  |_\\___/\\_/|_\\___|\r\n                                         \n\n");
        Console.ResetColor();
        Console.WriteLine("You are now adding a begin time \n\n");
        DateTime begin_time = Get_Start_Time(date);
        Console.Clear();

        // Asks the user for the end time of the movie.
        //Console.WriteLine("You are now adding a end time \n\n");
        DateTime end_time = begin_time.AddMinutes(movie.Length);

        RunningMovieModel running_movie = new(movie, room, begin_time, end_time, date);
        runningmovieLogic.Add_To_List(running_movie);



        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _   __  __         _     \r\n   /_\\  __| |__| | |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` | | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| |_|  |_\\___/\\_/|_\\___|\r\n                                         \n\n");
        Console.ResetColor();
        Console.WriteLine("You have succesfully added a movie!");
        Thread.Sleep(1000);
        Console.WriteLine("Going back to menu....");
        Thread.Sleep(1000);
        Console.Clear();
        Start();

    }


    //Adds a random amount of movies to a date.
    public static void Populate_A_Date()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___               _      _                ___       _       \r\n | _ \\___ _ __ _  _| |__ _| |_ ___   __ _  |   \\ __ _| |_ ___ \r\n |  _/ _ \\ '_ \\ || | / _` |  _/ -_) / _` | | |) / _` |  _/ -_)\r\n |_| \\___/ .__/\\_,_|_\\__,_|\\__\\___| \\__,_| |___/\\__,_|\\__\\___|\r\n         |_|                                                  ");
        Console.ResetColor();
        Console.WriteLine("");
        //Gets the date.
        DateTime date = Get_Date();

        //Converts the date to string and opens a new runningmovielogic.
        string date_string = date.ToString("yyyy-MM-dd");
        runningmovieLogic = new RunningMovieLogic(date_string);

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___               _      _                ___       _       \r\n | _ \\___ _ __ _  _| |__ _| |_ ___   __ _  |   \\ __ _| |_ ___ \r\n |  _/ _ \\ '_ \\ || | / _` |  _/ -_) / _` | | |) / _` |  _/ -_)\r\n |_| \\___/ .__/\\_,_|_\\__,_|\\__\\___| \\__,_| |___/\\__,_|\\__\\___|\r\n         |_|                                                  ");
        Console.ResetColor();
        Console.WriteLine("");

        //Asks the user how many random movie they want to add.
        Console.WriteLine("Enter the amount of movies you want to add");
        Console.WriteLine("Amount: ");
        var population_input = Convert.ToInt32(Console.ReadLine()!);

        //Loops through the amount of movies.
        for (int i = 0; i <= population_input; i++)
        {
            runningmovieLogic.Populate(date);
        }
        Console.Clear();
        Start();


    }


}