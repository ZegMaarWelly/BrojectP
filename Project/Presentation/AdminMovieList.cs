static class AdminMovieList
{
    static private MovieListLogic movieLogic = new MovieListLogic();
    static public void Start()
    {
        Console.WriteLine("Admin movie list menu\n\nWhat would you like to do?\n1) Add a movie to the list of movies\n2) Remove a movie from the list\n3) See the current list of movies\n4) Return to the main menu\n");
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
                Console.WriteLine("\nPress any button to return to the main menu");
                Console.ReadKey();
                Console.Clear();
                Start();
                break;
            case 4:
                Console.Clear();
                Menu.Start();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid input\n");
                Start();
                break;
        }
    }

    static public void Get_Movie_List()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach (MovieListModel movie in movie_list)
        {
            Console.WriteLine($"{movie}\n");
        }
    }

    static public void Get_Movie_Names()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach(MovieListModel movie in movie_list)
        {
            Console.WriteLine($"ID: {movie.Id}| Name: {movie.Name}\n");
        }
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
        Console.WriteLine("Current list of movies: ");
        Get_Movie_Names();
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
                Get_Movie_Names();
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
        Console.WriteLine("Current list of movies:\n");
        Get_Movie_Names();
        Console.WriteLine();
        Console.WriteLine("Which movie would you like to remove? (please provide only the ID)");
        bool correct_input = false;
        while (!correct_input) 
        {
            try
            {
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
                }
            }

            catch
            {
                Console.WriteLine("Invalid input, only numbers are accepted");
            }


        }
    }
}
