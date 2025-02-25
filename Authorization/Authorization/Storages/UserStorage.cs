using Authorization.Models;

namespace Authorization.Storages
{
    public class UserStorage
    {
        private const string fileName = "Users.json";

        public User GetSignInUser()
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(x => x.IsSignIn);
        }

        public User GetRememberUser()
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(x => x.IsRemember);
        }

        public void Add(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            FileProvider.Save(users, fileName);
        }

        public static List<User> GetAllUsers()
        {
            return FileProvider.Load<List<User>>(fileName) ?? new List<User>();
        }

        public void SignOut()
        {
            var signInUser = GetSignInUser();

            if (signInUser != null)
            {
                var users = GetAllUsers();
                var existingUser = users.FirstOrDefault(x => x.Login == signInUser.Login && x.Password == signInUser.Password);
                existingUser.IsSignIn = false;
                FileProvider.Save(users, fileName);
            }
        }

        public void SignIn(string login, string password)
        {
            var users = GetAllUsers();
            var currentUser = users.FirstOrDefault(x => x.Login == login && x.Password == password);
            currentUser.IsSignIn = true;
            FileProvider.Save(users, fileName);
        }

        public void NotRemember()
        {
            var rememberUser = GetRememberUser();
            if (rememberUser != null)
            {
                var users = GetAllUsers();
                var existingUser = users.FirstOrDefault(x => x.Login == rememberUser.Login && x.Password == rememberUser.Password);
                existingUser.IsRemember = false;
                FileProvider.Save(users, fileName);
            }
        }

        public void Remember(string login)
        {
            var users = GetAllUsers();
            var existingUser = users.FirstOrDefault(x => x.Login == login);
            existingUser.IsRemember = true;
            FileProvider.Save(users, fileName);
        }
    }
}
