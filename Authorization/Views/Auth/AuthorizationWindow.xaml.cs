using System.Windows;
using Authorization.Storages;

namespace Authorization.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            Authorization_Button.Click += Authorization_Button_Click;
        }

        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            var currentLogin = Login_TextBox.Text;
            var currentPassword = Password_TextBox.Text;
            var isRemember = Remind_CheckBox.IsChecked;

            if (string.IsNullOrEmpty(currentLogin) || string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            else
            {
                var allUsers = UserStorage.GetAllUsers();

                bool isLoginFound = false;
                bool isPasswordFound = false;

                foreach ( var user in allUsers )
                {
                    if (user.Login == currentLogin)
                    {
                        isLoginFound = true;

                        if (user.Password == currentPassword)
                        {
                            isPasswordFound = true;
                            break;
                        }
                        break;
                    }
                }

                if (!isLoginFound)
                {
                    MessageBox.Show("Пользователя с таким логином не существует");
                }
                else
                {
                    if (!isPasswordFound)
                    {
                        MessageBox.Show("Вы ввели некорректный пароль");
                    }
                    else
                    {
                        var userStorage = new UserStorage();
                        userStorage.SignOut();
                        userStorage.SignIn(currentLogin, currentPassword);

                        if (isRemember == true)
                        {
                            userStorage.NotRemember();
                            userStorage.Remember(currentLogin);
                        }

                        MessageBox.Show("Вы успешно авторизованы");
                        Close();
                    }
                }

            }
        }
    }
}
