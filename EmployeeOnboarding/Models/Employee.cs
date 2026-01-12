using System;

namespace EmployeeOnboarding.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public DateTime DateOfJoining { get; set; }

        // Used as Status / Address based on your UI
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
