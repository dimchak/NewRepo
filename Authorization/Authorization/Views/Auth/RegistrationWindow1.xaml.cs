using System.Windows;
using Authorization.Models;
using Authorization.Storages;

namespace Authorization.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow1.xaml
    /// </summary>
    public partial class RegistrationWindow1 : Window
    {
        private UserStorage userStorage { get; } = new UserStorage();
        public RegistrationWindow1()
        {
            InitializeComponent();

            Registration_Button.Click += Registration_Button_Click;
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            var inputLogin = RegLogin_TextBox.Text;
            var inputPassword = RegPass_TextBox.Text;
            var confirmPassword = RegConfirm_TextBox.Text;

            if (string.IsNullOrEmpty(inputLogin))
            {
                MessageBox.Show("Поле \"Логин\" не может быть пустым");
                return;
            }
            else
            {
                foreach (char s in inputLogin)
                {
                    if (!Char.IsLetter(s) && !Char.IsNumber(s))
                    {
                        MessageBox.Show("Поле \"Логин\" может состоять только из букв и цифр");
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("Поле \"Пароль\" не может быть пустым");
                return;
            }

            if (inputPassword != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                RegPass_TextBox.Text = "";
                RegConfirm_TextBox.Text = "";
                return;
            }

            var users = UserStorage.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Login == inputLogin)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    RegLogin_TextBox.Text = "";
                    RegPass_TextBox.Text = "";
                    RegConfirm_TextBox.Text = "";
                    return;
                }
            }

            var registeredUser = new User(inputLogin, inputPassword, true, false);

            userStorage.Add(registeredUser);

            MessageBox.Show("Аккаунт создан");
            Close();

        }
    }
}
