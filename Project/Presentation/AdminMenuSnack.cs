using ConsoleTables;

static class AdminMenuSnack
{

    static private SnacksLogic snacksLogic = new SnacksLogic();
    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        ___              _     __  __              \r\n   /_\\  __| |_ __ (_)_ _   / __|_ _  __ _ __| |__ |  \\/  |___ _ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  \\__ \\ ' \\/ _` / _| / / | |\\/| / -_) ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |___/_||_\\__,_\\__|_\\_\\ |_|  |_\\___|_||_\\_,_|\r\n                                                                      ");
        Console.ResetColor();
        Console.WriteLine("What do you want to do?");
        Console.WriteLine(" > Enter [1] to add a snack to the snack list");
        Console.WriteLine(" > Enter [2] to remove a snack from the snack list");
        Console.WriteLine(" > Enter [3] to change a value of snacks from the snack list");
        Console.WriteLine(" > Enter [4] see current snack list");
        Console.WriteLine(" > Enter [5] to go back to");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear() ;
            Add_Snack();
        }
        else if (input == "2")
        {
            Console.Clear();
            Remove_Snack();
        }
        else if (input == "3")
        {
            Console.Clear();
            Change_Snack();
        }
        else if (input == "4")
        {
            Console.Clear();
            Get_Snack_List();
            Console.WriteLine(" > Press 'Enter' to continue");
            Console.ReadLine();
            Start();
        }
        else if (input == "5")
        {
            Console.Clear();
            AdminMenu.Start();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            Thread.Sleep(3000);
            Console.Clear();
            Start();
        }
    }

    public static void Update_Snack_ID()
    {
        SnacksLogic snacksLogic = new SnacksLogic();
        snacksLogic.Update_Snack_ID();
    }

    static public void Get_Snack_List()
    {
        List<SnackModel> snack_list = snacksLogic.Return_Snack_List();
        //foreach(SnackModel snack in snack_list)
        //{
        //    Console.WriteLine(snack);
        //}
        ConsoleTable.From<SnackModel>(snack_list).Write(Format.Alternative);
    }

    static public int Get_Snack_ID()
    {
        int next_id = SnacksLogic.Find_Next_ID();
        return next_id;
    }

    static public string Get_Snack_Name()
    {
        Console.WriteLine(" > Your Snack name: ");
        string snack_name = Console.ReadLine()!;
        return snack_name;
    }
    static public double Get_Snack_Price()
    {
        double snack_price = -1;
        bool price_success = false;
        while (!price_success)
        {
            Console.WriteLine(" > Your Price: ");
            try
            {
                snack_price = Convert.ToDouble(Console.ReadLine());
                price_success = true;
                
            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid price; please enter a correct number");
            }
        }
        return snack_price;
    }

    static public string Get_Snack_Type()
    {
        bool type_success = false;
        string type_of_food = "";
        while (!type_success)
        {
            Console.WriteLine(" > Type of food (Snack or Drink): ");
            type_of_food = Console.ReadLine()!;
            if (type_of_food == "Snack" || type_of_food == "Drink")
            {
                type_success = true;
            }
            else
            {
                Console.WriteLine("Invalid Type, try again!");
            }
        }
        return type_of_food;
    }

    static public string Get_Snack_Allergies()
    {
        Console.WriteLine(" > Your Allergies: ");
        string allergies = Console.ReadLine()!;
        if (allergies == "")
        {
            allergies = "none";
        }
        return allergies;

    }
    static public void Add_Snack()
    {
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();

        // Takes the highest ID value in the snack list and returns this number + 1
        int snack_id = Get_Snack_ID();

        //Asks the user for their snack.
        string snack_name = Get_Snack_Name();

        //Asks the user for their price, if the price isn't a double, you get an error message and can try it again.
        double snack_price = Get_Snack_Price();

        //Asks the user for their type of food, if the user input isn't "Snack" or "Drink", it will ask again.
        string type_of_food = Get_Snack_Type();

        //Asks the user for their allergies.
        string allergies = Get_Snack_Allergies();

        // Creates a snack object and asks the user for confirmation
        SnackModel snack = new(snack_id,snack_name,snack_price,type_of_food,allergies);
        while(true)
        {

            SnackModel your_snack = snacksLogic.Find_Snack(snack.Name); 
            Console.WriteLine(snack);
            if (your_snack != null)
            {
                Console.WriteLine("This Snack already exists in the snack list\n\n");
                Start();
            }
            else
            {
                Console.WriteLine(" > Proceed to add the snack to the snack list? (Y/N) ");
                string snack_confirmation = Console.ReadLine()!.ToUpper();
                //If the answer is Yes, it will add it to the list (and also the json file)
                if (snack_confirmation == "Y")
                {
                    Console.Clear();
                    snacksLogic.Add_To_List(snack);
                    Console.WriteLine($"{snack.Name} has succesfully been added to the snack list");
                    //Prints the new snack list
                    Console.WriteLine("New List: ");
                    Get_Snack_List();
                    Console.WriteLine("Press any key to return to the snack menu");
                    Console.ReadKey();

                    Start();
                }
                else if (snack_confirmation == "N")
                {
                    Console.WriteLine("Press any button to return to the snack menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
                else
                {
                    Console.WriteLine("Invalid input, try again!\n");
                }
            }
            
                
               
        }

    }

    static public void Remove_Snack()
    {
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();

        while (true)
        {
            try
            {
                //Asks the user want snack they want to remove
                Console.WriteLine(" > What Snack do you want to remove? (Please provide only numbers)");
                string snack_id = Console.ReadLine()!;
                int converted_id = Convert.ToInt32(snack_id);

                //Finds the Snack if it is present in the snack list, if snack isnt present, you will be sent back to the menu.
                SnackModel your_snack = snacksLogic.Find_Snack_ID(converted_id);
                if (your_snack == null)
                {
                    Console.WriteLine("This ID does not belong to any snacks\nPress any button to return to Admin Movie list menu");
                    Console.ReadKey();
                    Console.Clear();
                    Start();
                }
                else
                {
                    //Asks the user for confirmation, If the answer is yes, it will delete it from the list. If the answer is no, you will be sent back to the menu.
                    Console.WriteLine($" > Are you sure you want to remove the {your_snack.Name}? (Y/N)");
                    string snack_confirmation = Console.ReadLine()!.ToUpper();
                    if (snack_confirmation == "Y")
                    {
                        snacksLogic.Delete_From_List(your_snack);
                        Console.WriteLine($"{your_snack.Name} has succesfully been deleted from the snack list");
                        //Prints the new snack list
                        Console.WriteLine("New List: ");
                        Update_Snack_ID();
                        Get_Snack_List();
                        Console.WriteLine("Press any key to return to the snack menu");
                        Console.ReadKey();

                        Start();
                    }
                    else if (snack_confirmation == "N")
                    {
                        Console.WriteLine("Press any button to go back to the snack menu");
                        Console.ReadKey();
                        Console.Clear();
                        Start();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again!");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid input, only numbers are accepted");
            }
        }
    }

    static public void Change_Snack()
    {
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();

        while (true)
        {
            try
            {
                //Asks the user want snack they want to change
                Console.WriteLine(" > What Snack do you want to change? (Please provide the ID in numbers)");
                string snack_id = Console.ReadLine()!;
                int converted_id = Convert.ToInt32(snack_id);

                //Finds the Snack if it is present in the snack list, if snack isnt present, you will be sent back to the menu.
                SnackModel your_snack = snacksLogic.Find_Snack_ID(converted_id);
                if (your_snack == null)
                {
                    Console.WriteLine("This Snack doesn't exist in the snack list");
                    Start();
                }
                else
                {
                    while (true)
                    {
                        //Asks the user which value they want to change of the snack.
                        Console.WriteLine(your_snack);
                        Console.WriteLine("What value do you want to change? \n You have the options to choose the following values.");
                        Console.WriteLine(" > Enter [1] to change the name");
                        Console.WriteLine(" > Enter [2] to change the price");
                        Console.WriteLine(" > Enter [3] to change the type of food");
                        Console.WriteLine(" > Enter [4] to change the allergies");
                        Console.WriteLine(" > Enter [5] to go back to the menu");
                        string change_snack_choice = Console.ReadLine()!;
                        if (change_snack_choice == "1")
                        {
                            string value_to_be_changed = Get_Snack_Name();
                            snacksLogic.Change_Name_Snack(value_to_be_changed, your_snack);
                        }
                        else if (change_snack_choice == "2")
                        {
                            double value_to_be_changed = Get_Snack_Price();
                            snacksLogic.Change_Price_Snack(value_to_be_changed, your_snack);
                        }
                        else if (change_snack_choice == "3")
                        {
                            string value_to_be_changed = Get_Snack_Type();
                            snacksLogic.Change_Type_Snack(value_to_be_changed, your_snack);
                        }
                        else if (change_snack_choice == "4")
                        {
                            string value_to_be_changed = Get_Snack_Allergies();
                            snacksLogic.Change_Allergy_Snack(value_to_be_changed, your_snack);
                        }
                        else if (change_snack_choice == "5")
                        {
                            Console.WriteLine("Going back to the menu");
                            Start();
                        }


                        //Prints the new snack list
                        Console.WriteLine("Snack succesfully changed");
                        Console.WriteLine("New List: ");
                        Get_Snack_List();
                        Console.WriteLine();
                        Start();
                    }


                }
            }
            catch
            {
                Console.WriteLine("Invalid input, only numbers are accepted.\n");
            }
            }
        }
}
