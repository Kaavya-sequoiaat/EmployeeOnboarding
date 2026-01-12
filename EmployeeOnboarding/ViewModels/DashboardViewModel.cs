namespace EmployeeOnboarding.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        // Example property for dashboard stats
        private int _totalEmployees;
        public int TotalEmployees
        {
            get => _totalEmployees;
            set => SetProperty(ref _totalEmployees, value);
        }

        public DashboardViewModel()
        {
            // Placeholder
            TotalEmployees = 0;
        }
    }
}
