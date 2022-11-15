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
            return (user == null || user.UserName == null || user.Password == null) 
                ? false 
                : (user.UserName == "TrainingUser" && user.Password == "Training@1");
        }
    }
}
