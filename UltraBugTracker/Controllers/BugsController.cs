using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UBT.API.Data;
using UBT.Common.API.Models;

namespace UBT.API.Controllers
{
    [ApiController, Route("[controller]"), Authorize]
    public class BugsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetAsync()
        {
            var bugs = await _context.Bugs.AsNoTracking().ToListAsync();
            return Ok(bugs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetAsync(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            return Ok(bug);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Bug bug)
        {
            if (!(await _context.Bugs.AnyAsync(b => b.Id == id)))
            {
                return NotFound();
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            _context.Bugs.Update(bug);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!(await _context.Bugs.AnyAsync(b => b.Id == id)))
            {
                return NotFound();
            }

            var bug = new Bug() {Id = id};
            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
