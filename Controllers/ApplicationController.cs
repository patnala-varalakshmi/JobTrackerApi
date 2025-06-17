using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Data;
using JobTrackerApi.Models;

namespace JobTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ApplicationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: api/Application/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
                return NotFound();
            return application;
        }

        // POST: api/Application
        [HttpPost]
        public async Task<ActionResult<Application>> CreateApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetApplication), new { id = application.Id }, application);
        }

        // PUT: api/Application/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, Application updated)
        {
            if (id != updated.Id)
                return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Applications.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Application/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if (app == null)
                return NotFound();

            _context.Applications.Remove(app);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
