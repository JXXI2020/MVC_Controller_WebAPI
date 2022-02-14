using WebAPI_App.Models;
using System.Collections.Generic;

namespace WebAPI_App.Business
{
    public interface IEmployeeBL
    {
        List<Employee> calculateSalary(List<Employee> employee);
    }
}
