using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using EmployeeOnboarding.Views;
using EmployeeOnboarding.Services;
namespace EmployeeOnboarding
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEmployeeService, EmployeeService>();

            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.RegisterForNavigation<DashboardView>();
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<EmployeeListView>();
            containerRegistry.RegisterForNavigation<AddEmployeeView>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Container.Resolve<IRegionManager>()
                .RequestNavigate("MainRegion", nameof(Views.LoginView));
        }

    }
}
