using Microsoft.EntityFrameworkCore;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Service
{
    public class PostService : IPost
    {
        private readonly UserDbContext _context;

        public PostService(UserDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.Include(a => a.user).ToList();
        }

        public Post getDetails(int id)
        {
            return _context.Posts.Include(u => u.user).FirstOrDefault(a => a.PostId == id) ?? new Post();
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }


        public void DelPost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

    }
}
