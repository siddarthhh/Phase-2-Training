using MVCAssessment.Models;

namespace MVCAssessment.Repository
{
    public interface IUser
    {
        public IEnumerable<User> GetUsers();

        public User GetUser(int id);

        public void CreateUser(User user);

        public void EditUser(User user);

        public void DeleteUser(User user);

    }
}
