﻿using ConsoleTables;

static class MenuSnack
{
    static private SnacksLogic snacksLogic = Factory.snacksLogic;
    static public  ShoppingCartLogic shoppingcartLogic = Factory.shoppingcartLogic;
    static public void Start()
    {
        Console.ForegroundColor= ConsoleColor.DarkGreen;
        Console.WriteLine("\r\n  ___              _     __  __              \r\n / __|_ _  __ _ __| |__ |  \\/  |___ _ _ _  _ \r\n \\__ \\ ' \\/ _` / _| / / | |\\/| / -_) ' \\ || |\r\n |___/_||_\\__,_\\__|_\\_\\ |_|  |_\\___|_||_\\_,_|\r\n                                             \r\n");
        Console.ResetColor();
        Console.WriteLine("What do you want to order?");
        Console.WriteLine("> Enter [1] to order food");
        Console.WriteLine("> Enter [2] to order drinks");
        Console.WriteLine("> Enter [3] to see your shopping cart");
        Console.WriteLine("> Enter [4] screening room test small.");
        User.CurrentUser();

        string input = Console.ReadLine()!;
        Console.Clear();
        if (input == "1")
        { 
            while (true)
            {
                try
                {
                    Food_Menu();
                    Console.WriteLine();
                    Console.WriteLine("What Snack are you going to choose? (Please provide only the ID)\n");
                    string snack_choice = Console.ReadLine()!;
                    int converted_snack = Convert.ToInt32(snack_choice);
                    SnackModel your_snack = snacksLogic.Find_Snack_ID(converted_snack);
                    if (your_snack == null || your_snack.Type_Of_Food == "Drink")
                    {
                        Console.WriteLine("This Snack doesn't exist in the snack list");
                        Thread.Sleep(3000);
                        Console.Clear();
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
                catch
                {
                    Console.WriteLine("Please provide only numbers.\n");
                }
            }
            

        }
        else if (input == "2")
        {
            while (true)
            {
                try
                {
                    Drink_Menu();
                    Console.WriteLine();
                    Console.WriteLine("What are you going to choose \n > Type the name: ");
                    string snack_choice = Console.ReadLine()!;
                    SnackModel your_snack = snacksLogic.Find_Snack(snack_choice);
                    if (your_snack == null || your_snack.Type_Of_Food == "Snack")
                    {
                        Console.WriteLine("This Snack doesn't exist in the snack list");
                        Thread.Sleep(3000);
                        Console.Clear();
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
                catch
                {
                    Console.WriteLine("Please provide only numbers.\n");
                }
            }
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