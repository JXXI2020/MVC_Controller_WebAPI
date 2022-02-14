using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WebAPI_App.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebAPI_App.Business;

namespace WebAPI_App.Controllers
{
    public class EmployeeAPIController : ApiController
    {

        //private readonly IEmployeeBL _business;

        //public EmployeeAPIController(IEmployeeBL business)
        //{
        //    _business = business;
        //}

        [Route("api/EmployeeAPI/GetEmployee/")]
        [HttpGet]
        public async Task<List<Employee>> GetEmployee(string id)
        {
            var json = "";
            HttpClient httpclient = new HttpClient();
            if (id == "")
                json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employees");
            else
            {
                json = await httpclient.GetStringAsync("http://dummy.restapiexample.com/api/v1/employee/" + id);
            }
            DataEmployees cons = JsonConvert.DeserializeObject<DataEmployees>(json);
            List<Employee> employeeListIni = cons.data;
            List<Employee> employeeList = null; //_business.calculateSalary(employeeListIni);

            return employeeList;

        }
    }
}
