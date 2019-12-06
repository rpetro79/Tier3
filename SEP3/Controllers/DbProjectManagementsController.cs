using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3.DbContexts;
using SEP3.DbModel;

namespace SEP3.Controllers
{
    [Route("api/ProjectManagement")]
    [ApiController]
    public class DbProjectManagementsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbProjectManagementsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbProjectManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbProjectManagement>>> GetProjectManagement()
        {
            var projectManagementList = _context.ProjectManagement.ToListAsync();
            var projects = _context.Projects.ToListAsync();
            return null;
        }

        // GET: api/DbProjectManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbProjectManagement>> GetDbProjectManagement(string id)
        {
            var dbProjectManagement = await _context.ProjectManagement.FindAsync(id);

            if (dbProjectManagement == null)
            {
                return NotFound();
            }

            return dbProjectManagement;
        }

        // PUT: api/DbProjectManagements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbProjectManagement(string id, DbProjectManagement dbProjectManagement)
        {
            if (id != dbProjectManagement.ProjectId)
            {
                return BadRequest();

            }

            _context.Entry(dbProjectManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbProjectManagementExists(id))
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

        // POST: api/DbProjectManagements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbProjectManagement>> PostDbProjectManagement(DbProjectManagement dbProjectManagement)
        {
            _context.ProjectManagement.Add(dbProjectManagement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DbProjectManagementExists(dbProjectManagement.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbProjectManagement", new { id = dbProjectManagement.ProjectId }, dbProjectManagement);
        }

        // DELETE: api/DbProjectManagements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbProjectManagement>> DeleteDbProjectManagement(string id)
        {
            var dbProjectManagement = await _context.ProjectManagement.FindAsync(id);
            if (dbProjectManagement == null)
            {
                return NotFound();
            }

            _context.ProjectManagement.Remove(dbProjectManagement);
            await _context.SaveChangesAsync();

            return dbProjectManagement;
        }

        private bool DbProjectManagementExists(string id)
        {
            return _context.ProjectManagement.Any(e => e.ProjectId == id);
        }
    }
}
