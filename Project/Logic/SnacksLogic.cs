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

    public void Add_To_List(SnackModel snack)
    {
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);
    }


    public SnackModel Find_Snack(string name)
    {
        // Loops through the snack list and finds the SnackModel based on method's argument
        foreach (SnackModel snack in _snacks)
        {
            if (snack.Name == name )
            {
                return snack;
            }
        }
        return null;
    }


    public void Delete_From_List(SnackModel snack)
    {
        _snacks.Remove(snack);
        SnacksAccess.WriteAll(_snacks);
    }

    public void Change_Name_Snack(string value, SnackModel snack)
    {
        snack.Name = value;
        _snacks.Remove(snack);
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);

    }
    public void Change_Price_Snack(double value, SnackModel snack)
    {
        snack.Price = value;
        _snacks.Remove(snack);
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);

    }
    public void Change_Type_Snack(string value, SnackModel snack)
    {
        snack.Type_Of_Food = value;
        _snacks.Remove(snack);
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);

    }
    public void Change_Allergy_Snack(string value, SnackModel snack)
    {
        snack.Allergies = value;
        _snacks.Remove(snack);
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);

    }
}





