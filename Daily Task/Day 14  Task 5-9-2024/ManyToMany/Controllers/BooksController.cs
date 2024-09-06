using API_Many_to_Many__C_.Models;
using API_Many_to_Many__C_.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Many_to_Many__C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _ser;

        public BooksController(BookService ser)
        {
            _ser = ser;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _ser.Getallbooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _ser.Getbookbyid(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task Post([FromBody] Book value)
        {
            await _ser.Addbooks(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Book value)
        {
            await _ser.Updatebooks(value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ser.Deletebooks(id);
        }
    }
}
