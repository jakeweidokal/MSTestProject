using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Models;

namespace UserProject.Interfaces
{
    public interface IUserService
    {
        public bool SignIn(User user);
    }
}
