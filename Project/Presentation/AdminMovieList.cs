using ConsoleTables;

static class AdminMovieList
{
    static private MovieListLogic movieLogic = new MovieListLogic();
    static private RunningMovieLogic runningmovieLogic = new RunningMovieLogic("empty_file");

    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __         _       __  __              \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |_____ _(_)___  |  \\/  |___ _ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / _ \\ V / / -_) | |\\/| / -_) ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\___/\\_/|_\\___| |_|  |_\\___|_||_\\_,_|\r\n                                                                      ");
        Console.ResetColor();
        Console.WriteLine("What would you like to do?\n > [1] Add a movie to the list of movies\n > [2] Remove a movie from the list\n > [3] See the current list of movies\n > [4] Edit a movie's information\n > [5] Sort movies by genre\n > [6] Return to the main menu\n");
        string input = Console.ReadLine()!;
        switch (input)
        {
            case "1":
                Add_Movie();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("You are currently on the remove a movie page\n\nCurrent list of movies:\n");
                Get_Movie_Table();
                Remove_Movie();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("The current list of movies consists of:\n");
                Get_Movie_Table();
                Console.WriteLine("\nPress any button to return to the main menu");
                Console.ReadKey();
                Console.Clear();
                Start();
                break;
            case "4":
                Console.Clear();
                Console.WriteLine("Current list of movies:\n");
                Get_Movie_Table();
                Change_Movie();
                break;
            case "5":
                Console.Clear();
                Sort_By_Genre();
                break;
            case "6":
                Console.Clear();
                AdminMenu.Start();
                break;
            case "7":
                Console.Clear();
                View_Movie_Synopsis();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid input\n");
                Start();
                break;
        }
    }
    // This changes all the ID's to be relevant to their relative position in the list, this so that no gaps can fall whenever you remove a movie
    public static void Update_Movie_ID()
    {
        MovieListLogic movieListLogic = new MovieListLogic();
        movieListLogic.Update_Movie_ID();
    }

    static public void View_Movie_Synopsis()
    {
        while (true)
        {
            Get_Movie_Table();
            Console.WriteLine("\nPlease provide the ID of the movie you would like to see the summary of: ");
            string movie_ID = Console.ReadLine();
            try
            {
                int int_id = Convert.ToInt32(movie_ID);
                string synopsis = movieLogic.Return_Movie_Synopsis(int_id);
                Console.WriteLine(synopsis);
                Console.ReadKey();
                Start();
            }
            catch
            {
                Console.WriteLine("Invalid input\n");
            }
        }
        
    }
    static public void View_Running_Movies()
    {
        runningmovieLogic = new RunningMovieLogic("");
        List<RunningMovieModel> runningmovie_list = runningmovieLogic.Return_RunningMovie_List();
        ConsoleTable.From<RunningMovieModel>(runningmovie_list).Write();
    }

    // Allows you to see what movies in the list currently have a certain genre defined
    static public void Sort_By_Genre()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___          _     ___         ___                  \r\n / __| ___ _ _| |_  | _ )_  _   / __|___ _ _  _ _ ___ \r\n \\__ \\/ _ \\ '_|  _| | _ \\ || | | (_ / -_) ' \\| '_/ -_)\r\n |___/\\___/_|  \\__| |___/\\_, |  \\___\\___|_||_|_| \\___|\r\n                         |__/                        ");
        Console.ResetColor();
        Console.WriteLine("> Type out the genre you would like to filter on\n");
        string given_genre = Console.ReadLine();
        var movie_genres = movieLogic.Return_By_Genre(given_genre);
        ConsoleTable.From<MovieListModel>(movie_genres).Write(Format.Alternative);
        Console.WriteLine();
        Console.WriteLine("Please select your next action\n > [1] Edit a movie's information\n > [2] Remove a movie\n > [3] Return to admin movie list\n");
        string genre_choice = Console.ReadLine();
        switch(genre_choice)
        {
            case "1":
                Change_Movie();
                break;
            case "2":
                Remove_Movie();
                break;
            case "3":
                Console.Clear();
                Start(); 
                break;
        }
    }


    // Prints all the movies from the list in the table we use for this
    static public void Get_Movie_Table()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        ConsoleTable.From<MovieListModel>(movie_list).Write(Format.Alternative);
    }

    // Finds the highest ID in the list and returns this value +1 for the new movie
    static public int New_Movie_id()
    {
        int next_id = MovieListLogic.Find_Next_ID();
        return next_id;
    }

    static public string New_Movie_Name()
    {
        Console.WriteLine("\n > Enter the name of the new movie you would like to add: ");
        string movie_name = Console.ReadLine()!;
        return movie_name;
    }

    static public string New_Movie_Genre()
    {
        Console.WriteLine("\n > Enter the genre(s) of this movie: ");
        string movie_genre = Console.ReadLine()!;
        return movie_genre;
    }
    
    // Length has to be expressed in numbers and will not accept anything but numbers
    static public int New_Movie_Length()
    {   
        bool correct_price = false;
        while (!correct_price)
        {
            Console.WriteLine("\n > Enter the length of the movie in minutes in numbers: ");
            try
            {
                string movie_length_string = Console.ReadLine();
                int movie_length = Convert.ToInt32(movie_length_string);
                return movie_length;
                correct_price = true;
            }
            catch
            {
                Console.WriteLine("Please enter only numbers");
            }
        }
        return 0;
    }

    // Age has to be expressed in numbers and will not accept anything but numbers
    static public int New_Movie_Age()
    {
        bool correct_age = false;
        while (!correct_age)
        {
            Console.WriteLine("\n > Enter the minumum age of the movie goer for this movie: ");
            try
            {
                string movie_age_string = Console.ReadLine();
                int movie_age = Convert.ToInt32(movie_age_string);
                return movie_age;
                correct_age = true;
            }
            catch
            {
                Console.WriteLine("Please enter only numbers");
            }
        }
        return 0;
    }

    static public string New_Movie_Labels()
    {
        Console.WriteLine("\n > Please enter the parental labels you would like to attach to this movie: ");
        string movie_labels = Console.ReadLine()!;
        if (movie_labels == "")
        {
            movie_labels = "None";
        }
        return movie_labels;
    }

    static public string New_Movie_Summary()
    {
        Console.WriteLine("\n > Please enter the summary of the movie here: ");
        string movie_summary = Console.ReadLine()!;
        if (movie_summary == "")
        {
            movie_summary = "No summary given";
        }
        return movie_summary;
    }

    static public void Add_Movie()
    {
        Console.Clear();
        Console.WriteLine("Current list of movies: ");
        Get_Movie_Table();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _     _     __  __         _     \r\n   /_\\  __| |__| |   /_\\   |  \\/  |_____ _(_)___ \r\n  / _ \\/ _` / _` |  / _ \\  | |\\/| / _ \\ V / / -_)\r\n /_/ \\_\\__,_\\__,_| /_/ \\_\\ |_|  |_\\___/\\_/|_\\___|\r\n                                                ");
        Console.ResetColor();
        int movie_id = New_Movie_id();
        string movie_name = New_Movie_Name();
        string movie_genre = New_Movie_Genre();
        int movie_length = New_Movie_Length();
        int movie_age = New_Movie_Age();
        string movie_labels = New_Movie_Labels();
        string movie_summary = New_Movie_Summary();
        Console.Clear();

        MovieListModel movie = new(movie_id, movie_name, movie_genre, movie_length, movie_age, movie_labels, movie_summary);
        while (true)
        {
            // Checks if a movie with the same name isn't already in the list and makes it so that it doesn't get added if it is the case
            MovieListModel new_movie = movieLogic.Find_Movie(movie.Name);
            Console.WriteLine(movie);
            if (new_movie != null)
            {
                Console.WriteLine("This movie is already in the list of movies. \n > Press any button to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
                Start();
            }
            else
            {
                movieLogic.Add_To_List(movie);
                Console.WriteLine($"The movie, '{movie.Name}' has succesfully been added to the list of movies");
                Thread.Sleep(10000);
                Console.Clear();
                Console.WriteLine("Current list of movies:\n");
                Get_Movie_Table();
                Console.WriteLine(" > Press any button to return to the movie list menu");
                Console.ReadKey();
                Console.Clear();
                Start();
            }
        }
    }

    static public void Remove_Movie()
    {
        Console.WriteLine();
        while (true) 
        {
            try
            {
                var for_removal = Console.ReadLine();

                int intInput;
                MovieListModel selected_movie = null;

                if (int.TryParse(for_removal, out intInput))
                {
                    // User input is an integer
                    selected_movie = movieLogic.Find_Movie(intInput);
                }

                if (selected_movie == null)
                {
                    // Either user input is a string or the integer input didn't match any movie
                    selected_movie = movieLogic.Find_Movie(for_removal);

                    if (selected_movie == null)
                    {
                        Console.WriteLine("This ID does not belong to any movies\nPress any button to return to Admin Movie list menu");
                        Console.ReadKey();
                        Console.Clear();
                        Start();
                    }
                }
                {
                    while (true)
                    {
                        Console.WriteLine($" > Are you sure you wish to remove the movie {selected_movie.Name}? (Y/N)");
                        string movie_confirmation = Console.ReadLine()!.ToUpper();
                        switch (movie_confirmation)
                        {
                            case "Y":
                                movieLogic.Delete_From_List(selected_movie);
                                Console.Clear();
                                Console.WriteLine($"{selected_movie.Name} has been succesfully removed from the movie list\nCurrent list of movies:\n");
                                Update_Movie_ID();
                                Get_Movie_Table();
                                Console.WriteLine(" > Press any button to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;

                            case "N":
                                Console.WriteLine("\n > Press any button to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
                    
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, only numbers are accepted");
            }
        }
    }

    static public void Change_Movie()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                           _     __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___    /_\\   |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_)  / _ \\  | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| /_/ \\_\\ |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                                    ");
        Console.ResetColor();
        Console.WriteLine("\n > Which movie's information would you like to change? (Please provide either the ID or the name)\n");
        while (true)
        {
            try
            {
                var for_update = Console.ReadLine();

                int intInput;
                MovieListModel selected_movie = null;

                if (int.TryParse(for_update, out intInput))
                {
                    // User input is an integer
                    selected_movie = movieLogic.Find_Movie(intInput);
                }

                if (selected_movie == null)
                {
                    // Either user input is a string or the integer input didn't match any movie
                    selected_movie = movieLogic.Find_Movie(for_update);

                    if (selected_movie == null)
                    {
                        Console.WriteLine("This ID does not belong to any movies\nPress any button to return to Admin Movie list menu");
                        Console.ReadKey();
                        Console.Clear();
                        Start();
                    }
                }
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("   ___ _                           _     __  __         _     \r\n  / __| |_  __ _ _ _  __ _ ___    /_\\   |  \\/  |_____ _(_)___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_)  / _ \\  | |\\/| / _ \\ V / / -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| /_/ \\_\\ |_|  |_\\___/\\_/|_\\___|\r\n                     |___/                                    ");
                        Console.ResetColor();
                        Console.WriteLine($"\nYou have selected the movie: {selected_movie.Name}\n");
                        Console.WriteLine($"Information of the selected movie: \n{selected_movie}\n");
                        Console.WriteLine("What part would you like to edit?\n[1] Change the name of the movie\n[2] Change the genre of the movie\n[3] Change the length of the movie\n[4] Change the minimum age of the movie\n[5] Change the labels of the movie\n[6] Select a different movie\n[7] Return to the admin movie list menu");
                        string movie_edit = Console.ReadLine()!;
                        switch (movie_edit)
                        {
                            case "1":
                                string new_name_value = New_Movie_Name();
                                movieLogic.Update_Movie_Name(new_name_value, selected_movie);
                                Console.WriteLine($"The name of {selected_movie.Name} has been updated\n\nUpdated information of this movie\n {selected_movie}\nPress any key to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;
                            case "2":
                                string new_genre_value = New_Movie_Genre();
                                movieLogic.Update_Movie_Genre(new_genre_value, selected_movie);
                                Console.WriteLine($"The genre of {selected_movie.Name} has been updated\n\nUpdated information of this movie\n {selected_movie}Press any key to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;
                            case "3":
                                int new_length_value = New_Movie_Length();
                                movieLogic.Update_Movie_Length(new_length_value, selected_movie);
                                Console.WriteLine($"The length of {selected_movie.Name} has been updated\n\nUpdated information of this movie\n {selected_movie}\nPress any key to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;
                            case "4":
                                int new_age_value = New_Movie_Age();
                                movieLogic.Update_Movie_Age(new_age_value, selected_movie);
                                Console.WriteLine($"The age of {selected_movie.Name} has been updated\n\nUpdated information of this movie\n {selected_movie}\nPress any key to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;
                            case "5":
                                string new_label_value = New_Movie_Labels();
                                movieLogic.Update_Movie_Labels(new_label_value, selected_movie);
                                Console.WriteLine($"The label(s) of {selected_movie.Name} has been updated\n\nUpdated information of this movie\n {selected_movie}\nPress any key to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;
                            case "6":
                                Console.Clear();
                                
                                break;
                            case "7":
                                Console.Clear();
                                Change_Movie();
                                break;
                            case "8":
                                Console.Clear();
                                Console.Clear();
                                Start(); 
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, only numbers are accepted");
            }
        }
    }
}
