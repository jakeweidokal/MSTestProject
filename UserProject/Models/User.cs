using System.Numerics;
using System.Reflection.Metadata;

namespace UserProject.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string? userName, string? email, string? password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
        }
        public int Id { get; set; }
        private string? userName;
        public string? UserName
        {
            get { return userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new ArgumentException("Parameter username may not be null or blank", "UserName"));
                userName = value;
                    
            }
        }   
        public string? Email { get; set; }
        private string? password;
        public string? Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw (new ArgumentException("Parameter username may not be null or blank", "Password"));
                password = value;

            }
        }
    }
}