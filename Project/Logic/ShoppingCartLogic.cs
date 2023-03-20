using System.Xml.Linq;

class ShoppingCartLogic
{
    private List<CountedSnackModel> _shoppingcart;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    public ShoppingCartLogic()
    {
        _shoppingcart = new();
    }


    public List<CountedSnackModel> Return_Counted_Snack_List()
    {
        return _shoppingcart;
    }
    public CountedSnackModel Find_Counted_Snack(SnackModel your_snack)
    {
        // Loops through the snack list and finds the SnackModel based on method's argument
        foreach (CountedSnackModel counted_snack in _shoppingcart)
        {
            if (counted_snack.Snack == your_snack)
            {
                return counted_snack;
            }
        }
        return null;
    }
    public void AddCountedSnack(SnackModel your_snack)
    {
        CountedSnackModel your_counted_snack = Find_Counted_Snack(your_snack);
        if (your_counted_snack != null)
        {
            // If item exist, increase the quantity by 1
            your_counted_snack.Quantity++;
        }
        else
        {
            // If item don't exist, create new counted item.
            CountedSnackModel counted_snack_to_be_added = new(your_snack, 1);
            _shoppingcart.Add(counted_snack_to_be_added);
        }
    }



}





