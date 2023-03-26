static class ShoppingCart
{
    
    static private List<CountedSnackModel> inventory = MenuSnack.shoppingcartLogic.Return_Counted_Snack_List();
    static public void Show_Shopping_Cart()
    {
        foreach(var CountedSnack in inventory)
        {
            Console.WriteLine($"{CountedSnack}| $ {CountedSnack.Snack.Price * CountedSnack.Quantity}");
        }
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"                  Total: $ {MenuSnack.shoppingcartLogic.Get_Total_Price()}");
        MenuSnack.Start();
        Console.WriteLine();
    }

}