using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Authorization.ViewModels
{
    // все viewModel должны наследовать этот интерфейс
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // при нажатии на кнопку Home (в окне MainWindow) должна инициироваться некоторая команда
        // ICommand - это стандартный виндовсовский интерфейс. Через него работает паттерн MVVM
        public ICommand HomeCommand { get; }

        private HomeViewViewModel homeViewViewModel;
        public HomeViewViewModel HomeViewViewModel
        {
            get { return homeViewViewModel; }
            set
            {
                homeViewViewModel = value;
                OnPropertyChanged();  // в качестве аргумента ничего не передаем, т.к. атрибут в нашем методе автоматически подтянет необходимое свойство
            }
        }

        public MainWindowViewModel()
        {
            // в аргументы передаем функцию, которую нужно выполнить, когда выполнится команда HomeCommand
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
        }

        // метод, который говорит, когда мы можем выполнить функцию (в нашем случае - когда мы можем открыть HomeWindow)
        private bool CanOpenHomeView(object arg)
        {
            return true;  // у нас окно открывается всегда. Но вообще сюда можно зашить любую логику (открытие по правам доступа, авторизован/не авторизован и т.д.)
        }

        private void OpenHomeView(object obj)
        {
            HomeViewViewModel = new HomeViewViewModel();
        }

        // этот метод через атрибут CallerMemberName будет автоматически определять, какое свойство (Property) изменилось.
        // метод принимает название свойства (prop) и инициализирует событие PropertyChanged. А за этим событием уже следит вьюшка
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
