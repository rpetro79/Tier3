using Microsoft.AspNetCore.Mvc;
using SEP3.DbContexts;
using SEP3.DbManagement;
using SEP3.DbModel;
using SEP3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Controllers
{
    [Route("api/Collaborations")]
    [ApiController]
    public class DbCollaborationController:ControllerBase
    {
        private readonly UserContext _context;

        public DbCollaborationController(UserContext context)
        {
            _context = context;
        }

        //GET: api/Collaborations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collaboration>>> GetCollaborations()
        {
            return await CollaborationDb.GetCollaborationsAsync(_context);
        }


        [HttpGet("user/{username}")]
        public async Task<ActionResult<List<Collaboration>>> GetCollaborationManagementOfUser(string username)
        {
            var collaborations = await CollaborationDb.getCollaborationsOfUserAsync(username, _context);

            if (collaborations == null)
            {
                return NotFound();
            }

            return collaborations;
        }

        //Get: api/Collaborations/3
        [HttpGet("{CollaborationId}")]
        public async Task<ActionResult<Collaboration>> GetCollaboration(string CollaborationId)
        {
            Collaboration Collaboration = await CollaborationDb.GetCollaborationAsync(CollaborationId, _context);
            if(Collaboration == null)
                return NotFound();
            return Collaboration;
        }
    }
}
