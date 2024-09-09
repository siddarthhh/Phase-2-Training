using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiEx.Models;

namespace ApiEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidUsersController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public ValidUsersController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/ValidUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidUser>>> GetValidUsers()
        {
            return await _context.ValidUsers.ToListAsync();
        }

        // GET: api/ValidUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValidUser>> GetValidUser(int id)
        {
            var validUser = await _context.ValidUsers.FindAsync(id);

            if (validUser == null)
            {
                return NotFound();
            }

            return validUser;
        }

        // PUT: api/ValidUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValidUser(int id, ValidUser validUser)
        {
            if (id != validUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(validUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ValidUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValidUser>> PostValidUser(ValidUser validUser)
        {
            _context.ValidUsers.Add(validUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValidUser", new { id = validUser.UserId }, validUser);
        }

        // DELETE: api/ValidUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValidUser(int id)
        {
            var validUser = await _context.ValidUsers.FindAsync(id);
            if (validUser == null)
            {
                return NotFound();
            }

            _context.ValidUsers.Remove(validUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValidUserExists(int id)
        {
            return _context.ValidUsers.Any(e => e.UserId == id);
        }
    }
}
