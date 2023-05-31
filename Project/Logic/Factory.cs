class Factory
{
    //this is where the Logic is created, so that you don't need to create a new logic everytime.

    public static RunningMovieLogic runningmovieLogic = new RunningMovieLogic("empty_file");
    public static AccountsLogic accountsLogic = new AccountsLogic();
    static public RoomLogic roomLogic = new RoomLogic();
    static public MovieListLogic movieLogic = new MovieListLogic();
    static public SnacksLogic snacksLogic = new SnacksLogic();
    static public    ShoppingCartLogic shoppingcartLogic = new ShoppingCartLogic();
    static public ReservationLogic reservationLogic = new ReservationLogic("noone");

}