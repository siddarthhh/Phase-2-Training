using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManyToManyApi.Models;

namespace ManyToManyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookAuthorDbContext _context;

        public BooksController(BookAuthorDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Getbooks()
        {
            return await _context.books.Include(e => e.bookList).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.books.Any(e => e.BookId == id);
        }
    }
}
