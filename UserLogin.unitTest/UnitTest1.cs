using Moq;
namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        [TestClass]
        public class UserLoginTests
        {
            [TestMethod]
            //test if Admin can log in
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
            [TestMethod]
            //test if Admin can log in
            public void IsAdmin_IsTrue_Test2()
            {
                // Arrange
                var email = "A";
                var password = "A";

                // Act
                var result = UserLogin.IsAdmin(email, password);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            //A user logs in and tests if the user is not an admin.
            public void IsUserLoginFalse()
            {
                // Arrange
                var email = "test@example.com";
                var password = "password";

                // Act
                var result = UserLogin.IsAdmin(email, password);

                // Assert
                Assert.IsFalse(result);
            }
        }
    }
}
