namespace TestProject1
{
    [TestClass]
    public class UserLoginTests
    {
        [TestMethod]
        public void IsAdmin_IsTrue_Test()
        {
            // Arrange
            var email = "Admin";
            var password = "Admin";

            // Act
            var result = UserLogin.IsAdmin(email, password);

            // Assert
            Assert.IsTrue(result);
        }

    }
}