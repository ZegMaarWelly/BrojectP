
using Moq;

namespace UnitTesting
{
    [TestClass]
    public class SnacksLogicTests
    {
        private SnacksLogic _snacksLogic = new();


    


        [TestMethod]
        //Get the snack list based on type (drink) and checks wether each type is equal to (drink).
        public void ReturnSnackListBasedOnType()
        {
            
            string type = "Drink";

           
            List<SnackModel> snacks = _snacksLogic.Return_Snack_List_Based_On_Type(type);

            
            foreach (SnackModel snack in snacks)
            {
                Assert.AreEqual(type, snack.Type_Of_Food);
            }
        }

        [TestMethod]
        //Adds a snack to the list and checks if the snack list has increased in size.
        public void AddToList_IncreasesSnackCount()
        {
            
            SnackModel snack = new(_snacksLogic.Return_Snack_List().Count, "Chocolate Bar", 2.99, "Snack", "None");

            int initialCount = _snacksLogic.Return_Snack_List().Count;

            
            _snacksLogic.Add_To_List(snack);

            
            Assert.AreEqual(initialCount + 1, _snacksLogic.Return_Snack_List().Count);
        }

       

        [TestMethod]
        //Finds a snack by the ID and checks wether or not the IDs are equal.
        public void FindSnackID_ReturnsMatchingSnack()
        {
            
            int id = 1;

            
            SnackModel snack = _snacksLogic.Find_Snack_ID(id);

            
            Assert.AreEqual(id, snack.ID);
        }

        [TestMethod]
        //Finds a snack by the name and checks if they are the same.
        public void FindSnack_ReturnsMatchingSnack()
        {
           
            string name = "Chocolate Bar";

            SnackModel snack = _snacksLogic.Find_Snack(name);

            Assert.AreEqual(name, snack.Name);
        }

        

        [TestMethod]

        //Changes the name of the snack and checks if the name has indeed changed.
        public void ChangeNameSnack_UpdatesSnackName()
        {
         
            string newName = "New Name";
            SnackModel snack = _snacksLogic.Find_Snack("Chocolate Bar");

         
            _snacksLogic.Change_Name_Snack(newName, snack);

            SnackModel updatedSnack = _snacksLogic.Find_Snack(newName);
            Assert.IsNotNull(updatedSnack);
            Assert.AreEqual(newName, updatedSnack.Name);
        }

        [TestMethod]
        //Changes the price of the snack and checks if the price has indeed changed.
        public void ChangePriceSnack_UpdatesSnackPrice()
        {
           
            double newPrice = 3.99;
            SnackModel snack = _snacksLogic.Find_Snack("Chocolate Bar");

            _snacksLogic.Change_Price_Snack(newPrice, snack);

            SnackModel updatedSnack = _snacksLogic.Find_Snack("Chocolate Bar");
            Assert.IsNotNull(updatedSnack);
            Assert.AreEqual(newPrice, updatedSnack.Price);
        }

        [TestMethod]
        //Changes the type of the snack and checks if the type  has indeed changed.
        public void ChangeTypeSnack_UpdatesSnackType()
        {
         
            string newType = "Candy";
            SnackModel snack = _snacksLogic.Find_Snack("Chocolate Bar");

            _snacksLogic.Change_Type_Snack(newType, snack);

            SnackModel updatedSnack = _snacksLogic.Find_Snack("Chocolate Bar");
            Assert.IsNotNull(updatedSnack);
            Assert.AreEqual(newType, updatedSnack.Type_Of_Food);
        }

        [TestMethod]
        //Changes the allergy of the snack and checks if the allergy has indeed changed.
        public void ChangeAllergySnack_UpdatesSnackAllergy()
        {
          
            string newAllergy = "Peanuts";
            SnackModel snack = _snacksLogic.Find_Snack("Chocolate Bar");

            _snacksLogic.Change_Allergy_Snack(newAllergy, snack);

            SnackModel updatedSnack = _snacksLogic.Find_Snack("Chocolate Bar");
            Assert.IsNotNull(updatedSnack);
            Assert.AreEqual(newAllergy, updatedSnack.Allergies);
        }

        [TestMethod]
        //Deletes a snack from the list and checks if the snack list count has decreased.
        public void DeleteFromList_DecreasesSnackCount()
        {
         
            SnackModel snack = _snacksLogic.Find_Snack("New Name");
            int initialCount = _snacksLogic.Return_Snack_List().Count;

         
            _snacksLogic.Delete_From_List(snack);

            Assert.AreEqual(initialCount, _snacksLogic.Return_Snack_List().Count);
        }


    }
}
