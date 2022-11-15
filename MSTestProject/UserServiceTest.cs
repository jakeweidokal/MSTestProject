using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserProject;
using UserProject.Interfaces;

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
            Assert.Fail();
        }

        [TestMethod]
        public void Should_SignIn_ValidUser()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Should_Not_SignIn_InvalidUser()
        {
            Assert.Fail();
        }
    }
}