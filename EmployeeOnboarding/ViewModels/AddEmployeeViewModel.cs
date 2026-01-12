using EmployeeOnboarding.Commands;
using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;
using System.Windows;
using System.Windows.Input;

namespace EmployeeOnboarding.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        private readonly EmployeeService _service = new();

        private Employee _employee = new();
        public Employee Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }

        public ICommand SaveCommand { get; }

        public AddEmployeeViewModel()
        {
            SaveCommand = new RelayCommand(_ => Save());
        }

        private void Save()
        {
            _service.AddEmployee(Employee);
            MessageBox.Show("Employee added successfully!");

            // Reset form
            Employee = new Employee(); // ✅ PropertyChanged raised automatically
        }
    }
}
