using ConsoleTables;

public static class AdminMenuSnack
{

    static private SnacksLogic snacksLogic = new SnacksLogic();
    static public void Start()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _       _        ___              _     __  __              \r\n   /_\\  __| |_ __ (_)_ _   / __|_ _  __ _ __| |__ |  \\/  |___ _ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  \\__ \\ ' \\/ _` / _| / / | |\\/| / -_) ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |___/_||_\\__,_\\__|_\\_\\ |_|  |_\\___|_||_\\_,_|\r\n                                                                      ");
        Console.ResetColor();
        Console.WriteLine("What do you want to do?");
        Console.WriteLine(" > [1] Add a snack to the snack list");
        Console.WriteLine(" > [2] Remove a snack from the snack list");
        Console.WriteLine(" > [3] Change a value of snacks from the snack list");
        Console.WriteLine(" > [4] See current snack list");
        Console.WriteLine(" > [5] Go back ");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("    _      _       _        ___              _     __  __              \r\n   /_\\  __| |_ __ (_)_ _   / __|_ _  __ _ __| |__ |  \\/  |___ _ _ _  _ \r\n  / _ \\/ _` | '  \\| | ' \\  \\__ \\ ' \\/ _` / _| / / | |\\/| / -_) ' \\ || |\r\n /_/ \\_\\__,_|_|_|_|_|_||_| |___/_||_\\__,_\\__|_\\_\\ |_|  |_\\___|_||_\\_,_|\r\n                                                                      ");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("Current List: ");
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

    static public void Get_Snack_List()
    {
        List<SnackModel> snack_list = snacksLogic.Return_Snack_List();
        //foreach(SnackModel snack in snack_list)
        //{
        //    Console.WriteLine(snack);
        //}
        ConsoleTable.From<SnackModel>(snack_list).Write(Format.Alternative);
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
        if (allergies == ""|| allergies == " ")
        {
            allergies = "none";
        }
        return allergies;

    }

    static public int Get_Snack_ID()
    {
        int next_id = SnacksLogic.Find_Next_ID();
        return next_id;
    }
    static public void Add_Snack()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("    _      _    _   ___              _   \r\n   /_\\  __| |__| | / __|_ _  __ _ __| |__\r\n  / _ \\/ _` / _` | \\__ \\ ' \\/ _` / _| / /\r\n /_/ \\_\\__,_\\__,_| |___/_||_\\__,_\\__|_\\_\\\r\n                                         ");
        Console.ResetColor();
        Console.WriteLine("");
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();

        //Asks the user for their snack.
        string snack_name = Get_Snack_Name();

        //Asks the user for their price, if the price isn't a double, you get an error message and can try it again.
        double snack_price = Get_Snack_Price();

        //Asks the user for their type of food, if the user input isn't "Snack" or "Drink", it will ask again.
        string type_of_food = Get_Snack_Type();

        //Asks the user for their allergies.
        string allergies = Get_Snack_Allergies();
        int id = Get_Snack_ID();

        // Creates a snack object and asks the user for confirmation
        SnackModel snack = new(id,snack_name, snack_price, type_of_food, allergies);
        while (true)
        {

            Console.Clear();
            SnackModel your_snack = snacksLogic.Find_Snack(snack.Name);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("    _      _    _   ___              _   \r\n   /_\\  __| |__| | / __|_ _  __ _ __| |__\r\n  / _ \\/ _` / _` | \\__ \\ ' \\/ _` / _| / /\r\n /_/ \\_\\__,_\\__,_| |___/_||_\\__,_\\__|_\\_\\\r\n                                         ");
            Console.ResetColor();
            Console.WriteLine("");


            if (your_snack != null)
            {
                Console.Clear();
                Console.WriteLine("This Snack already exists in the snack list\n\n");
                Thread.Sleep(1000);
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Console.Clear();
                Start();
            }
            else
            {
                Console.WriteLine(" > Proceed to add the snack to the snack list? (Y/N) ");
                string snack_confirmation = Console.ReadLine()!.ToUpper();
                //If the answer is Yes, it will add it to the list (and also the json file)
                if (snack_confirmation == "Y")
                {
                    snacksLogic.Add_To_List(snack);
                    Console.WriteLine($"\n{snack.Name} has succesfully been added to the snack list\n");
                    Thread.Sleep(2000);
                    Console.WriteLine("New List: ");
                    Get_Snack_List();

                    Console.WriteLine();
                    Console.WriteLine(" > Press 'Enter' to continue");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Going back to menu....");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Start();

                }
                else if (snack_confirmation == "N")
                {
                    Console.WriteLine($"{snack.Name} was not added to the snack list");
                    Thread.Sleep(2000);
                    Console.WriteLine("Going back to menu....");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Start();
                }
                else
                {
                    Console.WriteLine("Invalid input, try again!");
                }
            }



        }

    }

    static public void Remove_Snack()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  ___      _     _         ___              _   \r\n |   \\ ___| |___| |_ ___  / __|_ _  __ _ __| |__\r\n | |) / -_) / -_)  _/ -_) \\__ \\ ' \\/ _` / _| / /\r\n |___/\\___|_\\___|\\__\\___| |___/_||_\\__,_\\__|_\\_\\\r\n                                                ");
        Console.ResetColor();
        Console.WriteLine("");
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();

        //Asks the user want snack they want to remove
        while (true)
        {
            try
            {
                //Asks the user want snack they want to remove
                Console.WriteLine("What snack would you like to remove? (Please provide either the ID or the name of the snack)");
                var for_removal = Console.ReadLine();

                int intInput;
                SnackModel selected_snack = null;

                if (int.TryParse(for_removal, out intInput))
                {
                    // User input is an integer
                    selected_snack = snacksLogic.Find_Snack(intInput);
                }

                if (selected_snack == null)
                {
                    // Either user input is a string or the integer input didn't match any movie
                    selected_snack = snacksLogic.Find_Snack(for_removal);

                    if (selected_snack == null)
                    {
                        Console.WriteLine($"Snack {selected_snack} is not in the list, press any button to return to the admin snack menu");
                        Console.ReadKey();
                        Console.Clear();
                        Start();
                    }
                }
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("    _      _    _   ___              _   \r\n   /_\\  __| |__| | / __|_ _  __ _ __| |__\r\n  / _ \\/ _` / _` | \\__ \\ ' \\/ _` / _| / /\r\n /_/ \\_\\__,_\\__,_| |___/_||_\\__,_\\__|_\\_\\\r\n                                         ");
                    Console.ResetColor();
                    Console.WriteLine("");
                    //Asks the user for confirmation, If the answer is yes, it will delete it from the list. If the answer is no, you will be sent back to the menu.
                    Console.WriteLine($" > Are you sure you want to remove the {selected_snack}? (Y/N)");
                    string snack_confirmation = Console.ReadLine()!.ToUpper();
                    if (snack_confirmation == "Y")
                    {

                        snacksLogic.Delete_From_List(selected_snack);
                        snacksLogic.Update_Snack_ID();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("    _      _    _   ___              _   \r\n   /_\\  __| |__| | / __|_ _  __ _ __| |__\r\n  / _ \\/ _` / _` | \\__ \\ ' \\/ _` / _| / /\r\n /_/ \\_\\__,_\\__,_| |___/_||_\\__,_\\__|_\\_\\\r\n                                         ");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine($"\n{selected_snack.Name} has succesfully been deleted from the snack list\n");
                        //Prints the new snack list
                        Console.WriteLine("New List: ");
                        Get_Snack_List();

                        Console.WriteLine();
                        Console.WriteLine(" > Press 'Enter' to continue");
                        Console.ReadLine();
                        Thread.Sleep(2000);
                        Console.WriteLine("Going back to menu....");
                        Thread.Sleep(1000);
                        Console.Clear();

                        Start();
                    }
                    else if (snack_confirmation == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("Your changes have been discarded");
                        Thread.Sleep(2000);
                        Console.WriteLine("Going back to menu....");
                        Thread.Sleep(1000);
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
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("   ___ _                         ___              _   \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__\r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / /\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\\r\n                     |___/                            ");
        Console.ResetColor();
        Console.WriteLine("");
        //Prints the current snack list
        Console.WriteLine("Current List: ");
        Get_Snack_List();
        Console.WriteLine();


        while(true)
        {
            try
            {
                //Asks the user want snack they want to change
                var for_change = Console.ReadLine();

                int intInput;
                SnackModel selected_snack = null;

                if (int.TryParse(for_change, out intInput))
                {
                    // User input is an integer
                    selected_snack = snacksLogic.Find_Snack(intInput);
                }

                if (selected_snack == null)
                {
                    // Either user input is a string or the integer input didn't match any movie
                    selected_snack = snacksLogic.Find_Snack(for_change);

                    if (selected_snack == null)
                    {
                        Console.WriteLine($"Snack {selected_snack} is not in the list, press any button to return to the admin snack menu");
                        Console.ReadKey();
                        Console.Clear();
                        Start();
                    }
                }
                {
                    while (true)
                    {
                        //Asks the user which value they want to change of the snack.
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("   ___ _                         ___              _   \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__\r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / /\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\\r\n                     |___/                            ");
                        Console.ResetColor();
                        Console.WriteLine("");

                        //Creates a new table.
                        var table = new ConsoleTable("Name", "Price", "Type of Food", "Allergies");
                        //Loops through the running movie list, and add the contents to the table.

                        table.AddRow(selected_snack.Name, selected_snack.Price, selected_snack.Type_Of_Food, selected_snack.Allergies);

                        table.Options.EnableCount = false;

                        Console.WriteLine(table);
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine(" > [1] Change the name");
                        Console.WriteLine(" > [2] Change the price");
                        Console.WriteLine(" > [3] Change the type of food");
                        Console.WriteLine(" > [4] Change the allergies");
                        Console.WriteLine(" > [5] Go back to the menu");
                        string change_snack_choice = Console.ReadLine()!;
                        if (change_snack_choice == "1")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("   ___ _                         ___              _     _  _                \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__ | \\| |__ _ _ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / / | .` / _` | '  \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\ |_|\\_\\__,_|_|_|_\\___|\r\n                     |___/                                                  ");
                            Console.ResetColor();
                            Console.WriteLine("");
                            string value_to_be_changed = Get_Snack_Name();
                            snacksLogic.Change_Name_Snack(value_to_be_changed, selected_snack);
                        }
                        else if (change_snack_choice == "2")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("   ___ _                         ___              _     ___     _        \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__ | _ \\_ _(_)__ ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / / |  _/ '_| / _/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\ |_| |_| |_\\__\\___|\r\n                     |___/                                               ");
                            Console.ResetColor();
                            Console.WriteLine("");
                            double value_to_be_changed = Get_Snack_Price();
                            snacksLogic.Change_Price_Snack(value_to_be_changed, selected_snack);
                        }
                        else if (change_snack_choice == "3")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("   ___ _                         ___              _     _____               \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__ |_   _|  _ _ __  ___ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / /   | || || | '_ \\/ -_)\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\   |_| \\_, | .__/\\___|\r\n                     |___/                                   |__/|_|        ");
                            Console.ResetColor();
                            Console.WriteLine("");
                            string value_to_be_changed = Get_Snack_Type();
                            snacksLogic.Change_Type_Snack(value_to_be_changed, selected_snack);
                        }
                        else if (change_snack_choice == "4")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("   ___ _                         ___              _       _   _ _                   \r\n  / __| |_  __ _ _ _  __ _ ___  / __|_ _  __ _ __| |__   /_\\ | | |___ _ _ __ _ _  _ \r\n | (__| ' \\/ _` | ' \\/ _` / -_) \\__ \\ ' \\/ _` / _| / /  / _ \\| | / -_) '_/ _` | || |\r\n  \\___|_||_\\__,_|_||_\\__, \\___| |___/_||_\\__,_\\__|_\\_\\ /_/ \\_\\_|_\\___|_| \\__, |\\_, |\r\n                     |___/                                               |___/ |__/ ");
                            Console.ResetColor();
                            Console.WriteLine("");
                            string value_to_be_changed = Get_Snack_Allergies();
                            snacksLogic.Change_Allergy_Snack(value_to_be_changed, selected_snack);
                        }
                        else if (change_snack_choice == "5")
                        {
                            Console.Clear();
                            Console.WriteLine("Going back to menu....");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Start();
                        }


                        //Prints the new snack list
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.ResetColor();
                        Console.WriteLine("Snack succesfully changed");
                        Console.WriteLine("New List: ");
                        Get_Snack_List();
                        Console.WriteLine();
                        Console.WriteLine(" > Press 'Enter' to continue");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Going back to menu....");
                        Thread.Sleep(1000);
                        Console.Clear();
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