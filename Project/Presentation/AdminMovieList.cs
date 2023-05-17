using ConsoleTables;

static class AdminMovieList
{
    static private MovieListLogic movieLogic = new MovieListLogic();
    static public void Start()
    {
<<<<<<< Updated upstream
=======
        Console.WriteLine("You are currently on the admin movie list menu\n\nWhat would you like to do?\n[1] Add a movie to the list of movies\n[2] Remove a movie from the list\n[3] See the current list of movies (Only the ID's and names)\n[4] Edit a movie's information\n[5] Return to the main menu\n");
        string input = Console.ReadLine()!;
        int int_input = Convert.ToInt32(input);
        switch (int_input)
        {
            case 1:
                Add_Movie();
                break;
            case 2:
                Remove_Movie();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("The current list of movies consists of:\n");
                Get_Movie_Names();
>>>>>>> Stashed changes
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        __  __         _       __  __ ___          \r\n   /_\\  __| |_ __ (_)_ _   |  \\/  |_____ _(_)___  |  \\/  | __|_ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  | |\\/| / _ \\ V / / -_) | |\\/| | _|| ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |_|  |_\\___/\\_/|_\\___| |_|  |_|___|_||_\\_,_|\r\n                                                                      ");
        Console.ResetColor();
        Console.WriteLine("What would you like to do?\n > [1] Add a movie to the list of movies\n > [2] Remove a movie from the list\n > [3] See the current list of movies\n > [4] Edit a movie's information\n > [5] Sort movies by genre\n > [6] Return to the main menu\n");
        string input = Console.ReadLine()!;
        switch (input)
        {
            case "1":
                Add_Movie();
                break;
            case "2":
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
<<<<<<< Updated upstream
=======
            case 4:
                Console.Clear();
                Change_Movie();
                break;
            case 5:
                Console.Clear();
                Menu.Start();
>>>>>>> Stashed changes
            case "4":
                Console.Clear();
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
            default:
                Console.Clear();
                Console.WriteLine("Invalid input\n");
                Start();
                break;
        }
    }
    static public void Sort_By_Genre()
    {
        Console.WriteLine("Type the genre you would like to filter on");
        string given_genre = Console.ReadLine();
        var movie_genres = movieLogic.Return_By_Genre(given_genre);
        ConsoleTable.From<MovieListModel>(movie_genres).Write();
    }

    static public void Get_Movie_List()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach (MovieListModel movie in movie_list)
        {
            Console.WriteLine($"{movie}\n");
        }
    }

<<<<<<< Updated upstream
=======
    static public void Get_Movie_Names()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach(MovieListModel movie in movie_list)
        {
            Console.WriteLine($"ID: {movie.Id}| Name: {movie.Name}\n");
        }
>>>>>>> Stashed changes
    static public void Get_Movie_Table()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        ConsoleTable.From<MovieListModel>(movie_list).Write();

    }

    static public int New_Movie_id()
    {
        int next_id = MovieListLogic.Find_Next_ID();
        return next_id;
    }

    static public string New_Movie_Name()
    {
        Console.WriteLine("Enter the name of the new movie you would like to add: ");
        string movie_name = Console.ReadLine()!;
        return movie_name;
    }

    static public string New_Movie_Genre()
    {
        Console.WriteLine("Enter the genre(s) of this movie: ");
        string movie_genre = Console.ReadLine()!;
        return movie_genre;
    }
    
    // Length has to be expressed in numbers and will not accept anything but numbers
    static public int New_Movie_Length()
    {   
        bool correct_price = false;
        while (!correct_price)
        {
            Console.WriteLine("Enter the length of the movie in minutes in numbers: ");
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
            Console.WriteLine("Enter the minumum age of the movie goer for this movie: ");
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
        Console.WriteLine("Please enter the parental labels you would like to attach to this movie: ");
        string movie_labels = Console.ReadLine()!;
        if (movie_labels == "")
        {
            movie_labels = "None";
        }
        return movie_labels;
    }

    static public void Add_Movie()
    {
        Console.Clear();
        Console.WriteLine("You are currently on the add a movie page\n\n");
        Console.WriteLine("Current list of movies: ");
<<<<<<< Updated upstream
=======
        Get_Movie_Names();
>>>>>>> Stashed changes
        Get_Movie_Table();
        Console.WriteLine();
        int movie_id = New_Movie_id();
        string movie_name = New_Movie_Name();
        string movie_genre = New_Movie_Genre();
        int movie_length = New_Movie_Length();
        int movie_age = New_Movie_Age();
        string movie_labels = New_Movie_Labels();
        Console.Clear();

        MovieListModel movie = new(movie_id, movie_name, movie_genre, movie_length, movie_age, movie_labels);
        while (true)
        {
            MovieListModel new_movie = movieLogic.Find_Movie(movie.Name);
            Console.WriteLine(movie);
            if (new_movie != null)
            {
                Console.WriteLine("This movie is already in the list of movies. \nPress any button to return to the main menu...");
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
<<<<<<< Updated upstream
=======
                Get_Movie_Names();
>>>>>>> Stashed changes
                Get_Movie_Table();
                Console.WriteLine("Press any button to return to the movie list menu");
                Console.ReadKey();
                Console.Clear();
                Start();
            }
        }
    }

    static public void Remove_Movie()
    {
        Console.Clear();
        Console.WriteLine("You are currently on the remove a movie page\n\nCurrent list of movies:\n");
<<<<<<< Updated upstream
=======
        Get_Movie_Names();
        Console.WriteLine();
        Console.WriteLine("Which movie would you like to remove? (please provide only the ID)");
>>>>>>> Stashed changes
        Get_Movie_Table();
        Console.WriteLine();
        while (true) 
        {
            try
            {
                Console.WriteLine("Which movie would you like to remove? (please provide only the ID)");
                string remove_id = Console.ReadLine();
                int for_removal = Convert.ToInt32(remove_id);
                MovieListModel selected_movie = movieLogic.Find_Movie_ID(for_removal);
                if (selected_movie == null)
                {
                    Console.WriteLine("This ID does not belong to any movies\nPress any button to return to Admin Movie list menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
                else
                {
<<<<<<< Updated upstream
=======
                    Console.WriteLine($"Are you sure you wish to remove the movie {selected_movie.Name}? (Y/N)");
                    string movie_confirmation = Console.ReadLine()!.ToUpper();
                    switch (movie_confirmation)
                    {
                        case "Y":
                            movieLogic.Delete_From_List(selected_movie);
                            Console.Clear();
                            Console.WriteLine($"{selected_movie.Name} has been succesfully removed from the movie list\nCurrent list of movies:\n");
                            Get_Movie_Names();
                            Console.WriteLine("Press any button to return to the movie list menu");
                            Console.ReadKey();
                            Console.Clear();
                            Start();
                            break;

                        case "N":
                            Console.WriteLine("\nPress any button to return to the movie list menu");
                            Console.ReadKey();
                            Console.Clear();
                            Start();
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
>>>>>>> Stashed changes
                    while (true)
                    {
                        Console.WriteLine($"Are you sure you wish to remove the movie {selected_movie.Name}? (Y/N)");
                        string movie_confirmation = Console.ReadLine()!.ToUpper();
                        switch (movie_confirmation)
                        {
                            case "Y":
                                movieLogic.Delete_From_List(selected_movie);
                                Console.Clear();
                                Console.WriteLine($"{selected_movie.Name} has been succesfully removed from the movie list\nCurrent list of movies:\n");
                                Get_Movie_Table();
                                Console.WriteLine("Press any button to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;

                            case "N":
                                Console.WriteLine("\nPress any button to return to the movie list menu");
                                Console.ReadKey();
                                Console.Clear();
                                Start();
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
<<<<<<< Updated upstream
                    
=======
>>>>>>> Stashed changes
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
        Console.WriteLine("You are currently on the edit movie information page\n\nCurrent list of movies: \n");
<<<<<<< Updated upstream
=======
        Get_Movie_List();
>>>>>>> Stashed changes
        Get_Movie_Table();
        Console.WriteLine();
        Console.WriteLine("Which movie's information would you like to change? (Please provide only the ID)\n");
        while (true)
        {
            try
            {
                string for_update = Console.ReadLine();
                int update_id = Convert.ToInt32(for_update);
                MovieListModel selected_movie = movieLogic.Find_Movie_ID(update_id);
                if (selected_movie == null)
                {
                    Console.WriteLine("This ID does not belong to any movies\nPress any button to return to Admin Movie list menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"You have selected the movie {selected_movie.Name}\n");
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
                                Change_Movie();
                                Console.Clear();
                                break;
                            case "7":
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
