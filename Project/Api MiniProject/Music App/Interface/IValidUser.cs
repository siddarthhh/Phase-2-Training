using MusicApp.Models;

namespace MusicApp.Interface
{
    public interface IValidUser
    {
        Task<IEnumerable<ValidUser>> GetAllAsync();
        Task<ValidUser> GetByIdAsync(int id);
        Task<ValidUser> AddAsync(ValidUser validUser);
        Task<ValidUser> UpdateAsync(ValidUser validUser);
        Task<bool> DeleteAsync(int id);
        bool Exists(int id);
    }
}
