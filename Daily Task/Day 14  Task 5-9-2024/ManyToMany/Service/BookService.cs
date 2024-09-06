using API_Many_to_Many__C_.Interface;
using API_Many_to_Many__C_.Models;

namespace API_Many_to_Many__C_.Service
{
    public class BookService
    {
        private readonly IBook bk;

        public BookService(IBook bk)
        {
            this.bk = bk;
        }
        public async Task Addbooks(Book book)
        {
            await bk.Addbooks(book);
        }

        public async Task Deletebooks(int id)
        {
            await bk.Deletebooks(id);
        }

        public async Task<IEnumerable<Book>> Getallbooks()
        {
           return await bk.Getallbooks();
        }

        public async Task<Book> Getbookbyid(int id)
        {
            return await bk.Getbookbyid(id);
        }

        public async Task Updatebooks(Book book)
        {
            await bk.Updatebooks(book);
        }
    }
}
