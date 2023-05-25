class ReservationLogic
{
    private List<ReservationModel> _reservations;


    public string File_Name { get; set; }
    public ReservationLogic(string name)
    {
        File_Name = $"reservations_of_{name}";
        _reservations = ReservationAccess.LoadAll(File_Name);
    }

    public List<ReservationModel> Return_RunningMovie_List()
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








}
