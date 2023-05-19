class RoomLogic
{
    private List<RoomModel> _rooms;


    public RoomLogic()
    {
        _rooms = RoomAccess.LoadAll();
    }

    public List<RoomModel> Return_Room_List()
    {
        return _rooms;
    }

    public void Add_To_List(RoomModel room)
    {
        _rooms.Add(room);
        RoomAccess.WriteAll(_rooms);
    }

    public RoomModel Find_Room(int id)
    {
        foreach (RoomModel room in _rooms)
        {
            if (room.ID == id)
            {
                return room;
            }
        }
        return null;
    }

    public void Update_list(List<string> scr_room,RoomModel room)
    {
        room.Map = scr_room;
        int roomindex = _rooms.IndexOf(room);
        _rooms[roomindex] = room;
        RoomAccess.WriteAll(_rooms);
    }


}
