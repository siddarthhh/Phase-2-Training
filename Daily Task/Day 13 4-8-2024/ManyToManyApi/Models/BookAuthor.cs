namespace ManyToManyApi.Models
{
    public class BookAuthor
    {
        public int BookId {  get; set; }
        public Book? book { get; set; }
        public int AuthorId {  get; set; }
        public Author? author { get; set; }

    }
}
