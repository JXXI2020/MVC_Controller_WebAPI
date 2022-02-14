using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_App.Models;

namespace WebAPI_App.Models
{
    public class DataEmployees
    {
        public string status { get; set; }
        public List<WebAPI_App.Models.Employee> data { get; set; }
        public string message { get; set; }

    }
}
