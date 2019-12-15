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
    [Route("api/CustomerCredentials")]
    [ApiController]
    public class DbCustomerCredentialsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbCustomerCredentialsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbCustomerCredentials
        [HttpGet]
        public async Task<IEnumerable<CustomerCredentials>> GetDbCustomerCredentials()
        {
            return await CustomerDb.getCustomerCredentialsAsync(_context);
        }

        // GET: api/DbCustomerCredentials/5
        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerCredentials>> GetDbCustomerCredentials(string username)
        {
            var cust = await CustomerDb.getCustomerCredentialsAsync(username, _context);
            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }

        // PUT: api/DbCustomerCredentials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutDbCustomerCredentials(CustomerCredentials credentials)
        {

            bool x = await CustomerDb.putCustomerCredentialsAsync(credentials, _context);
            if (x)
                return Accepted();
            else return NotFound();
        }

        // POST: api/DbCustomerCredentials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbCustomerCredentials>> PostDbCustomerCredentials(CustomerCredentials credentials)
        {
            var i = await CustomerDb.postCustomerCredentialsAsync(credentials, _context);

            if (!i)
                return Conflict();
            else 
                return Accepted();
        }

        // DELETE: api/DbCustomerCredentials/5
        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteDbCustomerCredentials(string username)
        {
            await CustomerDb.deleteCredentialsAsync(username, _context);
            return Ok();
        }

        
    }
}
