static class AdminMovieList
{
    static private MovieListLogic movieLogic = new MovieListLogic();
    static public void Start()
    {
        Console.WriteLine("What would you like to do?\n1) Add a movie to the list of movies\n2) Remove a movie from the list\n3) See the current list of movies\n");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Add_Movie();
        }
        else if (input == "2") 
        {
            Console.WriteLine("Not yet implemented");
            Start();
        }
        else if (input == "3")
        {
            Get_Movie_list();
            Start();
        }
        else
        {
            Console.WriteLine("Invalid input\n\n");
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

    static public string New_Movie_Name()
    {
        Console.WriteLine("Enter the name of the movie: ");
        string movie_name = Console.ReadLine()!;
        return movie_name;
    }

    static public string New_Movie_Genre()
    {
        Console.WriteLine("Enter the genre(s) of the movie: ");
        string movie_genre = Console.ReadLine()!;
        return movie_genre;
    }

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
        Console.WriteLine("Current list of movies: ");
        Get_Movie_list();
        Console.WriteLine();
        string movie_name = New_Movie_Name();
        string movie_genre = New_Movie_Genre();
        int movie_length = New_Movie_Length();
        int movie_age = New_Movie_Age();
        string movie_labels = New_Movie_Labels();

        MovieListModel movie = new(movie_name, movie_genre, movie_length, movie_age, movie_labels);
        while (true)
        {
            MovieListModel new_movie = movieLogic.Find_Movie(movie.Name);
            Console.WriteLine(movie);
            if (new_movie != null)
            {
                Console.WriteLine("This movie is already in the list of movies. Returning to main menu... \n");
                Start();
            }
            else
            {
                movieLogic.Add_To_List(movie);
                Console.WriteLine($"Movie {movie.Name} has succesfully been added to the list of movies");
                Console.WriteLine("Current list of movies:\n");
                Get_Movie_list();
                Console.WriteLine();
                Start();
            }
        }
    }
}
