using Microsoft.EntityFrameworkCore;
using MusicApp.Interface;
using MusicApp.Models;

namespace MusicApp.Repository
{
    public class ValidUserRepository : IValidUser
    {
        private readonly MusicDbContext _context;

        public ValidUserRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ValidUser>> GetAllAsync()
        {
            return await _context.ValidUsers.ToListAsync();
        }

        public async Task<ValidUser> GetByIdAsync(int id)
        {
            return await _context.ValidUsers.FindAsync(id);
        }

        public async Task<ValidUser> AddAsync(ValidUser validUser)
        {
            _context.ValidUsers.Add(validUser);
            await _context.SaveChangesAsync();
            return validUser;
        }

        public async Task<ValidUser> UpdateAsync(ValidUser validUser)
        {
            _context.Entry(validUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return validUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var validUser = await _context.ValidUsers.FindAsync(id);
            if (validUser == null)
            {
                return false;
            }

            _context.ValidUsers.Remove(validUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Exists(int id)
        {
            return _context.ValidUsers.Any(e => e.UserId == id);
        }
    }
}
