using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraBugTracker.API.Data;
using UltraBugTracker.API.Models;

namespace UltraBugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/bugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetAsync()
        {
            var bugs = await _context.Bugs.AsNoTracking().ToListAsync();
            return Ok(bugs);
        }

        // GET api/bugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetAsync(int id)
        {
            var bug = await _context.Bugs.FindAsync(id);
            return Ok(bug);
        }

        // POST api/bugs
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

        // PUT api/bugs/5
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

        // DELETE api/bugs/5
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
