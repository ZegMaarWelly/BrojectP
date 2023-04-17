static class MenuSnack
{
    static private SnacksLogic snacksLogic = new SnacksLogic();
    static public  ShoppingCartLogic shoppingcartLogic = new ShoppingCartLogic();
    static public void Start()
    {
        Console.WriteLine("What do you want to order?");
        Console.WriteLine("Enter 1 to order food");
        Console.WriteLine("Enter 2 to order drinks");
        Console.WriteLine("Enter 3 to see your shopping cart");
        Console.WriteLine("Enter 4 screening room test small.");

        string input = Console.ReadLine()!;
        Console.Clear();
        if (input == "1")
        {
            Food_Menu();
            Console.WriteLine();
            Console.WriteLine("What Snack are you going to choose \n Type the name: ");
            string snack_choice = Console.ReadLine()!;
            SnackModel your_snack = snacksLogic.Find_Snack(snack_choice);
            if (your_snack == null || your_snack.Type_Of_Food == "Drink")
            {
                Console.WriteLine("This Snack doesn't exist in the snack list");
            }
            else
            {
                Console.WriteLine($"{your_snack.Name} has been added to your shopping cart");
                shoppingcartLogic.AddCountedSnack(your_snack);
                Thread.Sleep(3000);
                Console.Clear();
            }
            Start();

        }
        else if (input == "2")
        {
            Drink_Menu();
            Console.WriteLine();
            Console.WriteLine("What  are you going to choose \n Type the name: ");
            string snack_choice = Console.ReadLine()!;
            SnackModel your_snack = snacksLogic.Find_Snack(snack_choice);
            if (your_snack == null || your_snack.Type_Of_Food == "Snack")
            {
                Console.WriteLine("This Snack doesn't exist in the snack list");
                Start();
            }
            else
            {
                Console.WriteLine($"{your_snack.Name} has been added to your shopping cart");
                shoppingcartLogic.AddCountedSnack(your_snack);
                Thread.Sleep(3000);
                Console.Clear();
            }
            Start();
        }
        else if(input == "3")
        {
            ShoppingCart.Start();
        }
        else if(input == "4")
        {
            ScreeningRoom.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }


    }

    static public void Food_Menu()
    {
        List<SnackModel> snack_list = snacksLogic.Return_Snack_List_Based_On_Type("Snack");
        int snack_number = 1;
        foreach (SnackModel snack in snack_list)
        {
            Console.WriteLine($"{snack_number}|{snack.Name}| ${snack.Price}");
            snack_number += 1;
        }
                
    }

    static public void Drink_Menu()
    {
        List<SnackModel> snack_list = snacksLogic.Return_Snack_List_Based_On_Type("Drink");
        int snack_number = 1;
        foreach (SnackModel snack in snack_list)
        {
            Console.WriteLine($"{snack_number}|{snack.Name}| ${snack.Price}");
            snack_number += 1;
        }

    }
}