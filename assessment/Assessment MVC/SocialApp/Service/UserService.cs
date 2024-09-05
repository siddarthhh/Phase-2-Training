using Microsoft.EntityFrameworkCore;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Service
{
    public class UserService : IUser
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(a => a.Posts).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Include(p => p.Posts).FirstOrDefault(i => i.UId == id) ?? new User();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}
