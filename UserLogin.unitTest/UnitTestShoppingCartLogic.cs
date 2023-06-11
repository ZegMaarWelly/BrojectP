namespace UnitTesting
{
   
   
    [TestClass]
    public class ShoppingCartLogicTests
    {
        private ShoppingCartLogic _shoppingCartLogic = new();
        private SnackModel _snack1 = new SnackModel(1, "Snack 1", 2.5, "Type 1", "Allergies 1");
        private SnackModel _snack2  = new SnackModel(2, "Snack 2", 3.0, "Type 2", "Allergies 2");



     

        [TestMethod]
        //Finds the counted Snack and checks if it is in the list.
        public void Find_Counted_Snack_Unsuccessful()
        {
            CountedSnackModel result = _shoppingCartLogic.Find_Counted_Snack(_snack1);
            Assert.IsNull(result);
        }

        [TestMethod]
        //Finds the counted Snack and checks if it is  in the list.
        public void Find_Counted_Snack_Successful()
        {
            _shoppingCartLogic.AddCountedSnack(_snack1);
            CountedSnackModel result = _shoppingCartLogic.Find_Counted_Snack(_snack1);
            Assert.AreEqual(_snack1, result.Snack);
        }

        [TestMethod]
        //Finds the counted snack by name and checks if it is in the list.
        public void Find_Counted_Snack_By_Name_Unsuccessful()
        {
            CountedSnackModel result = _shoppingCartLogic.Find_Counted_Snack_By_Name("Snack 1");
            Assert.IsNull(result);
        }

        [TestMethod]
        //Finds the counted snack by name and checks if it is in the list.
        public void Find_Counted_Snack_By_Name_Successful()
        {
            _shoppingCartLogic.AddCountedSnack(_snack1);
            CountedSnackModel result = _shoppingCartLogic.Find_Counted_Snack_By_Name("Snack 1");
            Assert.AreEqual(_snack1, result.Snack);
        }

        [TestMethod]
        //Checks if it properly adds a  singular counted snack to the list.
        public void AddCountedSnack_Singular()
        {

            _shoppingCartLogic.AddCountedSnack(_snack1);
            List<CountedSnackModel> expectedList = new List<CountedSnackModel>()
        {
            new CountedSnackModel(_snack1, 1)
        };
            var result = _shoppingCartLogic.Return_Counted_Snack_List();
            Assert.AreEqual(expectedList[0].Snack, result[0].Snack);
            Assert.AreEqual(expectedList[0].Quantity, result[0].Quantity);
        }

        [TestMethod]
        //Checks if it properly adds  mutiple counted snacks to the list.
        public void AddCountedSnack_Mutiple()

        {
            List<CountedSnackModel> expectedList = new List<CountedSnackModel>()
            {
            new CountedSnackModel(_snack2, 2)
            };

            _shoppingCartLogic.AddCountedSnack(_snack2);
            _shoppingCartLogic.AddCountedSnack(_snack2);

            var result = _shoppingCartLogic.Return_Counted_Snack_List();

            Assert.AreEqual(expectedList[0].Snack, result[0].Snack);
            Assert.AreEqual(expectedList[0].Quantity, result[0].Quantity);
        }

        [TestMethod]
        //Checks wether it successfully removes a counted snack.
        public void Remove_Counted_Snack_Successful()
        {
            _shoppingCartLogic.AddCountedSnack(_snack1);
            _shoppingCartLogic.Remove_Counted_Snack(_shoppingCartLogic.Find_Counted_Snack(_snack1));
            List<CountedSnackModel> expectedList = new List<CountedSnackModel>();

            var result = _shoppingCartLogic.Return_Counted_Snack_List();

            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void Decrease_Quantity_Mutiple()
        {
            //_shoppingCartLogic = new();
            _shoppingCartLogic.AddCountedSnack(_snack2);
            _shoppingCartLogic.AddCountedSnack(_snack2);
            _shoppingCartLogic.AddCountedSnack(_snack2);
            CountedSnackModel countedSnack = _shoppingCartLogic.Find_Counted_Snack(_snack2);
            


            List<CountedSnackModel> expectedList = new List<CountedSnackModel>()
            {
                new CountedSnackModel(_snack2,2)
            };
            _shoppingCartLogic.Decrease_Quantity(countedSnack, 1);
            var result = _shoppingCartLogic.Return_Counted_Snack_List();
            Assert.AreEqual(expectedList[0].Snack, result[0].Snack);
            Assert.AreEqual(expectedList[0].Quantity, result[0].Quantity);
        }

        [TestMethod]
        public void Decrease_Quantity_Singular()
        {
            _shoppingCartLogic.AddCountedSnack(_snack1);
            CountedSnackModel countedSnack = _shoppingCartLogic.Find_Counted_Snack(_snack1);
            _shoppingCartLogic.Decrease_Quantity(countedSnack, 1);
            List<CountedSnackModel> expectedList = new List<CountedSnackModel>();
            var result = _shoppingCartLogic.Return_Counted_Snack_List();
            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        //Checks wether the total price is returned properly
        public void Get_Total_Price_Successful()
        {
            _shoppingCartLogic.AddCountedSnack(_snack1);
            _shoppingCartLogic.AddCountedSnack(_snack2);
            double expectedTotalPrice = _snack1.Price + _snack2.Price;

            double result = _shoppingCartLogic.Get_Total_Price();

            Assert.AreEqual(expectedTotalPrice, result);
        }
    }

}