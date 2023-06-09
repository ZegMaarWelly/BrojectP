
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTesting
{
    [TestClass]
    public class AdminMenuSnackTests
    {
        [TestMethod]
        //Tests the method to see if it succesfully returns the correct name
        public void GetSnackName_Successful()
        {

            string expectedName = "LitteralyAnything";
            var inputString = new StringReader(expectedName);
            Console.SetIn(inputString);

            string actualName = AdminMenuSnack.Get_Snack_Name();

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        //Tests the method to see if it succesfully returns the correct type
        public void GetSnackType_Successful()
        {

            string expectedType = "Snack";
            var inputString = new StringReader(expectedType);
            Console.SetIn(inputString);

            string actualType = AdminMenuSnack.Get_Snack_Type();

            Assert.AreEqual(expectedType, actualType);
        }


        [TestMethod]
        //Tests the method to see if it gives an error message when given an unsuccesful type
        public void GetSnackType_Unsuccessful()
        {

            string invalidType = "Invalid";
            string validType = "Drink";
            var inputString = new StringReader(invalidType + Environment.NewLine + validType);
            Console.SetIn(inputString);
            var output = new StringWriter();
            Console.SetOut(output);


            AdminMenuSnack.Get_Snack_Type();


            string outputText = output.ToString();
            string expectedErrorMessage = "Invalid Type, try again!";
            Assert.IsTrue(outputText.Contains(expectedErrorMessage));
        }

        [TestMethod]
        //Tests the method to see if it succesfully returns the correct price
        public void GetSnackPrice_Successful()
        {

            string validNumber = "5";
            double expectedPrice = Convert.ToDouble(validNumber);
            var inputString = new StringReader(validNumber);
            Console.SetIn(inputString);
            var output = new StringWriter();
            Console.SetOut(output);


            double actualPrice = AdminMenuSnack.Get_Snack_Price();


            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        //Tests the method to see if it gives an error message when given an unsuccesful number
        public void GetSnackPrice_Unsuccessful()
        {

            string invalidNumber = "Invalid";
            string validNumber = "5";
            var inputString = new StringReader(invalidNumber + Environment.NewLine + validNumber);
            Console.SetIn(inputString);
            var output = new StringWriter();
            Console.SetOut(output);


            AdminMenuSnack.Get_Snack_Price();


            string outputText = output.ToString();
            string expectedErrorMessage = "Invalid price; please enter a correct number";
            Assert.IsTrue(outputText.Contains(expectedErrorMessage));
        }

        [TestMethod]
        //Tests the method to see if it succesfully returns the correct Allergy
        public void GetSnackAllergy_Successful()
        {

            string expectedAllergy = "LitteralyAnything";
            var inputString = new StringReader(expectedAllergy);
            Console.SetIn(inputString);

            string actualAllergy = AdminMenuSnack.Get_Snack_Allergies();

            Assert.AreEqual(expectedAllergy, actualAllergy);
        }

        [TestMethod]
        //Test the method to see if it succesfully returns "none" when the input is nothing.
        public void GetSnackAllergy_SuccessfulButEmpty()
        {

            string inputAllergy = " ";
            string expectedAllergy = "none";
            var inputString = new StringReader(inputAllergy);
            Console.SetIn(inputString);

            string actualAllergy = AdminMenuSnack.Get_Snack_Allergies();

            Assert.AreEqual(expectedAllergy, actualAllergy);
        }

       

    }
}