using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace EmployeeOnboarding.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand LoginCommand { get; }

        public LoginViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            if (Username == "admin" && Password == "1234")
            {
                _regionManager.RequestNavigate(
     "MainRegion",
     nameof(Views.DashboardView));
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
