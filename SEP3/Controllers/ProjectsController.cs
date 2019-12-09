using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEP3.DbContexts;
using SEP3.Model;
using SEP3.DbModel;
using SEP3.DbManagement;

namespace SEP3.Controllers
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly UserContext _context;

        public ProjectsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {            
            return await ProjectDb.getProjectsAsync(_context);
        }

        // GET: api/Projects/5
        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetProject(string projectId)
        {
            Project project = await ProjectDb.getProjectAsync(projectId, _context);
            if (project == null)
                return NotFound();
            return project;

        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutProject(Project project)
        {
            bool x = await ProjectDb.putProjectAsync(project, _context);

            if (x)
            {
                return Accepted();
            }
            else return NotFound();
        }

        // POST: api/Projects
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            bool n = await ProjectDb.postProjectAsync(project, _context);

            if(n)
            {
                return Accepted();
            }
            else return Conflict();
        }

        // DELETE: api/Projects/5
        [HttpDelete("{projectId}")]
        public async Task<ActionResult<DbProject>> DeleteProject(string projectId)
        {
            await ProjectDb.deleteProject(projectId, _context);

            return Ok();
        }
    }
}
