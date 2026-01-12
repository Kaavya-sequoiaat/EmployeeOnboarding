using EmployeeOnboarding.Commands;
using System.Windows;
using System.Windows.Input;

namespace EmployeeOnboarding.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        public Action OnLoginSuccess { get; set; }
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        // PasswordBox cannot bind two-way by default, we'll handle via code-behind
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(_ => Login());
        }

        private void Login()
        {
            if (Username == "admin" && Password == "1234")
            {
                OnLoginSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
