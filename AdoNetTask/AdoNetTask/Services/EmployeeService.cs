using AdoNetTask.DataBase;
using AdoNetTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTask.Services
{
    internal class EmployeeService
    {
        AppDbContext dbContext;
        public EmployeeService()
        {
            this.dbContext = new AppDbContext();
        }

        public void Create(Employee employee)
        {
            if (employee != null && !string.IsNullOrEmpty(employee.Name) && !string.IsNullOrEmpty(employee.Surname))
            {
                string createCommand = $"INSERT INTO Employees VALUES ('{employee.Name}','{employee.Surname}', '{employee.Salary}')";
                int result = dbContext.NonQuery(createCommand);
                if (result > 0)
                    Console.WriteLine("Employee created +.");
                else
                    Console.WriteLine("Failed to create employee.");
            }
            else
            {
                Console.WriteLine("Invalid information.");
            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                string query = "select * from Employees";
                DataTable table = dbContext.Query(query);
                foreach (DataRow item in table.Rows)
                {
                    Employee emp = new Employee()
                    {
                        Id = int.Parse(item["Id"].ToString()),
                        Name = item["Name"].ToString(),
                        Surname = item["Surname"].ToString(),
                        Salary = double.Parse(item["Salary"].ToString())
                    };
                    list.Add(emp);
                }
            }
            catch(Exception  ex)
            {
                Console.WriteLine($"Error for GetAll methods: {ex.Message}");
            }
            
            return list;
        }

        public void Delete(int id)
        {
            string command = $"delete from Employees where id = {id}";
            int result = dbContext.NonQuery(command);
            if (result > 0)
                Console.WriteLine("Employee deleted.");
            else
                Console.WriteLine("Failed to delete employee.");

        }

        public void Update(int id, double salary)
        {
            if (id > 0)
            {
                string command = $"update Employees set Salary = {salary} where Id = {id}";
                int result = dbContext.NonQuery(command);
                if (result > 0)
                    Console.WriteLine("Employee salary updated.");
                else
                    Console.WriteLine("Failed to update employee salary.");
            }
            else
            {
                Console.WriteLine("Enter the correct ID.");
            }
        }
       
    }
}
