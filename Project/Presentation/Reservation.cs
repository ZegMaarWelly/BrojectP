static class Reservation
{

    static private RunningMovieLogic runningmovieLogic = Factory.runningmovieLogic;
    static private ShoppingCartLogic shoppingcartLogic = Factory.shoppingcartLogic;
    static private AccountsLogic accountsLogic = Factory.accountsLogic;
    static private ReservationLogic reservationLogic = Factory.reservationLogic;


    // You make your reservation here, after selecting a movie.
    public static void Make_Reservation(RunningMovieModel runningmovie)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("  __  __         _       ___                          _   _          \r\n |  \\/  |_____ _(_)___  | _ \\___ ___ ___ _ ___ ____ _| |_(_)___ _ _  \r\n | |\\/| / _ \\ V / / -_) |   / -_|_-</ -_) '_\\ V / _` |  _| / _ \\ ' \\ \r\n |_|  |_\\___/\\_/|_\\___| |_|_\\___/__/\\___|_|  \\_/\\__,_|\\__|_\\___/_||_|\r\n                                                                     ");
        Console.ResetColor();
        Console.WriteLine($"You are about to make a reservation to the movie {runningmovie.Movie.Name} in room {runningmovie.Room.ID}\n\n");
        Console.WriteLine(" > How many seats do you want to reserve?\n");

        // Asks the user for the amount of seats.
        int seat_amount = -1;
        bool seat_success = false;
        while (!seat_success)
        {
            try
            {
                seat_amount = Convert.ToInt32(Console.ReadLine());
                seat_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid input; please enter a correct number");
            }

        }




        List<string> list_of_seats = new();

        // You reserve a seat here.
        for (int i = 0; i < seat_amount; i++)
        {
            
            // returns the selected seat.
            (List<string> new_map, string seat) = ScreenRoomLogic.screening_room_reservation(runningmovie.Room.Map);

            runningmovie.Room.Available_Seats -= 1;


            list_of_seats.Add(seat);
        }

        

        // Prints the seats you just reserverd.
        string joinedSeats = String.Join(",", list_of_seats);
        Console.WriteLine($"You have succesfully ordered seats {joinedSeats}\n\n");
        Console.WriteLine($"0");

        double Total_Price = 0;

        
        Ask_Confirmation_And_See_Price(Total_Price);


        //Asks the users if they want to order some snacks.
        while(true)
        {
            Console.WriteLine("Do you also want to order some snacks? (Y/N)");
            var input = Console.ReadLine()!.ToUpper();
            //if the answer is yes, you will be send to the shoppingcart file.
            if (input == "Y")
            {
                Console.Clear();
                ShoppingCart.Start();

                var snack_price = shoppingcartLogic.Get_Total_Price();
                Total_Price += snack_price;

                Ask_Confirmation_And_See_Price(Total_Price);

                break;


            }
            //if the answer is no, no snacks will be selected and the total price will stay the same.
            else if (input == "N")
            {
                Console.WriteLine("No snacks selected");
                Thread.Sleep(1000);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Answer, try again");
            }

        }




        runningmovieLogic = new(runningmovie.Date.ToString("yyyy-MM-dd"));
        
        //updates the room map in the json file.
        runningmovieLogic.Change_Running_Movie_From_RoomIDMovieStarDate(runningmovie);

        // Creates a ReservationModel.
        ReservationModel reservation = new(runningmovie,accountsLogic.Return_Current_User(),list_of_seats,shoppingcartLogic.Return_Counted_Snack_List());

        //Creates a new accountlogic , this will have the name of the users email adress.
        reservationLogic = new(accountsLogic.Return_Current_User().EmailAddress);

        //Adds the reservation to the users reservations list.
        reservationLogic.Add_To_List(reservation);

        Console.Clear();
        Menu.Menu_When_Logged_In();

    }

    // Asks the user for confirmation. You are also able to see the total price here.
    public static void Ask_Confirmation_And_See_Price(double total)
    {
        Console.WriteLine($"Your total price is now ${total}.");
        Console.WriteLine($"Do you want to confirm your reservation? (Y/N)");
        var input = Console.ReadLine()!.ToUpper();
        if(input == "Y")
        {
            Console.WriteLine("Reservation confirmed");

        }
        else if (input == "N")
        {
            Console.WriteLine("Reservation declined");
            Console.WriteLine("Sending you back to menu");
            Thread.Sleep(2000);
            Console.Clear();
            Menu.Menu_When_Logged_In();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Answer, try again");
            Ask_Confirmation_And_See_Price(total);
        }

    }

    //As a user, you are able to see the reservations you have made.
    public static void See_Reservations()
    {
        //Creates a new accountlogic, this will have the name of the users email adress.
        reservationLogic = new(accountsLogic.Return_Current_User().EmailAddress);

        Console.Clear();
        //The list of all the users reservations
        List<ReservationModel> reservation_list = reservationLogic.Return_RunningMovie_List();

        //If the user has no reservations, return to menu
        if(reservation_list.Count == 0)
        {
            Console.WriteLine("You do not have any reservations on this account");
            Thread.Sleep(1000);
            Console.WriteLine("Going back to menu....");
            Thread.Sleep(1000);
            Menu.Menu_When_Logged_In();
        }

        //Prints the reservations
        foreach(ReservationModel reservation in reservation_list)
        {
            Console.WriteLine(reservation);

        }
        Console.ReadLine();

    }

}