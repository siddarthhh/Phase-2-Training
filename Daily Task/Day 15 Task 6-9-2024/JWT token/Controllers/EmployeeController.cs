using ApiEx.Models;
using ApiEx.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _ser;
        public EmployeeController(EmployeeService ser)
        {
            _ser = ser;
        }


        [Authorize(Roles = "admin,employee")]
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _ser.GetAllEmployee();
        }

        [Authorize(Roles = "admin,employee")]

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _ser.GetEmployeeById(id);
        }

        [Authorize(Roles = "admin")]

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task AddEmployee(Employee employee)
        {
            await _ser.AddEmployee(employee);
        }
        [Authorize(Roles = "employee")]
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody]Employee employee)
        {

            //if (id == employee.EmpId)
            //{
                    await _ser.UpdateEmployee(employee);
                    return Ok("Update");
            //}
            //else return Ok("NOt match");
        }

        [Authorize(Roles = "admin,employee")]
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _ser.DeleteEmployee(id);
        }
    }
}
