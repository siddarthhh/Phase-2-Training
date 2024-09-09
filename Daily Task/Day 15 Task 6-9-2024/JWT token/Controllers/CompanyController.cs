using ApiEx.Models;
using ApiEx.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _ser;
        public CompanyController(CompanyService ser)
        {
            _ser = ser;
        }



        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _ser.GetAllCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<Company> GetCompanyById(int id)
        {
            return await _ser.GetCompanyById(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task AddCompany(Company company)
        {
            await _ser.AddCompany(company);
        }
        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
