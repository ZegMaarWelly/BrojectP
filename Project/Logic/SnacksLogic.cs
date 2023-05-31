class SnacksLogic
{
    private List<SnackModel> _snacks;


    public SnacksLogic()
    {
        _snacks = SnacksAccess.LoadAll();
    }

    public List<SnackModel> Return_Snack_List()
    {
        _snacks = SnacksAccess.LoadAll();
        return _snacks;
    }
    
    //returns a list of snacks based on argumnent
    public List<SnackModel> Return_Snack_List_Based_On_Type(string type)
    {
        List<SnackModel> snack_list = new();
        foreach (SnackModel snack in _snacks)
        {
            if (snack.Type_Of_Food == type)
            {
                snack_list.Add(snack);
            }
        }
        return snack_list;
    }

    //Adds one snack to the list.
    public void Add_To_List(SnackModel snack)
    {
        _snacks.Add(snack);
        SnacksAccess.WriteAll(_snacks);
    }

    public void Update_Snack_ID()
    {
        List<SnackModel> snacks = SnacksAccess.LoadAll();
        for (int i = 0; i < snacks.Count; i++)
        {
            snacks[i].ID = i + 1;
        }
        SnacksAccess.WriteAll(snacks);
    }

    public static int Find_Next_ID()
    {
        return SnacksAccess.LoadAll().Select(a => a.ID).Max() + 1;
    }

    public SnackModel Find_Snack_ID(int id)
    {
        // Loops through the snack list and finds the SnackModel based on method's argument
        foreach (SnackModel snack in _snacks)
        {
            if (snack.ID == id )
            {
                return snack;
            }
        }
        return null;
    }

    public SnackModel Find_Snack(string name)
    {
        foreach (SnackModel snack in _snacks)
        {
            if (snack.Name == name)
            {
                return snack;
            }
        }
        return null;
    }


    //Deletes one item from the list.
    public void Delete_From_List(SnackModel snack)
    {
        _snacks.Remove(snack);
        SnacksAccess.WriteAll(_snacks);
    }

    //Changes the value of the Name based on an argument.
    public void Change_Name_Snack(string value, SnackModel snack)
    {
      
        snack.Name = value;
        int snackindex = _snacks.IndexOf(snack);
        _snacks[snackindex] = snack;
        SnacksAccess.WriteAll(_snacks);

    }
    //Changes the value of the Price based on an argument.
    public void Change_Price_Snack(double value, SnackModel snack)
    {
        snack.Price = value;
        int snackindex = _snacks.IndexOf(snack);
        _snacks[snackindex] = snack;
        SnacksAccess.WriteAll(_snacks);

    }
    //Changes the value of the Type based on an argument.
    public void Change_Type_Snack(string value, SnackModel snack)
    {
        snack.Type_Of_Food = value;
        int snackindex = _snacks.IndexOf(snack);
        _snacks[snackindex] = snack;
        SnacksAccess.WriteAll(_snacks);

    }
    //Changes the value of the Allergy based on an argument.
    public void Change_Allergy_Snack(string value, SnackModel snack)
    {
        snack.Allergies = value;
        int snackindex = _snacks.IndexOf(snack);
        _snacks[snackindex] = snack;
        SnacksAccess.WriteAll(_snacks);

    }
}





