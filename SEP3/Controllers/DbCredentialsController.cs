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

namespace SEP3.Controllers
{
    [Route("api/UserCredentials")]
    [ApiController]
    public class DbCredentialsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbCredentialsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserCredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credentials>>> Getcredentials()
        {
            List<Credentials> users = new List<Credentials>();
            List<DbCredentials> credentials = await _context.credentials.ToListAsync();
            foreach (DbCredentials credential in credentials)
            {
                users.Add(toUser(credential));
            }
            return users;
        }

        private Credentials toUser(DbCredentials credential)
        {
            DbITProvider provider = (_context.ITProviders.Single(provider => provider.username == credential.username));
            DbCustomer customer;
            List<DbTechnologies> technologies;
            DbContactInfo contactInfo = _context.contactInfo.Single(contactInfo => contactInfo.username == credential.username);
            IUser user;
            if (provider != null)
            {
                technologies = _context.technologies.Where(technology => technology.username == credential.username).ToList<DbTechnologies>();
                user = provider.toUser(contactInfo, technologies);
            }
            else
            {
                customer = (_context.customers.Single(customer => customer.username == credential.username));
                user = customer.toUser(contactInfo);
            }
            return credential.toCredentials(user);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<Credentials>> GetDbCredentials(string username)
        {
            DbCredentials dbCredentials = await _context.credentials.FindAsync(username);
            Credentials user = toUser(dbCredentials);

            if (dbCredentials == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/DbCredentials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbCredentials(string id, DbCredentials dbCredentials)
        {
            if (id != dbCredentials.username)
            {
                return BadRequest();
            }

            _context.Entry(dbCredentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbCredentialsExists(id))
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

        // POST: api/DbCredentials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbCredentials>> PostDbCredentials(DbCredentials dbCredentials)
        {
            _context.credentials.Add(dbCredentials);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DbCredentialsExists(dbCredentials.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbCredentials", new { id = dbCredentials.username }, dbCredentials);
        }

        // DELETE: api/DbCredentials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbCredentials>> DeleteDbCredentials(string id)
        {
            var dbCredentials = await _context.credentials.FindAsync(id);
            if (dbCredentials == null)
            {
                return NotFound();
            }

            _context.credentials.Remove(dbCredentials);
            await _context.SaveChangesAsync();

            return dbCredentials;
        }

        private bool DbCredentialsExists(string id)
        {
            return _context.credentials.Any(e => e.username == id);
        }
    }
}
