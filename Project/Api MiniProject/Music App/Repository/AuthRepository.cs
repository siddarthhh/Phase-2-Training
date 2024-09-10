using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicApp.Interface;
using MusicApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicApp.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly MusicDbContext _context;
        private readonly SymmetricSecurityKey _key;

        public AuthRepository(IConfiguration configuration, MusicDbContext context)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]!));
        }

        public async Task<bool> ValidateUserAsync(string email, string password, string requiredRole)
        {
            var user = await _context.ValidUsers
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            return user != null && user.Role == requiredRole;
        }

        public string GenerateToken(ValidUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role!) // Add the user's role as a claim
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
