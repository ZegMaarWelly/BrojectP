
public class ShoppingCartLogic
{
    private List<CountedSnackModel> _shoppingcart;

    
    public ShoppingCartLogic()
    {
        _shoppingcart = new();
    }

  

    //just returns the shopping Cart list.
    public List<CountedSnackModel> Return_Counted_Snack_List()
    {
        return _shoppingcart;
    }
    
    
    //Finds the Counted Snack based on the SnackModel argument..
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

    //Finds the Counted Snack based on the Snack name
    public CountedSnackModel Find_Counted_Snack_By_Name(string name)
    {
        // Loops through the snack list and finds the SnackModel based on method's argument
        foreach (CountedSnackModel counted_snack in _shoppingcart)
        {
            if (counted_snack.Snack.Name == name)
            {
                return counted_snack;
            }
        }
        return null;

    }
    

    // Adds a counted snack to the shopping cart
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

    // Removes a counted snack from the shopping cart
    public void Remove_Counted_Snack(CountedSnackModel your_counted_snack)
    {
        _shoppingcart.Remove(your_counted_snack);
    }

    // Decreases the quanity of a counted_snack based on the given quantity in the argument
    public void Decrease_Quantity(CountedSnackModel your_counted_snack, int quantity)
    {
        var old_counted_snack = your_counted_snack;
        your_counted_snack.Quantity = your_counted_snack.Quantity - quantity;
        if(your_counted_snack.Quantity == 0)
        {
            Remove_Counted_Snack(your_counted_snack);
        }
        else
        {
            int snackindex = _shoppingcart.IndexOf(old_counted_snack);
            _shoppingcart[snackindex] = your_counted_snack;
        }

    }
   
    // Get a double of the total price   of all the items in  the shopping cart
    public double Get_Total_Price()
    {
        double total_price = 0;
        foreach(CountedSnackModel CountedSnack in _shoppingcart)
        {
            double snack_price = CountedSnack.Snack.Price * CountedSnack.Quantity ;
            total_price += snack_price;
        }
        return total_price;
    }


    //Empties the shopping cart
    public void Empty_Cart()
    {
        _shoppingcart.Clear();
    }




}





