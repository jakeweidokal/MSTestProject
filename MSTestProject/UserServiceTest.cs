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
        public void TestMethod1()
        {
        }
    }
}