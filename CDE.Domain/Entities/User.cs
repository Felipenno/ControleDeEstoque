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
    }
}
