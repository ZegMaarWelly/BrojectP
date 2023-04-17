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





}
