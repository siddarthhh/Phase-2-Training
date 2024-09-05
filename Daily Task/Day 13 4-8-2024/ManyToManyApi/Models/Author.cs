using System.ComponentModel.DataAnnotations;

namespace ManyToManyApi.Models
{
    public class Author
    {
        [Key]
        public int AuthorId {  get; set; }
        public string? AuthorName { get; set; }

        public ICollection<BookAuthor>? bookAuthorsList { get; set; }

    }
}
