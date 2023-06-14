using ConsoleTables;
using System;

static class MenuSnack
{
    static private SnacksLogic snacksLogic = Factory.snacksLogic;
    static public ShoppingCartLogic shoppingcartLogic = Factory.shoppingcartLogic;
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\r\n  ___              _     __  __              \r\n / __|_ _  __ _ __| |__ |  \\/  |___ _ _ _  _ \r\n \\__ \\ ' \\/ _` / _| / / | |\\/| / -_) ' \\ || |\r\n |___/_||_\\__,_\\__|_\\_\\ |_|  |_\\___|_||_\\_,_|\r\n                                             \r\n");
        Console.ResetColor();
        Console.WriteLine("What do you want to order?");
        Console.WriteLine("> [1] Order food");
        Console.WriteLine("> [2] Order drinks");
        Console.WriteLine("> [3] See your shopping cart");
        User.CurrentUser();

        string input = Console.ReadLine()!;
        Console.Clear();
        if (input == "1")
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   ___         _           ___             _ \r\n  / _ \\ _ _ __| |___ _ _  | __|__  ___  __| |\r\n | (_) | '_/ _` / -_) '_| | _/ _ \\/ _ \\/ _` |\r\n  \\___/|_| \\__,_\\___|_|   |_|\\___/\\___/\\__,_|\r\n                                             ");
            Console.ResetColor();
            Console.WriteLine();
            Food_Menu();
            Console.WriteLine();
            Console.WriteLine("What Snack are you going to choose? (Please provide either the ID or the name)");
            var selected_snack = Console.ReadLine();

            int intInput;
            SnackModel your_snack = null;

            if (int.TryParse(selected_snack, out intInput))
            {
                // User input is an integer
                your_snack = snacksLogic.Find_Snack(intInput);
            }

            if (your_snack == null)
            {
                // Either user input is a string or the integer input didn't match any movie
                your_snack = snacksLogic.Find_Snack(selected_snack);

                if (selected_snack == null)
                {
                    Console.WriteLine("Snack not found\nPress any button to return to the snack menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
            }
            if (your_snack == null || your_snack.Type_Of_Food == "Drink")
            {
                Console.Clear();
                Console.WriteLine("This Snack doesn't exist in the snack list");
                Thread.Sleep(2000);
                Console.WriteLine("Going back...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                int intAmount = 0;
                while(true)
                {
                    Console.WriteLine("How many would you like to order?");
                    string amount = Console.ReadLine();
                    try
                    {
                        intAmount = Convert.ToInt32(amount);
                        if(intAmount < 1)
                        {
                            Console.WriteLine("Number too low");
                        }
                        else
                        {
                            break;
                        }
                    }
                    //Catches any type of exception.
                    catch
                    {
                        Console.WriteLine("Invalid number, please enter a correct number");
                    }
                }
                
                Console.Clear();
                for (int i = 0; i < intAmount; i++)
                {
                    shoppingcartLogic.AddCountedSnack(your_snack);
                }
                Console.WriteLine($"{your_snack.Name} has been added to your shopping cart");
                Thread.Sleep(2000);
                Console.WriteLine("Going back...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Start();

        }
        else if (input == "2")
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("   ___         _           ___      _      _   \r\n  / _ \\ _ _ __| |___ _ _  |   \\ _ _(_)_ _ | |__\r\n | (_) | '_/ _` / -_) '_| | |) | '_| | ' \\| / /\r\n  \\___/|_| \\__,_\\___|_|   |___/|_| |_|_||_|_\\_\\\r\n                                               ");
            Console.ResetColor();
            Console.WriteLine();
            Drink_Menu();
            Console.WriteLine();
            Console.WriteLine("What Drink are you going to choose? (Please provide either the ID or the name)");
            var selected_snack = Console.ReadLine();

            int intInput;
            SnackModel your_snack = null;

            if (int.TryParse(selected_snack, out intInput))
            {
                // User input is an integer
                your_snack = snacksLogic.Find_Snack(intInput);
            }

            if (your_snack == null)
            {
                // Either user input is a string or the integer input didn't match any movie
                your_snack = snacksLogic.Find_Snack(selected_snack);

                if (selected_snack == null)
                {
                    Console.WriteLine("This ID does not belong to any movies\nPress any button to return to Admin Movie list menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
            }
            if (your_snack == null || your_snack.Type_Of_Food == "Snack")
            {
                Console.Clear();
                Console.WriteLine("This Snack doesn't exist in the snack list");
                Thread.Sleep(2000);
                Console.WriteLine("Going back...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                int intAmount = 0;
                while (true)
                {
                    Console.WriteLine("How many would you like to order?");
                    string amount = Console.ReadLine();
                    try
                    {
                        intAmount = Convert.ToInt32(amount);
                        if (intAmount < 1)
                        {
                            Console.WriteLine("Number too low");
                        }
                        else
                        {
                            break;
                        }
                    }
                    //Catches any type of exception.
                    catch
                    {
                        Console.WriteLine("Invalid number, please enter a correct number");
                    }
                }
                Console.Clear();
                for (int i = 0; i < intAmount; i++)
                {
                    shoppingcartLogic.AddCountedSnack(your_snack);
                }
                Console.WriteLine($"{your_snack.Name} has been added to your shopping cart");
                Thread.Sleep(2000);
                Console.WriteLine("Going back...");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Start();
        }
        else if (input == "3")
        {
            ShoppingCart.Start();
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
        //int snack_number = 1;
        //foreach (SnackModel snack in snack_list)
        //{
        //    //Console.WriteLine($"{snack_number}|{snack.Name}| ${snack.Price}");
        //    //snack_number += 1;
        //}
        ConsoleTable.From<SnackModel>(snack_list).Write(Format.Alternative);

    }

    static public void Drink_Menu()
    {
        List<SnackModel> snack_list = snacksLogic.Return_Snack_List_Based_On_Type("Drink");
        //int snack_number = 1;
        //foreach (SnackModel snack in snack_list)
        //{
        //    Console.WriteLine($"{snack_number}|{snack.Name}| ${snack.Price}");
        //    snack_number += 1;
        //}
        ConsoleTable.From<SnackModel>(snack_list).Write(Format.Alternative);

    }

}