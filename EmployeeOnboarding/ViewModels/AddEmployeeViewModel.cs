using Prism.Mvvm;
using Prism.Commands;
using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;


namespace EmployeeOnboarding.ViewModels
{
    public class AddEmployeeViewModel : BindableBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegionManager _regionManager;

        public Employee Employee { get; } = new();

        public DelegateCommand SaveCommand { get; }

        public AddEmployeeViewModel(
            IEmployeeService employeeService,
            IRegionManager regionManager)
        {
            _employeeService = employeeService;
            _regionManager = regionManager;
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            _employeeService.AddEmployee(Employee);

            _regionManager.RequestNavigate(
                "MainRegion",
                nameof(Views.EmployeeListView));
        }
    }
}
