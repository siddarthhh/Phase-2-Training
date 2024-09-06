using API_Many_to_Many__C_.Interface;
using API_Many_to_Many__C_.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Many_to_Many__C_.Repository
{
    public class BookRepo : IBook
    {
        private readonly BookAuthorContext _context;

        public BookRepo(BookAuthorContext context)
        {
            _context = context;
        }
        public async Task Addbooks(Book book)
        {
          await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Deletebooks(int id)
        {
            var books = await _context.books.FindAsync(id);
            _context.books.Remove(books);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Getallbooks()
        {
            return await _context.books.Include(e=>e.BookList).ThenInclude(a=>a.Author).ToListAsync();
        }

        public async Task<Book> Getbookbyid(int id)
        {
           return await _context.books.FindAsync(id) ?? new Book();
        }

        public async Task Updatebooks(Book book)
        {
             _context.books.Update(book);
            await _context.SaveChangesAsync();

        }
    }
}
