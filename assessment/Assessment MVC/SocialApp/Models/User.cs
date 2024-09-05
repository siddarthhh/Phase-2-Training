using System.ComponentModel.DataAnnotations;

namespace MVCAssessment.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }

        public ICollection<Post>? Posts { get; set; }

    }
}
