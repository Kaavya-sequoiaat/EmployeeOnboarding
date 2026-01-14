using Prism.Commands;
using Prism.Mvvm;


namespace EmployeeOnboarding.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager; 

        public DelegateCommand NavigateEmployeesCommand { get; }

        public DashboardViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateEmployeesCommand = new DelegateCommand(() =>
                _regionManager.RequestNavigate("MainRegion", "EmployeeListPage"));
        }
    }
}
