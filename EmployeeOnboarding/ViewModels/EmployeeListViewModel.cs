using EmployeeOnboarding.Commands;
using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;
using EmployeeOnboarding.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EmployeeOnboarding.ViewModels

{
    public class EmployeeListViewModel : BaseViewModel
    {
        private readonly EmployeeService _service = new();

        public ObservableCollection<Employee> Employees { get; }

        public ICommand DeleteCommand { get; }

        public EmployeeListViewModel()
        {
            Employees = new ObservableCollection<Employee>(_service.GetEmployees());
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete(object parameter)
        {
            if (parameter is not Employee emp) return;

            if (MessageBox.Show($"Delete {emp.FirstName}?",
                "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _service.DeleteEmployee(emp.EmployeeId);
                Employees.Remove(emp);
            }
        }
    }
}

