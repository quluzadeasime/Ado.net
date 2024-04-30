// See https://aka.ms/new-console-template for more information
using AdoNetTask.Models;
using AdoNetTask.Services;

Employee employee = new Employee
{
    Name = "Asime",
    Surname = "Quluzade",
    Salary = 150
};
Employee employee1 = new Employee
{
    Name = "Fatime",
    Surname = "Eliyeva",
    Salary = 140
};

EmployeeService employeeService = new EmployeeService();
//employeeService.Create(employee);
//employeeService.Create(employee1);

//foreach(var item in employeeService.GetAll())
//{
//    Console.WriteLine(item);
//}
//employeeService.Delete(1);
employeeService.Update(2, 500);