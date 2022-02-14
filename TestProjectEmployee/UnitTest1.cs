using NUnit.Framework;
using MVC_App.Business;
using MVC_App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProjectEmployee
{
    [TestFixture]
    public class Tests
    {

        IEmployeeBL repository;

        [SetUp]
        public void Setup()
        {
            repository = new EmployeeBL();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public IEmployeeBL GetRepository()
        {
            return repository;
        }

        [Test(Description = "validate rule")]
        public void calculateSalary()
        {
            List<Employee> employee = new List<Employee>();
            Employee employee1 = new Employee();
            employee1.employee_salary = 10;
            employee.Add(employee1);

            List<Employee> response = repository.calculateSalary(employee);
            Assert.AreEqual(120,(response[0].employee_anual_salary));
        }
    }
}