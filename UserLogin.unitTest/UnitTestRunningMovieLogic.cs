
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTesting
{
   
    
    [TestClass]
    public class RunningMovieLogicTests
    {
        private RunningMovieLogic _runningMovieLogic = new("2023-06-23");
        [TestMethod]
        public void Add_To_List_Sucessful()
        {
           
        }

        [TestMethod]
        public void Delete_From_List_Sucessful()
        {
        }


    }
}