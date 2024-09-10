using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using MusicApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidUsersController : ControllerBase
    {
        private readonly ValidUserService _service;

        public ValidUsersController(ValidUserService service)
        {
            _service = service;
        }

        // GET: api/ValidUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidUser>>> GetValidUsers()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        // GET: api/ValidUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValidUser>> GetValidUser(int id)
        {
            var validUser = await _service.GetByIdAsync(id);

            if (validUser == null)
            {
                return NotFound();
            }

            return validUser;
        }

        // PUT: api/ValidUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValidUser(int id, ValidUser validUser)
        {
            var updatedUser = await _service.UpdateAsync(id, validUser);

            if (updatedUser == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/ValidUsers
        [HttpPost]
        public async Task<ActionResult<ValidUser>> PostValidUser(ValidUser validUser)
        {
            var createdUser = await _service.AddAsync(validUser);
            return CreatedAtAction(nameof(GetValidUser), new { id = createdUser.UserId }, createdUser);
        }

        // DELETE: api/ValidUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValidUser(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
