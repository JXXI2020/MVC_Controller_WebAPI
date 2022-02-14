using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace WebAPI_App.Controllers
{
    public class CustomerAPIController : ApiController
    {
        [Route("api/CustomerAPI/GetCustomers")]
        [HttpGet]
        public List<Customer> GetCustomers(string name)
        {
            NorthwindEntities entities = new NorthwindEntities();
            return (from c in entities.Customers.Take(10)
                    where c.ContactName.StartsWith(name) || string.IsNullOrEmpty(name)
                    select c).ToList();
        }
    }
}
