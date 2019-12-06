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
    [Route("api/Applications")]
    [ApiController]
    public class DbApplicationsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbApplicationsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbApplications/5
        [HttpGet("{projectId}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationsForProject(string projectId)
        {
            var applications = await ApplicationsDb.getApplicationsForProjectAsync(projectId, _context);

            if (applications == null)
            {
                return NotFound();
            }

            return applications;
        }

        // PUT: api/DbApplications/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbApplication(Application application)
        {
            bool x = ApplicationsDb.putApplication(application, _context);

            if (x)
                return Accepted();
            return NotFound();
        }

        // POST: api/DbApplications
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbApplication>> PostDbApplication(Application application)
        {
            bool x = ApplicationsDb.postApplication(application, _context);

            if (x)
                return Accepted();
            return Conflict();
        }

        // DELETE: api/DbApplications/5
        [HttpDelete("{projectId}/{username}")]
        public async Task<ActionResult<DbApplication>> DeleteDbApplication(string projectId, string providerUsername)
        {
            ApplicationsDb.deleteApplication(projectId, providerUsername, _context);
            return Ok();
        }

        private bool DbApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
