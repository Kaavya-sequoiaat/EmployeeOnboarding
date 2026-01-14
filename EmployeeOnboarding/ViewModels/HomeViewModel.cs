using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace EmployeeOnboarding.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public int TotalEmployees { get; set; }
        public int AddedToday { get; set; }
        public int AddedThisMonth { get; set; }

        public ObservableCollection<object> RecentEmployees { get; } = new();

        public HomeViewModel()
        {
            // temporary data (or inject service later)
            TotalEmployees = 10;
            AddedToday = 2;
            AddedThisMonth = 5;
        }
    }
}
