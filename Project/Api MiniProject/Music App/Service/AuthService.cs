using MusicApp.Interface;
using MusicApp.Models;
using MusicApp.Repository;

namespace MusicApp.Service
{
    public class AuthService
    {
        private readonly IAuth _authRepository;

        public AuthService(IAuth authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> ValidateUserAsync(string email, string password, string requiredRole)
        {
            return await _authRepository.ValidateUserAsync(email, password, requiredRole);
        }

        public string GenerateToken(ValidUser user)
        {
            return _authRepository.GenerateToken(user);
        }
    }
}

