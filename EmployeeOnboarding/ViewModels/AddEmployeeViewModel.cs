using Prism.Mvvm;
using Prism.Commands;
using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;
using System;

namespace EmployeeOnboarding.ViewModels
{
    public class AddEmployeeViewModel : BindableBase, INavigationAware
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegionManager _regionManager;
        private bool _isEdit;

        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set => SetProperty(ref _employee, value);
        }

        public DelegateCommand SaveCommand { get; }

        public AddEmployeeViewModel(
            IEmployeeService employeeService,
            IRegionManager regionManager)
        {
            _employeeService = employeeService;
            _regionManager = regionManager;

            Employee = new Employee
            {
                DateOfJoining = DateTime.Today
            };

            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            if (_isEdit)
                _employeeService.UpdateEmployee(Employee);
            else
                _employeeService.AddEmployee(Employee);

            // 🔥 THIS IS THE KEY LINE        
            _regionManager.RequestNavigate(
                "ContentRegion",
                nameof(Views.EmployeeListView));
        }

        public bool IsNavigationTarget(INavigationParameters parameters) => true;
        public void OnNavigatedFrom(INavigationParameters parameters) { }
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("employee"))
            {
                // EDIT MODE
                Employee = parameters.GetValue<Employee>("employee");
                _isEdit = true;
            }
            else
            {
                // ADD MODE (🔥 THIS WAS MISSING)
                Employee = new Employee
                {
                    DateOfJoining = DateTime.Today
                };
                _isEdit = false;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
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
