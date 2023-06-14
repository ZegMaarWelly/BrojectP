namespace UnitTesting
{
    [TestClass]
    public class AccountsLogicTests
    {
        private AccountsLogic _accountsLogic = new();





        [TestMethod]
        //Adds a  account to the list and checks if the account list has increased in size.
        public void Add_To_List_Succcessful()
        {

            AccountModel acc = new(_accountsLogic.Return_Account_List().Count,"Test@gmail.com","TestWachtwoord123.",DateTime.Now,"Full name Last name",false);

            int initialCount = _accountsLogic.Return_Account_List().Count;


            _accountsLogic.Add_To_List(acc);


            Assert.AreEqual(initialCount + 1, _accountsLogic.Return_Account_List().Count);
        }

        [TestMethod]
        //checks  if the current account is when logging out.
        public void Log_In_Succesful()
        {

            string email = "gio@gio.com";
            string pass = "Appelsap123.";
            var test =_accountsLogic.CheckLogin(email, pass);

            Assert.AreEqual(test.EmailAddress, email);
            Assert.AreEqual(test.Password, pass);



        }
        [TestMethod]
        //checks  if the current account is null when logging out.
        public void Log_Out_Successful()
        {

            _accountsLogic.LogOut();


            Assert.IsNull(_accountsLogic.Return_Current_User());
        }

        [TestMethod]
        //checks  if the given email is valid.
        public void Valid_Email()
        {

            string email = "gio@gio.com";

            bool validity = _accountsLogic.EmailVerification(email);


            Assert.IsTrue(validity);
        }

        [TestMethod]
        //checks  if the given email is invalid.
        public void Invalid_Email()
        {

            string email = "gio";

            bool validity = _accountsLogic.EmailVerification(email);


            Assert.IsFalse(validity);
        }

        [TestMethod]
        //checks  if the given password is valid.
        public void Valid_Password()
        {

            string pass = "Appelsap123.";

            bool validity = _accountsLogic.CheckPasswordSecurity(pass);


            Assert.IsTrue(validity);
        }

        [TestMethod]
        //checks  if the given password is invalid.
        public void Invalid_Password()
        {

            string pass = "water";

            bool validity = _accountsLogic.CheckPasswordSecurity(pass);


            Assert.IsFalse(validity);
        }

        [TestMethod]
        //checks  wether it can recognize if an admin is logged in or not.
        public void Check_Account_Admin_Successful()
        {

            string email = "Admin";
            string pass = "Admin";
            var loggingIn = _accountsLogic.CheckLogin(email, pass);

            bool adminOrNot = _accountsLogic.CheckAccountAdmin();

            Assert.IsTrue(adminOrNot);
        }

    }

}