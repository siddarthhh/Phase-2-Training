using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAssessment.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content   { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User? user { get; set; }
    }
}
