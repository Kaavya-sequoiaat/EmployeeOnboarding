using System.Collections.Generic;
using EmployeeOnboarding.Models;

namespace EmployeeOnboarding.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new();

        public List<Employee> GetEmployees() => _employees;

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
    }
}
