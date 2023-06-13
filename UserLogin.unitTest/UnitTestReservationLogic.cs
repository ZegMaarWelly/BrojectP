namespace UnitTesting
{
    [TestClass]
    public class ReservationsLogicTests
    {
        private ReservationLogic _reservationLogic = new("Test");
        private RunningMovieLogic _runningMovieLogic = new("2024-06-10");


        [TestMethod]
        //Adds a reservation to the list and checks if the reservation  list has increased in size.
        public void Add_To_List_Successful()
        {

            RunningMovieModel mov = _runningMovieLogic.Return_RunningMovie_List()[0];
            AccountModel acc = new(55, "Test@gmail.com", "TestWachtwoord123.", DateTime.Now, "Full name Last name", false);
            List<string> seats = new List<string>
            {
            "B-6",
            "A-5",
            
            };

            ReservationModel reservation = new(mov, acc, seats, new());

            int initialCount = _reservationLogic.Return_Reservation_List().Count;


            _reservationLogic.Add_To_List(reservation);


            Assert.AreEqual(initialCount + 1, _reservationLogic.Return_Reservation_List().Count);
        }

        [TestMethod]
        //removes a reservation from the list and checks if the reservation  list has increased in size.
        public void Delete_From_List_Successful()
        {



            ReservationModel reservation = _reservationLogic.Return_Reservation_List()[0];

            int initialCount = _reservationLogic.Return_Reservation_List().Count;


            _reservationLogic.Delete_From_List(reservation);


            Assert.AreEqual(initialCount - 1 , _reservationLogic.Return_Reservation_List().Count);
        }

    }

}