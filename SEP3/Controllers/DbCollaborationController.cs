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

        [HttpGet("all")]
        public async Task<ActionResult<CollaborationList>> GetAllCollaborations()
        {
            CollaborationList list = new CollaborationList();
            list.list = await CollaborationDb.getAllCollaborationsAsync(_context);
            return list;

        }

        //GET: api/Collaborations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collaboration>>> GetCollaborations()
        {
            return await CollaborationDb.GetCollaborationsAsync(_context);
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

        //Post: api/Collaborations
        [HttpPost]
        public async Task<ActionResult> PostCollaboration(Collaboration collaboration)
        {
            bool isApproved = await CollaborationDb.PostCollaborationAsync(collaboration, _context);
            if (isApproved)
                return Accepted();
            else
                return Conflict();
        }

        //PUT: api/Collaborations/3
        [HttpPut]
        public async Task<IActionResult> PutCollaboration(Collaboration collaboration)
        {
            bool isApproved = await CollaborationDb.PutCollaborationAsync(collaboration, _context);

            if (isApproved)
                return Accepted();
            else return NotFound();
        }

        //Delete: api/Projects/3
        [HttpDelete("{CollaborationId}")]
        public async Task<ActionResult> DeleteCollaboration(string collaborationId)
        {
            bool isApproved = await CollaborationDb.DeleteCollaborationFromITProvider(collaborationId, _context);
            if (isApproved)
                return Accepted();
            else
                return Conflict();
        }

        //Delete api/Projects/leksi12
        [HttpDelete("{ITProviderName}")]
        public async Task<ActionResult> DeleteCollaborationsFrom(string username)
        {
            await CollaborationDb.DeleteAllCollaborationsFromITProvider(username, _context);
            return Accepted();
        }
    }
}
