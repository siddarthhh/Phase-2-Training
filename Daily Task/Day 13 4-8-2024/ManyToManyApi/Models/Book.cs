using System.ComponentModel.DataAnnotations;

namespace ManyToManyApi.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }

        public ICollection<BookAuthor> bookList { get; set; }


    }
}
