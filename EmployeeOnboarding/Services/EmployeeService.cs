using EmployeeOnboarding.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace EmployeeOnboarding.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("SELECT * FROM EmployeeInfo", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    EmployeeId = (int)reader["EmployeeId"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Department = reader["Department"].ToString(),
                    Position = reader["Position"].ToString(),
                    DateOfJoining = reader["DateOfJoining"] as DateTime? ?? DateTime.Now,
                    Status = reader["Status"].ToString(),
                    CreatedDate = (DateTime)reader["CreatedDate"]
                });
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                INSERT INTO EmployeeInfo
                (FirstName, LastName, Email, Phone, Department, Position, DateOfJoining, Status)
                VALUES
                (@FirstName, @LastName, @Email, @Phone, @Department, @Position, @DateOfJoining, @Status)", conn);

            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Email", employee.Email ?? "");
            cmd.Parameters.AddWithValue("@Phone", employee.Phone ?? "");
            cmd.Parameters.AddWithValue("@Department", employee.Department ?? "");
            cmd.Parameters.AddWithValue("@Position", employee.Position ?? "");
            cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
            cmd.Parameters.AddWithValue("@Status", employee.Status ?? "");

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee employee)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(@"
                UPDATE EmployeeInfo SET
                FirstName=@FirstName,
                LastName=@LastName,
                Email=@Email,
                Phone=@Phone,
                Department=@Department,
                Position=@Position,
                DateOfJoining=@DateOfJoining,
                Status=@Status
                WHERE EmployeeId=@EmployeeId", conn);

            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Email", employee.Email ?? "");
            cmd.Parameters.AddWithValue("@Phone", employee.Phone ?? "");
            cmd.Parameters.AddWithValue("@Department", employee.Department ?? "");
            cmd.Parameters.AddWithValue("@Position", employee.Position ?? "");
            cmd.Parameters.AddWithValue("@DateOfJoining", employee.DateOfJoining);
            cmd.Parameters.AddWithValue("@Status", employee.Status ?? "");

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmployee(int employeeId)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(
                "DELETE FROM EmployeeInfo WHERE EmployeeId=@EmployeeId", conn);

            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
