using System;

static class AdminManageMovie
{

    static private RoomLogic roomLogic = new RoomLogic();
    static public void Start()
    {
        Get_Room_List();

    }

    static public void Get_Room_List()
    {
        List<RoomModel> room_list = roomLogic.Return_Room_List();
        foreach (RoomModel room in room_list)
        {
            Console.WriteLine(room);
        }
    }

    
}