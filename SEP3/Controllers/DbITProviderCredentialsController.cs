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
    [Route("api/ITProviderCredentials")]
    [ApiController]
    public class DbITProviderCredentialsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbITProviderCredentialsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbITProviderCredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ITProviderCredentials>>> GetDbITProviderCredentials()
        {
            List<ITProviderCredentials> users = new List<ITProviderCredentials>();
            List<DbITProviderCredentials> credentials =  await _context.ITProviderCredentials.ToListAsync();
            foreach (DbITProviderCredentials credential in credentials)
            {
                users.Add(toUser(credential));
            }
            return users;
        }

        private ITProviderCredentials toUser(DbITProviderCredentials credential)
        {
            DbITProvider dbProvider = _context.ITProviders.Single(prov => prov.Username == credential.Username);
            if (dbProvider == null)
                return null;
            DbContactInfo contactInfo = _context.contactInfo.Single(contactInfo => contactInfo.Username == credential.Username);
            ITProvider provider;
            List<DbTechnologies> technologies = new List<DbTechnologies>();
            technologies = _context.technologies.Where(technology => technology.Username == credential.Username).ToList<DbTechnologies>();
            provider = dbProvider.toITProvider(contactInfo, technologies);
            
            ITProviderCredentials pc = new ITProviderCredentials(credential.Password, provider);
            return pc;
        }

        // GET: api/DbITProviderCredentials/5
        [HttpGet("{username}")]
        public async Task<ActionResult<ITProviderCredentials>> GetDbITProviderCredentials(string username)
        {
            var dbITProviderCredentials = await _context.ITProviderCredentials.FindAsync(username);

            if (dbITProviderCredentials == null)
            {
                return NotFound();
            }
            ITProviderCredentials credentials;
            DbITProvider dbProvider = _context.ITProviders.Find(username);
            DbContactInfo dbCi = _context.contactInfo.Find(username);
            List<DbTechnologies> techs = _context.technologies.Where(tec => tec.Username == username).ToList<DbTechnologies>();
            credentials = dbITProviderCredentials.toITProviderCredentials(dbProvider.toITProvider(dbCi, techs));
            return credentials;
        }

        // PUT: api/DbITProviderCredentials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{username}")]
        public async Task<IActionResult> PutDbITProviderCredentials(string username, ITProviderCredentials credentials)
        {
            if (username != credentials.Provider.Username)
            {
                return BadRequest();
            }
            DbITProviderCredentials dbCredentials = new DbITProviderCredentials();
            dbCredentials.toDbITProviderCredentials(credentials);

            DbITProvider provider = new DbITProvider();
            List<DbTechnologies> techs = provider.toDbITProvider(credentials.Provider);

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(credentials.Provider.ContactInfo, credentials.Provider.Username);

            List<DbTechnologies> toDeleteTechs = _context.technologies.Where(tec => tec.Username == username).ToList<DbTechnologies>();
            foreach(DbTechnologies t in toDeleteTechs)
            {
                _context.technologies.Remove(t);
            }
            await _context.SaveChangesAsync();

            foreach(DbTechnologies t in techs)
            {
                _context.technologies.Add(t);
            }



            _context.Entry(dbCredentials).State = EntityState.Modified;
            _context.Entry(provider).State = EntityState.Modified;
            _context.Entry(ci).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbITProviderCredentialsExists(username))
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

        // POST: api/DbITProviderCredentials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbITProviderCredentials>> PostDbITProviderCredentials(ITProviderCredentials credentials)
        {
            DbITProviderCredentials dbCredentials = new DbITProviderCredentials();
            dbCredentials.toDbITProviderCredentials(credentials);
            _context.ITProviderCredentials.Add(dbCredentials);

            DbITProvider provider = new DbITProvider();
            List<DbTechnologies> techs = provider.toDbITProvider(credentials.Provider);
            _context.ITProviders.Add(provider);
            foreach(DbTechnologies tec in techs)
            {
                _context.technologies.Add(tec);
            }

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(credentials.Provider.ContactInfo, credentials.Provider.Username);
            _context.contactInfo.Add(ci);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DbITProviderCredentialsExists(credentials.Provider.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbITProviderCredentials", new { id = credentials.Provider.Username }, credentials);
        }

        // DELETE: api/DbITProviderCredentials/5
        [HttpDelete("{username}")]
        public async Task<ActionResult<DbITProviderCredentials>> DeleteDbITProviderCredentials(string username)
        {
            var dbITProviderCredentials = await _context.ITProviderCredentials.FindAsync(username);
            if (dbITProviderCredentials == null)
            {
                return NotFound();
            }

            DbContactInfo ci = _context.contactInfo.Find(username);
            _context.contactInfo.Remove(ci);

            List<DbTechnologies> techs = _context.technologies.Where(tec => tec.Username == username).ToList<DbTechnologies>();
            foreach(DbTechnologies tec in techs)
            {
                _context.technologies.Remove(tec);
            }

            DbITProvider prov = _context.ITProviders.Find(username);
            _context.ITProviders.Remove(prov);

            _context.ITProviderCredentials.Remove(dbITProviderCredentials);
            await _context.SaveChangesAsync();

            return dbITProviderCredentials;
        }

        private bool DbITProviderCredentialsExists(string id)
        {
            return _context.ITProviderCredentials.Any(e => e.Username == id);
        }
    }
}
