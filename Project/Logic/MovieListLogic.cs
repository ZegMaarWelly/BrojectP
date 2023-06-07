class MovieListLogic
{
	private List<MovieListModel> _movies;


	public MovieListLogic()
	{
		_movies = MovieListAccess.LoadAll();
	}

	// Returns all the movie's information based on the MovieListModel, also loads the list every time so it is updated in every time it needs to be displayed
	public List<MovieListModel> Return_Movie_List()
	{
		_movies = MovieListAccess.LoadAll();
		return _movies;
	}

	// Checks the genres to see if a certain string is in the list
	public List<MovieListModel> Return_By_Genre(string genre)
	{
		List<MovieListModel> movies = new List<MovieListModel>();
		foreach (var movie in _movies)
		{
			if (movie.Genre.Contains(genre))
			{
				movies.Add(movie);
			}
		}
		return movies;
	}

	public void Add_To_List(MovieListModel movie)
	{
		_movies.Add(movie);
		MovieListAccess.WriteAll(_movies);
	}

	public void Delete_From_List(MovieListModel movie)
	{
		_movies.Remove(movie);
		MovieListAccess.WriteAll(_movies);
	}

	public MovieListModel Find_Movie(string name)
	{
		foreach (MovieListModel movie in _movies)
		{
			if (movie.Name == name)
			{
				return movie;
			}
		}
		return null;
	}

	public MovieListModel Find_Movie_ID(int id)
	{
		foreach (MovieListModel movie in _movies)
		{
			if (movie.Id == id)
			{
				return movie;
			}
		}
		return null;
	}

	// Finds highest ID in the list and returns this value +1
	public static int Find_Next_ID()
	{
		return MovieListAccess.LoadAll().Select(a => a.Id).Max() + 1;
	}

	public void Update_Movie_Name(string value, MovieListModel movie)
	{
		movie.Name = value;
		int movieindex = _movies.IndexOf(movie);
		_movies[movieindex] = movie;
		MovieListAccess.WriteAll(_movies);
	}

	public void Update_Movie_Genre(string value, MovieListModel movie)
	{
		movie.Genre= value;
        int movieindex = _movies.IndexOf(movie);
        _movies[movieindex] = movie;
        MovieListAccess.WriteAll(_movies);
    }

    public void Update_Movie_Length(int value, MovieListModel movie)
    {
        movie.Length = value;
        int movieindex = _movies.IndexOf(movie);
        _movies[movieindex] = movie;
        MovieListAccess.WriteAll(_movies);
    }

    public void Update_Movie_Age(int value, MovieListModel movie)
    {
        movie.Age = value;
        int movieindex = _movies.IndexOf(movie);
        _movies[movieindex] = movie;
        MovieListAccess.WriteAll(_movies);
    }

    public void Update_Movie_Labels(string value, MovieListModel movie)
    {
        movie.Labels = value;
        int movieindex = _movies.IndexOf(movie);
        _movies[movieindex] = movie;
        MovieListAccess.WriteAll(_movies);
    }

	// Provides movies with ID's based on their position on the list
	public void Update_Movie_ID()
	{
        List<MovieListModel> movies = MovieListAccess.LoadAll();
		for (int i = 0; i < movies.Count; i++)
		{
			movies[i].Id = i + 1;
		}
		MovieListAccess.WriteAll(movies);
    }
}