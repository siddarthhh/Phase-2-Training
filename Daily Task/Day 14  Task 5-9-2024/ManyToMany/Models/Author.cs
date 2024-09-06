using System.ComponentModel.DataAnnotations;

namespace API_Many_to_Many__C_.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }


        public ICollection<BookAuthor>? BookAuthorList { get; set; }




    }
}
