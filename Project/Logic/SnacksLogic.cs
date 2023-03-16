using System.Xml.Linq;

class SnacksLogic
{
    private List<SnackModel> _snacks;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public SnackModel? CurrentSnacks { get; private set; }

    public SnacksLogic()
    {
        _snacks = SnacksAccess.LoadAll();
    }

    public List<SnackModel> Return_Snack_List()
    {
        return _snacks;
    }

    public bool Add_To_List(SnackModel snack)
    {
        bool duplicated_snack = Check_For_Duplicates(snack.Name);
        if(!duplicated_snack)
        {
            _snacks.Add(snack);
            SnacksAccess.WriteAll(_snacks);
            return true;

        }
        else
        {
            return false;
        }
    }


    public SnackModel Find_Snack(string name)
    {
        // Loops through the snack list and finds the SnackModel based on method's argument
        foreach (SnackModel snack in _snacks)
        {
            if (snack.Name == name)
            {
                return snack;
            }
        }
        return null;
    }
    public bool Check_For_Duplicates(string name)
    {
        foreach(SnackModel snack in _snacks)
        {
            if(snack.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    public void Delete_From_List(SnackModel snack)
    {
        _snacks.Remove(snack);
        SnacksAccess.WriteAll(_snacks);
    }

    public void Change_String_Snack(SnackModel snack, string snack_value, string value_to_be_canged)
    {
        snack_value = value_to_be_canged;
        _snacks.Remove(snack);
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);

    }
}





