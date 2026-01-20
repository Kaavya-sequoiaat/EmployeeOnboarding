using Prism.Commands;
using Prism.Mvvm;


namespace EmployeeOnboarding.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand NavigateHomeCommand { get; }
        public DelegateCommand NavigateAddEmployeeCommand { get; }
        public DelegateCommand NavigateEmployeeListCommand { get; }

        public DashboardViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateHomeCommand =
                new DelegateCommand(() =>
                    _regionManager.RequestNavigate("ContentRegion", nameof(Views.HomeView)));

            NavigateAddEmployeeCommand =
                new DelegateCommand(() =>
                    _regionManager.RequestNavigate("ContentRegion", nameof(Views.AddEmployeeView)));

            NavigateEmployeeListCommand =
                new DelegateCommand(() =>
                    _regionManager.RequestNavigate("ContentRegion", nameof(Views.EmployeeListView)));
        }
    }
}
