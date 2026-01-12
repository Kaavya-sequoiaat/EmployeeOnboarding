using System;
using System.Windows.Controls;

namespace EmployeeOnboarding.Services
{
    public class NavigationService
    {
        private static NavigationService _instance;
        public static NavigationService Instance => _instance ??= new NavigationService();

        public Action<UserControl> NavigateAction { get; set; }

        public void Navigate(UserControl page)
        {
            NavigateAction?.Invoke(page);
        }
    }
}
