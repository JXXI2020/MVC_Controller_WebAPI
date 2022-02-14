using WebServiceEmployee.Models;
using System.Collections.Generic;

namespace WebServiceEmployee.Business
{
    public interface IEmployeeBL
    {
        List<Employee> calculateSalary(List<Employee> employee);
        Task<List<Employee>> GetByIdAsync(string id);
        Task<List<Employee>> Get();
    }
}
