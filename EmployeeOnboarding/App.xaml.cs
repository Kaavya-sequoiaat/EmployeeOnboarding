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

            containerRegistry.RegisterForNavigation<Home>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<Dashboard>();
            containerRegistry.RegisterForNavigation<EmployeeListPage>();
            containerRegistry.RegisterForNavigation<AddEmployeePage>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Container.Resolve<IRegionManager>()
                     .RequestNavigate("MainRegion", "Login");
        }

    }
}
