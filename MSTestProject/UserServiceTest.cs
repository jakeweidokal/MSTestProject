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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter username may not be null or blank")]
        public void Null_Username_In_Constructor()
        {
            // Arrange

            // Act
            User logonInfo = new User(0, null, "test@test.com", "Password");
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter password may not be null or blank")]
        public void Null_Password_In_Constructor()
        {
            // Arrange

            // Act
            User logonInfo = new User(0, "Test", "test@test.com", null);
            // Assert
        }
    }
}