using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Script.Serialization;
using MVC_App.Models;
using MVC_App.Business;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MVC_App.Controllers
{
    public class HomeController : Controller
    {
       

        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<Employee> customers = await SearchCustomers("");
            return View(customers);
        }

        [HttpPost]
        public async Task<ActionResult> Index(string id)
        {
            List<Employee> customers = await SearchCustomers(id);
            return View(customers);
        }

        private async Task<List<Employee>> SearchCustomers(string id)
        {            
            var json = "";
            DataEmployees consS = new DataEmployees();
            DataEmployee cons = new DataEmployee();
            HttpClient httpclient = new HttpClient(); 
            List<Employee> employeeSList = new List<Employee>();
            Employee employee = new Employee();

            if (id == "") 
            { 
                json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
                consS = JsonConvert.DeserializeObject<DataEmployees>(json);
                if (consS != null)
                {
                    List<Employee> employeeListIni = consS.data;
                    EmployeeBL employeeBL = new EmployeeBL();
                    employeeSList = employeeBL.calculateSalary(employeeListIni);
                }
            }
            else
            {
                json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employee/" + id);
                cons = JsonConvert.DeserializeObject<DataEmployee>(json);
                
                if (cons != null)
                {
                    Employee employeeIni = cons.data;
                    EmployeeBL employeeBL = new EmployeeBL();
                    employee = employeeBL.SalaryRule(employeeIni);                                      
                    employeeSList.Add(employee);                    
                }
            }

            return employeeSList;
        }
    }
}