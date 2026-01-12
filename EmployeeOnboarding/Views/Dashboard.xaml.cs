using EmployeeOnboarding.ViewModels;
using System.Windows;

namespace EmployeeOnboarding.Views
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
