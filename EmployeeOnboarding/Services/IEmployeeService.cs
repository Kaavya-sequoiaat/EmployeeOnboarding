using System.Collections.Generic;
using EmployeeOnboarding.Models;

namespace EmployeeOnboarding.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    
    }
}
