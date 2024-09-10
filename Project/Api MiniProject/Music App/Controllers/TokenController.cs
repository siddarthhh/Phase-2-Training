using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using MusicApp.Service;

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly AuthService _authService;

        public TokenController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> GenerateToken(ValidUser user)
        {
            if (await _authService.ValidateUserAsync(user.Email, user.Password, user.Role))
            {
                var token = _authService.GenerateToken(user);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
