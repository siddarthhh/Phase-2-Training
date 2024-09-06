using API_Many_to_Many__C_.Models;

namespace API_Many_to_Many__C_.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> Getallbooks();

        Task<Book> Getbookbyid(int id);

        Task Addbooks(Book book);

        Task Updatebooks(Book book);

        Task Deletebooks(int id);


    }
}
