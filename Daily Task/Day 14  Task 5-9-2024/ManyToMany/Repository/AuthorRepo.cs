using API_Many_to_Many__C_.Interface;
using API_Many_to_Many__C_.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Many_to_Many__C_.Repository
{
    public class AuthorRepo : IAuthor
    { 
    private readonly BookAuthorContext _context;

    public AuthorRepo(BookAuthorContext context)
    {
        _context = context;
    }
    public async Task AddAuthor(Author author)
    {
        await _context.author.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuthor(int id)
    {
        var del = await _context.author.FindAsync(id);
        _context.author.Remove(del);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Author>> GetallAuthors()
    {
        return await _context.author.Include(a => a.BookAuthorList).ThenInclude(b => b.Book).ToListAsync();
    }

    public async Task<Author> Getauthorbyid(int id)
    {
        return await _context.author.FindAsync(id);
    }

    public async Task UpdateAuthor(Author author)
    {
        _context.author.Update(author);
        await _context.SaveChangesAsync();
    }
}
}
