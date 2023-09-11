
using demo1;
using empwebapi.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace empwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpContext _context;
        public EmpController(EmpContext context)
        {
            _context = context;
        }
        private static List<Employee> emps = new List<Employee>()
            {
                new Employee {Id=101,Name="kiran",Place="bangalore"},
                new Employee { Id=102,Name="mahesh",Place="chennai"},
                new Employee {Id=103,Name="sita",Place="Delhi"}
            };

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpGet("emp2")]
        public async Task<ActionResult<List<Employee>>> GetEmployees2()
        {

            return Ok(emps);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> addEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());


            //emps.Add(emp);
            //return Ok(emps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }

            return Ok(employee);


            //var employee = emps.Find(x => x.Id == id);
            //if (employee != null)
            //{
            //    return Ok(employee);
            //}
            //else
            //{
            //    return BadRequest("employee not found");
            //}
        }
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> updateEmployee(Employee emp)

        {
            var employee = await _context.Employees.FindAsync(emp.Id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }

            employee.Name = emp.Name;
            employee.Place = emp.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());

            //var employee = emps.Find(x => x.Id == emp.Id);
            //if (employee != null)
            //{
            //    employee.Name = emp.Name;
            //    employee.Place = emp.Place;
            //}
            //return Ok(emps);

        }
        [HttpDelete]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());

            //var employee = emps.Find(x => x.Id == id);
            //if (employee != null)
            //{
            //    emps.Remove(employee);
            //    return Ok(employee);
            //}
            //else
            //{
            //    return BadRequest("emloyee not found");
            //}

        }


    }
}

