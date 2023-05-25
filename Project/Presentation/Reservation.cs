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
        Console.WriteLine($"You are about to make a reservation to the movie {runningmovie.Movie.Name} in room {runningmovie.Room.ID}\n\n");
        Console.WriteLine("How many seats do you want to reserve?\n");

        // Asks the user for the amount of seats.
        int seat_amount = -1;
        bool seat_success = false;
        while (!seat_success)
        {
            Console.WriteLine(" > Your Seats : ");
            try
            {
                seat_amount = Convert.ToInt32(Console.ReadLine());
                seat_success = true;

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number; please enter a correct number");
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

        double total_Price = 0;

        
        Ask_Confirmation_And_See_Price(total_Price);


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
                total_Price += snack_price;

                Ask_Confirmation_And_See_Price(total_Price);

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


   
    
    
    //Deletes a reservation
    public static void Delete_Reservation(ReservationModel reservation)
    {
        Console.Clear();
        ScreenRoomLogic.screening_room_reservation(reservation.Running_Movie.Room.Map);


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

        
        //Turns the list into an array
        ReservationModel[] reservation_array = reservation_list.ToArray();

        //Creates an array where the begin time is before the currrent date.
        ReservationModel[] valid_reservations = reservation_array.Where(x => x.Running_Movie.Begin_Time >= DateTime.Now).ToArray();

        //Ceates an array where the begin time is after the current date.
        ReservationModel[] expired_reservations = reservation_array.Where(x => x.Running_Movie.Begin_Time < DateTime.Now).ToArray();

        //If the user has no reservations, return to menu
        if (reservation_list.Count == 0)
        {
            Console.WriteLine("You do not have any reservations on this account");
            Thread.Sleep(1000);
            Console.WriteLine("Going back to menu....");
            Thread.Sleep(1000);
            Menu.Menu_When_Logged_In();
        }

        

        //Prints the expired reservations.

        Console.WriteLine("Expired reservations:      ");
        foreach (ReservationModel reservation in expired_reservations)
        {
            Console.WriteLine(reservation);

        }
        Console.WriteLine("\n\n\n");

        //Prints the valid reservations.
        Console.WriteLine("Valid reservations: ");
        foreach (ReservationModel reservation in valid_reservations)
        {
            Console.WriteLine(reservation);

        }


        bool confirmation = false;
        while(!confirmation)
        {
            Console.WriteLine("To go back press ENTER\nTo cancel reservation, press C");
            var reservation_input= Console.ReadLine()!;
            if(reservation_input == "")
            {
                Menu.Menu_When_Logged_In();
            }
            else if (reservation_input == "C")
            {
                if(valid_reservations.Length >0)
                {
                    Cancel_Reservation(valid_reservations.ToList());
                    confirmation = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("It appears that you don't have any valid reservations");
                    Thread.Sleep(1000);
                    Console.WriteLine("Going back to menu....");
                    Thread.Sleep(1000);
                    Menu.Menu_When_Logged_In();
                }
            }
            else
            {
                Console.WriteLine("Invalid Input, This is not one of the options.");
            }

        }

        Console.Clear();
        Console.WriteLine("You have successfully cancelled your reservation");
        Thread.Sleep(1000);
        Console.WriteLine("Going back to menu....");
        Thread.Sleep(1000);
        Menu.Menu_When_Logged_In();


    }

    public static void Cancel_Reservation(List<ReservationModel> reservation_list)
    {
        Console.Clear();
        //Turns the list into an array
        //Prints the reservations
        int count = 1;
        foreach (ReservationModel reservation in reservation_list)
        {
            Console.WriteLine($"________------------[{count}]------------________");
            Console.WriteLine(reservation);
            count++;

        }
        int reservation_id = -1;
        bool reservation_success = false;
        while (!reservation_success)
        {
            Console.WriteLine("Your Number: ");
            try
            {
                reservation_id = Convert.ToInt32(Console.ReadLine())-1;
                if (reservation_id >= reservation_list.Count || reservation_id < 0)
                {
                    Console.WriteLine("This number is not a valid option");
                }
                else
                {
                    reservation_success = true;
                }

            }
            //Catches any type of exception.
            catch
            {
                Console.WriteLine("Invalid number; please enter a correct number");
            }
        }


        Console.Clear();
        bool confirmation = false;
        while(!confirmation)
        {
            Console.WriteLine("Confirm Deletion? (Y/N)");
            var confirmation_choice = Console.ReadLine()!.ToUpper();
            if(confirmation_choice == "Y")
            {
                confirmation = true;
            }
            else if(confirmation_choice == "N")
            {
                Console.WriteLine("Going back to menu....");
                Thread.Sleep(1000);
                Menu.Menu_When_Logged_In();
            }
            else
            {
                Console.WriteLine("Invalid input, please type 'Y' or 'N'");
            }
        }


        ReservationModel reservation_to_be_changed = reservation_list[reservation_id];

        runningmovieLogic = new(reservation_to_be_changed.Running_Movie.Date.ToString("yyyy-MM-dd"));
        RunningMovieModel[] running_movie_array = runningmovieLogic.Return_RunningMovie_List().ToArray();
        RunningMovieModel running_movie_to_be_changed = running_movie_array.Where(x => x.Movie.Id == reservation_to_be_changed.Running_Movie.Movie.Id)
                                                                      .Where(x=> x.Room.ID == reservation_to_be_changed.Running_Movie.Room.ID)
                                                                      .Where(x => x.Begin_Time == reservation_to_be_changed.Running_Movie.Begin_Time).ToArray()[0];
        foreach (var seat in reservation_to_be_changed.Seats)
        {
            ScreenRoomLogic.Remove_Reserved_Seat(seat, running_movie_to_be_changed.Room.Map);
            running_movie_to_be_changed.Room.Available_Seats++;
        }

        runningmovieLogic.Change_Running_Movie_From_RoomIDMovieStarDate(running_movie_to_be_changed);
        reservationLogic.Delete_From_List(reservation_to_be_changed);
        
        
    }

}