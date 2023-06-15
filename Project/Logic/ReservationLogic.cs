public class ReservationLogic
{
    private List<ReservationModel> _reservations;


    public string File_Name { get; set; }
    public ReservationLogic(string name)
    {
        File_Name = $"reservations_of_{name}";
        _reservations = ReservationAccess.LoadAll(File_Name);
    }

    public List<ReservationModel> Return_Reservation_List()
    {
        return _reservations;
    }

    public void Add_To_List(ReservationModel reservation)
    {
        _reservations.Add(reservation);
        ReservationAccess.WriteAll(_reservations, File_Name);
    }
    public void Delete_From_List(ReservationModel reservation)
    {
        _reservations.Remove(reservation);
        ReservationAccess.WriteAll(_reservations, File_Name);
    }

    //loops through the reservation list and check if they overlap or not.
    public bool Overlapping_Reservation(RunningMovieModel selected_movie)
    {
        bool overlapping = false;
        var begin_movie = selected_movie.Begin_Time;
        var end_movie = selected_movie.End_Time;
        foreach(var reservation in _reservations)
        {
            var begin_reservation = reservation.Running_Movie.Begin_Time;
            var end_reservation = reservation.Running_Movie.End_Time;
            if (begin_movie < end_reservation && end_movie > begin_reservation)
            {
                overlapping = true;
            }
        }
        return overlapping;
    }










}
