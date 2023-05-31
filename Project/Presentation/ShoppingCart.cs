using ConsoleTables;

static class ShoppingCart
{

    static private SnacksLogic snacksLogic = Factory.snacksLogic;
    static private ShoppingCartLogic shoppingcartLogic = Factory.shoppingcartLogic;
    static private List<CountedSnackModel> inventory = shoppingcartLogic.Return_Counted_Snack_List();

    
    // Asks the user what they want to do
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(" __   __              ___ _                  _              ___          _   \r\n \\ \\ / /__ _  _ _ _  / __| |_  ___ _ __ _ __(_)_ _  __ _   / __|__ _ _ _| |_ \r\n  \\ V / _ \\ || | '_| \\__ \\ ' \\/ _ \\ '_ \\ '_ \\ | ' \\/ _` | | (__/ _` | '_|  _|\r\n   |_|\\___/\\_,_|_|   |___/_||_\\___/ .__/ .__/_|_||_\\__, |  \\___\\__,_|_|  \\__|\r\n                                  |_|  |_|         |___/                    ");
        Console.ResetColor();
        Console.WriteLine();
        Show_Shopping_Cart();
        Console.WriteLine(" > Press [1] to get more snacks");
        Console.WriteLine(" > Press [2] to delete snacks");
        Console.WriteLine(" > Press [3] to confirm your order");
        var choice = Console.ReadLine()!;
        Console.Clear();
        if(choice == "1")
        {
            MenuSnack.Start();
        }
        else if (choice == "2")
        {
            Delete_Snack();
        }
        else if (choice == "3")
        {
            Console.WriteLine("Order confirmed");
        }
        else
        {
            Start();
        }
    }
    
    
    // Prints the shopping Cart
    static public void Show_Shopping_Cart()
    {
        
        Console.WriteLine("-");
        foreach (var CountedSnack in inventory)
        {
            Console.WriteLine($"{CountedSnack}| $ {CountedSnack.Snack.Price * CountedSnack.Quantity}");
        }
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine($"                  Total: $ {MenuSnack.shoppingcartLogic.Get_Total_Price()}");
        Console.WriteLine();
        
    }

    static public void Delete_Snack()
    {
        Show_Shopping_Cart();
        Console.WriteLine("What Snack do you want to delete?");
        var snack_to_be_deleted = Console.ReadLine()!;
        //Finds the Snack if it is present in the snack list, if snack isnt present, you will be sent back to the menu.
        CountedSnackModel your_counted_snack = shoppingcartLogic.Find_Counted_Snack_By_Name(snack_to_be_deleted);
        if (your_counted_snack == null)
        {
            Console.WriteLine("This Snack doesn't exist in your shopping cart");
            Console.WriteLine("");
            Start();
        }
        else
        {
            
            // Removes the snack if the quantity is 1, if not, then it will ask the user how much.
            if(your_counted_snack.Quantity == 1)
            {
                shoppingcartLogic.Remove_Counted_Snack(your_counted_snack);
                Console.WriteLine($"You have succesfully removed one {your_counted_snack.Snack.Name} of your list");
                Thread.Sleep(4000);
                Console.Clear();
                Start();
            }
            else
            {
                // Asks the user how much they want to remove.
                int quantity_to_be_deleted = Get_Quantity();

                // Removes the selected snack if the given quantity is smaller than the available quantity
                if (quantity_to_be_deleted > your_counted_snack.Quantity)
                {
                    Console.WriteLine($"Your snack has not been deleted from your inventory");
                    Console.WriteLine($"You tried removing {quantity_to_be_deleted}, but you only have {your_counted_snack.Quantity}");
                    Thread.Sleep( 8000 );
                    Start();

                }
                else
                {
                    shoppingcartLogic.Decrease_Quantity(your_counted_snack, quantity_to_be_deleted);
                    Console.WriteLine($"You have decreased your quantity of {your_counted_snack.Snack.Name}");
                    Thread.Sleep( 8000 );
                    Start();

                }
               

            }
            
        }
    }


    // Asks the user how much they want to remove.
    static public int Get_Quantity()
    {

        int quantity = -1;
        bool success = false;
        while (!success)
        {
            Console.WriteLine("Your amount:  ");
            try
            {
                quantity = Convert.ToInt32(Console.ReadLine());
                success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid amount; please enter a correct number");
            }
        }
        return quantity;
    }

}