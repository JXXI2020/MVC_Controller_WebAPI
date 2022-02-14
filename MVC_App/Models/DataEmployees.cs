using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_App.Models;

namespace MVC_App.Models
{
    public class DataEmployees
    {
        public string status { get; set; }
        public List<MVC_App.Models.Employee> data { get; set; }
        public string message { get; set; }

    }
}
