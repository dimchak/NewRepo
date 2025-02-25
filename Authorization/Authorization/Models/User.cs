namespace Authorization.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsSignIn { get; set; }

        public bool IsRemember { get; set; }

        public User(string login, string password, bool isSignIn, bool isRemember)
        {
            Login = login;
            Password = password;
            IsSignIn = isSignIn;
            IsRemember = isRemember;
        }
    }
}