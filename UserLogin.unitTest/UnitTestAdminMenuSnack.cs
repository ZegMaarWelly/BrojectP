
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;

namespace UnitTesting
{
    [TestClass]
    public class AdminMenuSnackTests
    {

        [TestMethod]
        public void GetSnackType_Successful()
        {
           
            string expectedType = "Snack";
            var inputString = new StringReader(expectedType);
            Console.SetIn(inputString);
            
            string actualType = AdminMenuSnack.Get_Snack_Type();

            Assert.AreEqual(expectedType, actualType);
        }


        [TestMethod]
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
    }

    
}
