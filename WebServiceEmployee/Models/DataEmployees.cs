using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceEmployee.Models;

namespace WebServiceEmployee.Models
{
    public class DataEmployees
    {
        public string status { get; set; }
        public List<WebServiceEmployee.Models.Employee> data { get; set; }
        public string message { get; set; }

    }
}
