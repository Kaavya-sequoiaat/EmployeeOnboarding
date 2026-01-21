using Prism.Mvvm;
using Prism.Commands;
using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace EmployeeOnboarding.ViewModels
{
    public class EmployeeListViewModel : BindableBase, INavigationAware
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegionManager _regionManager;

        public ObservableCollection<Employee> Employees { get; }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
                EditEmployeeCommand.RaiseCanExecuteChanged();
                DeleteEmployeeCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand AddEmployeeCommand { get; }
        public DelegateCommand EditEmployeeCommand { get; }
        public DelegateCommand DeleteEmployeeCommand { get; }

        public EmployeeListViewModel(
            IEmployeeService employeeService,
            IRegionManager regionManager)
        {
            MessageBox.Show("EmployeeListViewModel CREATED");
            _employeeService = employeeService;
            _regionManager = regionManager;

            Employees = new ObservableCollection<Employee>();

            AddEmployeeCommand = new DelegateCommand(() =>
                _regionManager.RequestNavigate(
                    "ContentRegion",
                    nameof(Views.AddEmployeeView)));

            EditEmployeeCommand =
                new DelegateCommand(EditEmployee, CanModifyEmployee);

            DeleteEmployeeCommand =
                new DelegateCommand(DeleteEmployee, CanModifyEmployee);
        }

        

        private void LoadEmployees()
        {
            Employees.Clear();

            var list = _employeeService.GetEmployees();

            MessageBox.Show($"Employees fetched from DB: {list.Count}");

            foreach (var emp in list)
            {
                Employees.Add(emp);
            }
        }

        private bool CanModifyEmployee()
        {
            return SelectedEmployee != null;
        }

        private void EditEmployee()
        {
            var navParams = new NavigationParameters
            {
                { "employee", SelectedEmployee }
            };

            _regionManager.RequestNavigate(
                "ContentRegion",
                nameof(Views.AddEmployeeView),
                navParams);
        }

        private void DeleteEmployee()
        {
            var result = MessageBox.Show(
                $"Are you sure you want to delete {SelectedEmployee.FirstName}?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            _employeeService.DeleteEmployee(SelectedEmployee.EmployeeId);
            LoadEmployees();
        }

        
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            LoadEmployees();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }
    }
}
