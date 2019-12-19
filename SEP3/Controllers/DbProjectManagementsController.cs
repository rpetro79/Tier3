using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3.DbContexts;
using SEP3.DbModel;
using SEP3.Model;
using SEP3.DbManagement;

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
        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectManagement>> GetProjectManagement(string projectId)
        {
            var projectManagement = await ProjectManagementDb.getProjectManagementAsync(projectId, _context);
            if (projectManagement == null)
                return NotFound();
            return projectManagement;
        }

        // GET: api/DbProjectManagements/5
        [HttpGet("user/{username}")]
        public async Task<ActionResult<List<ProjectManagement>>> GetProjectManagementOfUser(string username)
        {
            var projectsManagement = await ProjectManagementDb.getProjectsManagementOfUserAsync(username, _context);

            if (projectsManagement == null)
            {
                return NotFound();
            }

            return projectsManagement;
        }
       
        // PUT: api/DbProjectManagements/5
        [HttpPut]
        public async Task<IActionResult> PutDbProjectManagement(ProjectManagement projectManagement)
        {
            bool x = await ProjectManagementDb.putProjectManagementAsync(projectManagement, _context);

            if (x == false)
                return NotFound();
            return Accepted();
        }

        // POST: api/DbProjectManagements
        [HttpPost]
        public async Task<ActionResult<DbProjectManagement>> PostDbProjectManagement(ProjectManagement projectManagement)
        {
            bool x = await ProjectManagementDb.postProjectManagementAsync(projectManagement, _context);

            if (x)
                return Accepted();
            return Conflict();
        }

        // DELETE: api/DbProjectManagements/5
        [HttpDelete("{projectId}")]
        public async Task<ActionResult<DbProjectManagement>> DeleteDbProjectManagement(string projectId)
        {
            await ProjectManagementDb.deleteProjectManagement(projectId, _context);

            return Ok();
        }
    }
}
