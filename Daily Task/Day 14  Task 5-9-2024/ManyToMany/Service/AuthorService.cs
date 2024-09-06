using API_Many_to_Many__C_.Interface;
using API_Many_to_Many__C_.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API_Many_to_Many__C_.Service
{
    public class AuthorService : IAuthor
    {
        private readonly IAuthor _auth;

        public AuthorService(IAuthor auth)
        {
            _auth = auth;
        }

        public async Task AddAuthor(Author author)
        {
           await  _auth.AddAuthor(author);
        }

        public async Task DeleteAuthor(int id)
        {
            await _auth.DeleteAuthor(id);
        }

        public async Task<IEnumerable<Author>> GetallAuthors()
        {
            return await _auth.GetallAuthors();
        }

        public async Task<Author> Getauthorbyid(int id)
        {
            return await _auth.Getauthorbyid(id);
        }

        public async Task UpdateAuthor(Author author)
        {
            await _auth.UpdateAuthor(author);
        }
    }
}
