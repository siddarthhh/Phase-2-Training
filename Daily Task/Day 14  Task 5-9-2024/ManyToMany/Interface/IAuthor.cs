using API_Many_to_Many__C_.Models;

namespace API_Many_to_Many__C_.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetallAuthors();

        Task<Author> Getauthorbyid(int id);

        Task AddAuthor(Author author);

        Task UpdateAuthor(Author author);

        Task DeleteAuthor(int id);
    }
}
