using API_Many_to_Many__C_.Models;
using API_Many_to_Many__C_.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Many_to_Many__C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _ser;
        public AuthorsController(AuthorService ser)
        {
            _ser = ser;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _ser.GetallAuthors();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _ser.Getauthorbyid(id);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task Post([FromBody] Author value)
        {
           await  _ser.AddAuthor(value);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Author value)
        {
            await _ser.UpdateAuthor(value);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ser.DeleteAuthor(id);
        }
    }
}
