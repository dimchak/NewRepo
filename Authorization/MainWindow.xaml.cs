using System.Windows;
using System.Windows.Controls;
using Authorization.Models;
using Authorization.Storages;
using Authorization.Views.Auth;

namespace Authorization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserStorage userStorage { get; } = new UserStorage();

        public MainWindow()
        {
            InitializeComponent();

            Register_Button.Click += Register_Button_Click;
            SignOut_Button.Click += SignOut_Button_Click;
            SignIn_Button.Click += SignIn_Button_Click;
            Loaded += MainWindow_Loaded;

            WeatherDays_ListBox.ItemsSource = WeatherDataStorage.GetAll();
        }

        private void WeatherDayButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var day = button.DataContext as DayForecastModel;

                Details_StackPanel.DataContext = day;
                HourlyForecastDetails_StackPanel.ItemsSource = day.HourlyForecasts;

                Interval_Label.Content = $"Weather forecast {day.Date.AddDays(-3).ToString("MM dd")} - {day.Date.AddDays(3).ToString("MM dd")}";
            }
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            var signInWindow = new AuthorizationWindow();
            signInWindow.ShowDialog();

            var user = userStorage.GetSignInUser();
            if (user != null)
            {
                Authorized(user);
            }
            else
            {
                UnAuthorized();
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var signinUser = userStorage.GetSignInUser();
            var rememberUser = userStorage.GetRememberUser();

            if (rememberUser != null)
            {
                Authorized(rememberUser);
            }
            else
            {
                if (signinUser != null)
                {
                    Authorized(signinUser);
                }
                else
                {
                    UnAuthorized();
                }
            }
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {
            userStorage.SignOut();

            UnAuthorized();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var registration = new RegistrationWindow1();
            registration.ShowDialog();

            var user = userStorage.GetSignInUser();
            if (user != null)
            {
                Authorized(user);
            }
            else 
            { 
                UnAuthorized(); 
            }
            
        }
        private void UnAuthorized()
        {
            //LoginName_Label.Visibility = Visibility.Collapsed;
            //PersonalDesk_Label.Visibility = Visibility.Collapsed;
            SignOut_Button.Visibility = Visibility.Collapsed;
            SignIn_Button.Visibility = Visibility.Visible;
            Register_Button.Visibility = Visibility.Visible;
        }

        private void Authorized(User signUser)
        {
            //LoginName_Label.Content = signUser.Login;

            //LoginName_Label.Visibility = Visibility.Visible;
            //PersonalDesk_Label.Visibility = Visibility.Visible;
            SignOut_Button.Visibility = Visibility.Visible;
            SignIn_Button.Visibility = Visibility.Collapsed;
            Register_Button.Visibility = Visibility.Collapsed;
        }
    }
}