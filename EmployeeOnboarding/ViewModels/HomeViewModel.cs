using EmployeeOnboarding.Models;
using EmployeeOnboarding.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace EmployeeOnboarding.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly EmployeeService _service = new();

        private int _totalEmployees;
        public int TotalEmployees
        {
            get => _totalEmployees;
            set => SetProperty(ref _totalEmployees, value);
        }

        private int _addedToday;
        public int AddedToday
        {
            get => _addedToday;
            set => SetProperty(ref _addedToday, value);
        }

        private int _addedThisMonth;
        public int AddedThisMonth
        {
            get => _addedThisMonth;
            set => SetProperty(ref _addedThisMonth, value);
        }

        private ObservableCollection<Employee> _recentEmployees;
        public ObservableCollection<Employee> RecentEmployees
        {
            get => _recentEmployees;
            set => SetProperty(ref _recentEmployees, value);
        }

        public HomeViewModel()
        {
            Load();
        }

        private void Load()
        {
            var list = _service.GetEmployees();

            TotalEmployees = list.Count;
            AddedToday = list.Count(e => e.CreatedDate.Date == DateTime.Today);
            AddedThisMonth = list.Count(e => e.CreatedDate.Month == DateTime.Now.Month);

            RecentEmployees = new ObservableCollection<Employee>(
                list.OrderByDescending(e => e.CreatedDate).Take(5)
            );
        }
    }
}
