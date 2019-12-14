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

        [Route("api/CollaborationManagement")]
        [ApiController]
        public class DbCollaborationManagementController : ControllerBase
        {
            private readonly UserContext _context;

            public DbCollaborationManagementController(UserContext context)
            {
                _context = context;
            }

            // GET: api/DbCollaborationManagement
            [HttpGet("{username}/{projectId}")]
            public async Task<ActionResult<CollaborationManagement>> GetCollaborationManagement(string projectId, string username)
            {
                var collaborationManagement = await CollaborationManagementDb.getCollaborationManagementAsync(projectId, _context);
                if (collaborationManagement == null)
                    return NotFound();
                return collaborationManagement;
            }

            // GET: api/DbCollaborationManagement/5
            [HttpGet("{username}")]
            public async Task<ActionResult<List<CollaborationManagement>>> GetCollaborationManagementOfUser(string username)
            {
                var collaborationsManagement = await CollaborationManagementDb.getCollaborationManagementOfUserAsync(username, _context);

                if (collaborationsManagement == null)
                {
                    return NotFound();
                }

                return collaborationsManagement;
            }

            [HttpGet("id/{projectId}")]
            public async Task<ActionResult<CollaborationManagement>> GetCollaborationManagementById(string projectId)
            {
                
                var projectCollaboration = await CollaborationManagementDb.getCollaborationManagementAsync(projectId, _context);
                if (projectCollaboration == null)
                    return NotFound();
                return projectCollaboration;
            }

            // PUT: api/DbCollaborationManagement/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPut]
            public async Task<IActionResult> PutDbCollaborationManagement(CollaborationManagement collaborationManagement)
            {
                bool x = await CollaborationManagementDb.putCollaborationManagementAsync(collaborationManagement, _context);

                if (x == false)
                    return NotFound();
                return Accepted();
            }

            // POST: api/DbCollaborationManagement
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPost]
            public async Task<ActionResult<DbCollaborationManagement>> PostDbCollaborationManagement(CollaborationManagement collaborationManagement)
            {
                bool x = await CollaborationManagementDb.postCollaborationManagementAsync(collaborationManagement, _context);

                if (x)
                    return Accepted();
                return Conflict();
            }

            // DELETE: api/DbCollaborationManagement/5
            [HttpDelete("{projectId}")]
            public async Task<ActionResult<DbProjectManagement>> DeleteDbCollaborationtManagement(string projectId)
            {
                await CollaborationManagementDb.deleteCollaborationManagement(projectId, _context);

                return Ok();
            }
        }
    
}
