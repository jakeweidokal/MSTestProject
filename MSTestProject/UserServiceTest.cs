using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserProject;
using UserProject.Interfaces;
using UserProject.Models;

namespace MSTestProject
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;

        [TestInitialize]
        public void SetUp()
        {
            _userService = new UserService();
        }

        [TestCleanup]
        public void CleanUp()
        {
            GC.Collect();
        }

        #region Basic Tests

        [TestMethod]
        public void Should_Not_SignIn_If_No_Credentials()
        {
            // Arrange
            User user = new User();
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void Should_SignIn_ValidUser()
        {
            // Arrange
            User user = new User() { UserName="TrainingUser", Password="Training@1"};
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Should_Not_SignIn_InvalidUser()
        {
            // Arrange
            User user = new User() { UserName = "INVALID_NAME", Password = "INVALID_PASSWORD" };
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, false);
        }

        #endregion

        #region Testing Exceptions

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter username may not be null or blank")]
        public void Null_Username_In_Constructor()
        {
            User logonInfo = new User(0, null, "test@test.com", "Password");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter password may not be null or blank")]
        public void Null_Password_In_Constructor()
        {
            User logonInfo = new User(0, "Test", "test@test.com", null);
        }

        #endregion

        #region Data Tests (run test multiple times with different sets of data)

        [DataTestMethod]
        [DataRow("INVALID_NAME", "INVALID_PASS", false)]
        [DataRow("TrainingUser", "Training@1", true)]
        public void Perform_Multiple_SignIn_Checks(string userName, string password, bool expected)
        {
            // Arrange
            User user = new User(0, userName, null, password);
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(UserData), DynamicDataSourceType.Method)]
        public void Perform_Multiple_SignIn_Checks_Dynamic_Data(string userName, string password, bool expected)
        {
            // Arrange
            User user = new User(0, userName, null, password);
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, expected);
        }

        private static IEnumerable<object[]> UserData()
        {
            return new[]
            {
                new object[] { "INVALID_NAME", "INVALID_PASS", false},
                new object[] { "TrainingUser", "Training@1", true }
            };
        }

        #endregion

        #region Ignore Tests

        [Ignore]
        public void Should_Ignore_SignIn_Test()
        {
            // Arrange
            User user = new User(0, "TrainingUser", null, "Training@1");
            // Act
            var result = _userService.SignIn(user);
            // Assert
            Assert.AreEqual(result, true);
        }

        #endregion
    }
}