class RunningMovieLogic
{
    private List<RunningMovieModel> _runningmovies;


    public string File_Name { get; set; }
    public RunningMovieLogic(string name)
    {
        File_Name = name;
        _runningmovies = RunningMovieAccess.LoadAll(File_Name);
    }

    public List<RunningMovieModel> Return_RunningMovie_List()
    {
        return _runningmovies;
    }

    // Returns a list of running movies where the  movie name is the same as the given argument.
    public List<RunningMovieModel> Return_RunningMovie_List_Based_On_Movie(string movie)
    {
        List<RunningMovieModel> runningmovie_list = new();
        foreach (RunningMovieModel runningmovie in _runningmovies)
        {
            if (runningmovie.Movie.Name == movie)
            {
                runningmovie_list.Add(runningmovie);
            }
        }
        return runningmovie_list;
    }

    //Adds one item to the list.
    public void Add_To_List(RunningMovieModel runningmovie)
    {
        _runningmovies.Add(runningmovie);
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);
    }

    //Deletes one item from the list.
    public void Delete_From_List(RunningMovieModel runningmovie)
    {
        _runningmovies.Remove(runningmovie);
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);
    }

    // Changes the movie to the given argument
    public void Change_Movie(MovieListModel movie, RunningMovieModel runningmovie)
    {
        int runningmovieindex = _runningmovies.IndexOf(runningmovie);
        runningmovie.Movie = movie;
        _runningmovies[runningmovieindex] = runningmovie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);

    }

    public void Change_Room(RoomModel room, RunningMovieModel runningmovie)
    {
        int runningmovieindex = _runningmovies.IndexOf(runningmovie);
        runningmovie.Room = room ;
        _runningmovies[runningmovieindex] = runningmovie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);

    }
   


    public void Change_Date(DateTime date, RunningMovieModel runningmovie)
    {
        int runningmovieindex = _runningmovies.IndexOf(runningmovie);
        runningmovie.Date = date;
        _runningmovies[runningmovieindex] = runningmovie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);

    }


    // Changes the begin time to the given argument.
    public void Change_Begin_Time(DateTime begin_time , RunningMovieModel runningmovie)
    {

        
        int runningmovieindex = _runningmovies.IndexOf(runningmovie);
        runningmovie.Begin_Time = begin_time;
        _runningmovies[runningmovieindex] = runningmovie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);


    }


    // Changes the end time to the given argument.
    public void Change_End_Time(DateTime end_time, RunningMovieModel runningmovie)
    {

        
        int runningmovieindex = _runningmovies.IndexOf(runningmovie);
        runningmovie.End_Time = end_time;
        _runningmovies[runningmovieindex] = runningmovie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);

    }

    
    //Changes the old running movie to the new running movie.
    public void Change_Running_Movie(RunningMovieModel old_movie, RunningMovieModel new_movie)
    {
        int runningmovieindex = _runningmovies.IndexOf(old_movie);
        _runningmovies[runningmovieindex] = new_movie;
        RunningMovieAccess.WriteAll(_runningmovies, File_Name);
    }

    public void Change_Running_Movie_From_RoomIDMovieStarDate(RunningMovieModel new_runningmovie)
    {
        RunningMovieModel movie_to_be_changed = null;
        bool change_success = false;
        foreach(RunningMovieModel runningmovie in _runningmovies)
        {
            if(runningmovie.Begin_Time == new_runningmovie.Begin_Time && runningmovie.Movie.Name == new_runningmovie.Movie.Name
                && runningmovie.Room.ID == new_runningmovie.Room.ID)
            {
                movie_to_be_changed = runningmovie;
                change_success = true;
            }
        }

        if(change_success)
        {
            int runningmovieindex = _runningmovies.IndexOf(movie_to_be_changed!);
            _runningmovies[runningmovieindex] = new_runningmovie;
            RunningMovieAccess.WriteAll(_runningmovies, File_Name);
        }
    }







}
