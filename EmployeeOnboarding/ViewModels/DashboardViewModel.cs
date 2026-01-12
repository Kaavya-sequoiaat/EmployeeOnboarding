using EmployeeOnboarding.Commands;
using System.Windows.Input;

namespace EmployeeOnboarding.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private object _currentPage;
        public object CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public ICommand ShowHomeCommand { get; }
        public ICommand ShowAddEmployeeCommand { get; }
        public ICommand ShowEmployeeListCommand { get; }

        public DashboardViewModel()
        {
            ShowHomeCommand = new RelayCommand(_ =>
                CurrentPage = new HomeViewModel());

            ShowAddEmployeeCommand = new RelayCommand(_ =>
                CurrentPage = new AddEmployeeViewModel());

            ShowEmployeeListCommand = new RelayCommand(_ =>
                CurrentPage = new EmployeeListViewModel());

            // Default page
            CurrentPage = new HomeViewModel();
        }
    }
}
