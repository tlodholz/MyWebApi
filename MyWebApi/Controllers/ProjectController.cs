using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult<Project>> CreateProject(int customerId, [FromBody] Project project)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Assign the CustomerId from the input parameter to the Project object
            project.CustomerId = customerId;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            // Return the created Project object
            return Ok(project);
        }

        // Read: Get all Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // Read: Get a single Project by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();

            return project;
        }

        // Update a Project
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // Delete a Project
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Get Projects by CustomerId
        [HttpGet("by-customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByCustomerId(int customerId)
        {
            var projects = await _context.Projects.Where(p => p.CustomerId == customerId).ToListAsync();
            return projects;
        }
    }
}
