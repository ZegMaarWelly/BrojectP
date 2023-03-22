static class ShoppingCart
{
    
    static private List<CountedSnackModel> inventory = MenuSnack.shoppingcartLogic.Return_Counted_Snack_List();
    static public void Show_Shopping_Cart()
    {
        foreach(var CountedSnackModel in inventory)
        {
            Console.WriteLine(CountedSnackModel);
        }
        MenuSnack.Start();
        Console.WriteLine();
    }

}