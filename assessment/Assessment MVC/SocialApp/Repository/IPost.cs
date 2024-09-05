using MVCAssessment.Models;

namespace MVCAssessment.Repository
{
    public interface IPost
    {
        public IEnumerable<Post> GetPosts();

        public Post getDetails(int id);

        public void CreatePost(Post post);

        public void EditPost(Post post);

        public void DelPost(Post post);
    }
}
