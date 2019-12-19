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
    [Route("api/ITProviderCredentials")]
    [ApiController]
    public class DbITProviderCredentialsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbITProviderCredentialsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbITProviderCredentials/5
        [HttpGet("{username}")]
        public async Task<ActionResult<ITProviderCredentials>> GetDbITProviderCredentials(string username)
        {
            var prov = await ITProviderDb.GetITProviderCredentialsAsync(username, _context);
            if (prov == null)
                return NotFound();
            return prov;
        }

        // PUT: api/DbITProviderCredentials/5
        [HttpPut]
        public async Task<IActionResult> PutDbITProviderCredentials(ITProviderCredentials credentials)
        {
            bool x = await ITProviderDb.putITProviderCredentialsAsync(credentials, _context);

            if(x)
            {
                return Accepted();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/DbITProviderCredentials
        [HttpPost]
        public async Task<ActionResult<DbITProviderCredentials>> PostDbITProviderCredentials(ITProviderCredentials credentials)
        {
            bool x = await ITProviderDb.postITProviderCredentialsAsync(credentials, _context);
            if (x)
            {
                return Accepted();
            }
            else
            {
                return Conflict();
            }
        }

        // DELETE: api/DbITProviderCredentials/5
        [HttpDelete("{username}")]
        public async Task<ActionResult<DbITProviderCredentials>> DeleteDbITProviderCredentials(string username)
        {
            await ITProviderDb.deleteCredentialsAsync(username, _context);
            return Ok();
        }
    }
}
