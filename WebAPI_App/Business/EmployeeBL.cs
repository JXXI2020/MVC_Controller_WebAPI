using WebAPI_App.Models;
using System.Collections.Generic;

namespace WebAPI_App.Business
{
    public class EmployeeBL : IEmployeeBL
    {
        public List<Employee> calculateSalary(List<Employee> employeeList)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                employeeList[i] = SalaryRule(employeeList[i]);
            }
            return employeeList;
        }
        
        public Employee SalaryRule(Employee employee)
        {
            Employee employee1 = employee;
            employee.employee_anual_salary = employee.employee_salary * 12;
            return employee1;
        }
    }
}
