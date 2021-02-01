using System.Security.Cryptography;
using System.Text;

namespace CDE.Domain.Entities
{
    public class User
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPassword { get; private set; }

        public User(string userName, string userPassword)
        {
            UserName = userName;
            UserPassword = userPassword;
        }

        public User(string userName, string userEmail, string userPassword) : this(userName, userPassword)
        {
            UserEmail = userEmail;
        }

        public User(int userId, string userName, string userEmail, string userPassword) : this(userName, userEmail, userPassword)
        {
            UserId = userId;
        }

        public void EncryptPassword()
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(UserPassword);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            UserPassword = sb.ToString();
        }
    }
}
