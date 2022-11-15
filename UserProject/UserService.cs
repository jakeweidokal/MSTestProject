using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Interfaces;
using UserProject.Models;

namespace UserProject
{
    public class UserService : IUserService
    {
        public bool SignIn(User user)
        {
            bool isUserNull = user == null || user.UserName == null || user.Password == null;
            bool hasValidUsernameAndPassword = user.UserName == "TrainingUser" && user.Password == "Training@1";
            return !isUserNull && hasValidUsernameAndPassword;
        }
    }
}
