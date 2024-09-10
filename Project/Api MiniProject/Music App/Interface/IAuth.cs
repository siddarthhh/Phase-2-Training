using MusicApp.Models;

namespace MusicApp.Interface
{
    public interface IAuth
    {
        Task<bool> ValidateUserAsync(string email, string password, string requiredRole);
        string GenerateToken(ValidUser user);
    }
}
