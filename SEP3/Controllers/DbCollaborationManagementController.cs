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
            [HttpGet("{projectId}")]
            public async Task<ActionResult<CollaborationManagement>> GetCollaborationManagement(string projectId)
            {
                var collaborationManagement = await CollaborationManagementDb.getCollaborationManagementAsync(projectId, _context);
                if (collaborationManagement == null)
                    return NotFound();
                return collaborationManagement;
            }

            // GET: api/DbCollaborationManagement/5
            [HttpGet("user/{username}")]
            public async Task<ActionResult<List<CollaborationManagement>>> GetCollaborationManagementOfUser(string username)
            {
                var collaborationsManagement = await CollaborationManagementDb.getCollaborationManagementOfUserAsync(username, _context);

                if (collaborationsManagement == null)
                {
                    return NotFound();
                }

                return collaborationsManagement;
            }

        
            // PUT: api/DbCollaborationManagement/5
            [HttpPut]
            public async Task<IActionResult> PutDbCollaborationManagement(CollaborationManagement collaborationManagement)
            {
                bool x = await CollaborationManagementDb.putCollaborationManagementAsync(collaborationManagement, _context);

                if (x == false)
                    return NotFound();
                return Accepted();
            }

            // POST: api/DbCollaborationManagement
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
            public async Task<ActionResult<DbCollaborationManagement>> DeleteDbCollaborationtManagement(string projectId)
            {
                await CollaborationManagementDb.deleteCollaborationManagement(projectId, _context);

                return Ok();
            }
        }
    
}
