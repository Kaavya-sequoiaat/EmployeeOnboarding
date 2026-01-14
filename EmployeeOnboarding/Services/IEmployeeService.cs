using System.Collections.Generic;
using EmployeeOnboarding.Models;

namespace EmployeeOnboarding.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
    }
}
