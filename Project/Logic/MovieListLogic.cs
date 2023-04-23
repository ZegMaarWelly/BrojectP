class MovieListLogic
{
	private List<MovieListModel> _movies;


	public MovieListLogic()
	{
		_movies = MovieListAccess.LoadAll();
	}

	public List<MovieListModel> Return_Movie_List()
	{
		return _movies;
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

	public static int Find_Next_ID()
	{
		return MovieListAccess.LoadAll().Select(a => a.Id).Max() + 1;
	}
}