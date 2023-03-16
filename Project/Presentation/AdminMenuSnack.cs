static class AdminMenuSnack
{

    static private SnacksLogic snacksLogic = new SnacksLogic();
    static public void Start()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Enter 1 to add a snack to the snack list");
        Console.WriteLine("Enter 2 to remove a snack from the snack list");
        Console.WriteLine("Enter 3 to change a value of snacks from the snack list");
        Console.WriteLine("Enter 4 to go back to");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Add_Snack();
        }
        else if (input == "2")
        {
            Remove_Snack();
        }
        else if (input == "3")
        {
            Change_Snack();
        }
        else if (input == "4")
        {
            AdminMenu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }
    }

    static public string Get_Snack_Name()
    {
        Console.WriteLine("Your Snack name: ");
        string snack_name = Console.ReadLine()!;
        return snack_name;
    }
    static public double Get_Snack_Price()
    {
        double snack_price = -1;
        bool price_success = false;
        while (!price_success)
        {
            Console.WriteLine("Your Price: ");
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
            Console.WriteLine("Type of food (Snack or Drink): ");
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
        Console.WriteLine("Your Allergies: ");
        string allergies = Console.ReadLine()!;
        if (allergies == "")
        {
            allergies = "none";
        }
        return allergies;

    }
    static public void Add_Snack()
    {
        //Asks the user for their snack.
        string snack_name = Get_Snack_Name();

        //Asks the user for their price, if the price isn't a double, you get an error message and can try it again.
        double snack_price = Get_Snack_Price();

        //Asks the user for their type of food, if the user input isn't "Snack" or "Drink", it will ask again.
        string type_of_food = Get_Snack_Type();

        //Asks the user for their allergies.
        string allergies = Get_Snack_Allergies();

        // Creates a snack object and asks the user for confirmation
        SnackModel snack = new(snack_name,snack_price,type_of_food,allergies);
        while(true)
        {
            Console.WriteLine(snack);
            Console.WriteLine("Proceed to add the snack to the snack list? (Y/N) ");
            string snack_confirmation = Console.ReadLine()!.ToUpper();
            
            //If the answer is Yes, it will delete it from the list (and also the json file)
            if(snack_confirmation == "Y")
            {
                if(snacksLogic.Add_To_List(snack))
                {
                    Console.WriteLine($"{snack.Name} successfully added to the snack list!");
                    Start();
                }
                else
                {
                    Console.WriteLine($"{snack.Name} already in the snack list!");
                    Start();
                }
            }
            else if (snack_confirmation == "N")
            {
                Console.WriteLine("going back the snack menu");
                Start();
            }
            else
            {
                Console.WriteLine("Invalid input, try again!");
            }
        }

    }

    static public void Remove_Snack()
    {
        //Asks the user want snack they want to remove
        Console.WriteLine("What Snack do you want to remove?");
        string snack_name = Console.ReadLine()!;

        //Finds the Snack if it is present in the snack list, if snack isnt present, you will be sent back to the menu.
        SnackModel your_snack = snacksLogic.Find_Snack(snack_name);
        if (your_snack == null)
        {
            Console.WriteLine("This Snack doesn't exist in the snack list");
            Start();
        }
        else
        {
            //Asks the user for confirmation, If the answer is yes, it will delete it from the list. If the answer is no, you will be sent back to the menu.
            Console.WriteLine($"Are you sure you want to remove the {your_snack.Name}? (Y/N)");
            string snack_confirmation = Console.ReadLine()!.ToUpper();
            if (snack_confirmation == "Y")
            {
                snacksLogic.Delete_From_List(your_snack);
                Console.WriteLine($"{your_snack.Name} has succesfully been deleted from the snack list");
                Start();
            }
            else if (snack_confirmation == "N")
            {
                Console.WriteLine("going back the snack menu");
                Start();
            }
            else
            {
                Console.WriteLine("Invalid input, try again!");
            }
        }
        
    }
    static public void Change_Snack()
    {
        //Asks the user want snack they want to change
        Console.WriteLine("What Snack do you want to change?");
        string snack_name = Console.ReadLine()!;

        //Finds the Snack if it is present in the snack list, if snack isnt present, you will be sent back to the menu.
        SnackModel your_snack = snacksLogic.Find_Snack(snack_name);
        if (your_snack == null)
        {
            Console.WriteLine("This Snack doesn't exist in the snack list");
            Start();
        }
        else
        {
           while(true)
            {
                Console.WriteLine(your_snack);
                Console.WriteLine("What value do you want to change? \n You have the options to choose the following values.");
                Console.WriteLine("Enter 1 to change the name");
                Console.WriteLine("Enter 2 to change the price");
                Console.WriteLine("Enter 3 to change the type of food");
                Console.WriteLine("Enter 4 to change the allergies");
                Console.WriteLine("Enter 5 to go back to the menu");
                string change_snack_choice = Console.ReadLine()!;
                if (change_snack_choice == "1")
                {
                    string value_to_be_changed = Get_Snack_Name();
                    snacksLogic.Change_String_Snack(your_snack, your_snack.Name, value_to_be_changed);
                }
                else if (change_snack_choice == "2")
                {
                    
                }
                else if (change_snack_choice == "3")
                {
                    
                }
                else if (change_snack_choice == "4")
                {
                }
                else if (change_snack_choice == "5")
                {
                    Console.WriteLine("Going back to the menu");
                    Start();
                }
            }
            

        }
    }
}
