using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace NTMSWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        Employees[] employees = new Employees[]
        {
            new Employees {Fname="Dinesh",Lname="Patil",Designation="Consultant",EmpID=100,city="Kalyan"},
            new Employees {Fname="Tushar",Lname="Patil",Designation="TechLead",EmpID=50,city="Thane"}

        };

        [HttpGet]
        public IEnumerable<Employees> ListAllEmployees()
        {
            return employees;

        }

        [HttpGet("empid/{id}")]
        public IEnumerable<Employees> ListEmployeeByEmpID(int id)
        {
            IEnumerable<Employees> searchEmployee = 
                from e in employees
                where e.EmpID.Equals(id)
                select e;

            return searchEmployee;
        }

        [HttpGet("city/{cityname}")]
        public IEnumerable<Employees> ListEmployeeBycity(string cityname)
        {
            IEnumerable<Employees> searchEmployee = 
                from e in employees
                where e.city.Equals(cityname)
                select e;

            return searchEmployee;
        }



    }
}
    // Fname, Lname, Designation, EmpID,city , CreationDate
    /* [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Employee
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    } */

