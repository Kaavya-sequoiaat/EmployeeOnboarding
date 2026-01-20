using Prism.Mvvm;
using Prism.Commands;
using EmployeeOnboarding.Services;
using EmployeeOnboarding.Models;
using System.Collections.ObjectModel;


namespace EmployeeOnboarding.ViewModels
{
    public class EmployeeListViewModel : BindableBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegionManager _regionManager;

        public ObservableCollection<Employee> Employees { get; }

        public DelegateCommand AddEmployeeCommand { get; }

        public EmployeeListViewModel(
            IEmployeeService employeeService,
            IRegionManager regionManager)
        {
            _employeeService = employeeService;
            _regionManager = regionManager;

            Employees = new ObservableCollection<Employee>(
                _employeeService.GetEmployees());

            AddEmployeeCommand = new DelegateCommand(() =>
                _regionManager.RequestNavigate(
                    "MainRegion",
                    nameof(Views.AddEmployeeView)));
        }
    }
}
