using WebServiceEmployee.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebServiceEmployee.Business
{
    public class EmployeeBL : IEmployeeBL
    {

        IConfiguration Configuration;

        public EmployeeBL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
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

        public async Task<List<Employee>> GetByIdAsync(string id)
        {
            var json = "";
            HttpClient httpclient = new HttpClient();
            json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employee/" + id);
            
            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeListIni = cons.data;
            List<Employee> employeeList = calculateSalary(employeeListIni);

            return employeeList;
        }

        public async Task<List<Employee>> Get()
        {
            var json = "";
            HttpClient httpclient = new HttpClient();
            json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            
            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeListIni = cons.data;
            List<Employee> employeeList = calculateSalary(employeeListIni);

            return employeeList;
        }
    }
}
