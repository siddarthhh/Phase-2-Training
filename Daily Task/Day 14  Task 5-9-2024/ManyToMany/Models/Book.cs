using System.ComponentModel.DataAnnotations;

namespace API_Many_to_Many__C_.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public ICollection<BookAuthor>? BookList { get; set; }
    }
}
