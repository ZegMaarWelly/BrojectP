static class AdminMovieList
{
    static private MovieListLogic movieLogic = new MovieListLogic();
    static public void Start()
    {
        Console.WriteLine("What would you like to do?\n1) Add a movie to the list of movies\n2) Remove a movie from the list\n3) See the current list of movies\n4) Return to the main menu")
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
                View_List();
                break;
            case "4":
                AdminMenu.Start();
                break;
            default:
                Console.WriteLine("Invalid input");
                Start();
        }
    }

    static public void Get_Movie_list()
    {
        List<MovieListModel> movie_list = movieLogic.Return_Movie_List();
        foreach(MovieListModel movie in movie_list)
        {
            Console.WriteLine(movie);
        }
    }

    static public void New_Movie_Name()
    {
        Console.WriteLine("Enter the name of the movie: ")
        string movie_name = Console.ReadLine()!;
        return movie_name;
    }

    static public void New_Movie_Genre()
    {
        Console.WriteLine("Enter the genre(s) of the movie: ")
        string movie_genre = Console.ReadLine()!;
        return movie_genre;
    }

    static public void New_Movie_Length()
    {
        bool correct_price = false;
        while (!correct_price)
        {
            Console.WriteLine("Enter the length of the movie in minutes in numbers: ")
            try
            {
                movie_length = Convert.ToInt32(Console.ReadLine());
                correct_price = true;
            }
            catch
            {
                Console.WriteLine("Please enter only numbers")
            }
        }
        return movie_length;
    }

    static public void New_Movie_Age()
    {
        bool correct_age = false;
        while (!correct_age)
        {
            Console.WriteLine("Enter the minumum age of the movie goer for this movie: ")
            try
            {
                movie_age = Convert.ToInt32(Console.ReadLine());
                correct_age = true;
            }
            catch
            {
                Console.WriteLine("Please enter only numbers")
            }
        }
        return movie_age;
    }

    static public void New_Movie_Labels()
    {
        Console.WriteLine("Please enter the labels you would like to attach to this movie: ");
        string movie_labels = Console.ReadLine()!;
        if (movie_labels == "")
        {
            movie_labels = "None";
        }
        return movie_labels;
    }

    static public void Add_movie()
    {
        Console.WriteLine("Current list of movies: ")
        Get_Movie_list();
        Console.WriteLine();

        string movie_name = New_Movie_Name();
        string movie_genre = New_Movie_Genre();
        string movie_length = New_Movie_Length();
        string movie_age = New_Movie_Age();
        string movie_labels = New_Movie_Labels();

        MovieListModel movie = new(movie_name, movie_genre, movie_length, movie_age, movie_labels);
        while (true)
        {
            MovieListModel new_movie = movieLogic.Find_Movie(movie.Name);
            Console.WriteLine(movie);
            if (new_movie != null)
            {
                Console.WriteLine("This movie is already in the list of movies. Returning to main menu... \n")
                Start();
            }
            else
            {
                Console.WriteLine($"Movie {movie.Name} has succesfully been added to the list of movies");
                Console.WriteLine("Current list of movies:\n");
                Get_Movie_list();
                Console.WriteLine();
                Start();
            }
        }
    }
}
