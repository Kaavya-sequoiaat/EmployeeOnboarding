using EmployeeOnboarding.Models;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;


namespace EmployeeOnboarding.Services
{
    public class EmployeeService
    {
        private readonly string _connectionString =
            "Server=DESKTOP-6BGJJO3\\SQLEXPRESS;Database=EmployeeOnboarding;Trusted_Connection=True;TrustServerCertificate=True;";

        public void AddEmployee(Employee emp)
        {
            using SqlConnection con = new(_connectionString);
            string query = @"INSERT INTO EmployeeInfo
                (FirstName, LastName, Email, Phone, Department, Position, DateOfJoining, Status, CreatedDate)
                VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @Position, @DateOfJoining, @Status, @CreatedDate)";

            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Phone", emp.Phone);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            cmd.Parameters.AddWithValue("@Position", emp.Position);
            cmd.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
            cmd.Parameters.AddWithValue("@Status", emp.Status);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = new();
            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new("SELECT * FROM EmployeeInfo", con);

            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Employee
                {
                    EmployeeId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Phone = reader.GetString(4),
                    Department = reader.GetString(5),
                    Position = reader.GetString(6),
                    DateOfJoining = reader.GetDateTime(7),
                    Status = reader.GetString(8),
                    CreatedDate = reader.GetDateTime(9)
                });
            }
            return list;
        }

        public void DeleteEmployee(int id)
        {
            using SqlConnection con = new(_connectionString);
            using SqlCommand cmd = new("DELETE FROM EmployeeInfo WHERE EmployeeId=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

