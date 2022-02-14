using MVC_App.Models;
using System.Collections.Generic;

namespace MVC_App.Business
{
    public interface IEmployeeBL
    {
        List<Employee> calculateSalary(List<Employee> employee);
        Employee SalaryRule (Employee employee);
    }
}
