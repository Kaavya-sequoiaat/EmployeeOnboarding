using EmployeeOnboarding.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EmployeeOnboarding.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set DataContext to LoginViewModel
            DataContext = new LoginViewModel();
            if (DataContext is LoginViewModel vm)
            {
                // Subscribe to login success event
                vm.OnLoginSuccess += Vm_OnLoginSuccess;
            }
        }
        private void Vm_OnLoginSuccess()
        {
            // Open Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

            // Close Login window
            this.Close();
        }

        // Sync PasswordBox password to ViewModel
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        // Handle Login Button Click
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                if (string.IsNullOrWhiteSpace(vm.Username) || string.IsNullOrWhiteSpace(vm.Password))
                {
                    MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Simple login check
                if (vm.Username == "admin" && vm.Password == "1234")
                {
                    MessageBox.Show(vm.Username,"success", MessageBoxButton.OK);
                    // Open Dashboard window
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();                  

                    // Close login window
                    this.Close();
                }
                else
                {                    
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
