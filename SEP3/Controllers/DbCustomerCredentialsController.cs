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
    [Route("api/customerCredentials")]
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
        public async Task<ActionResult<IEnumerable<CustomerCredentials>>> GetDbCustomerCredentials()
        {
            List<CustomerCredentials> users = new List<CustomerCredentials>();
            List<DbCustomerCredentials> credentials = await _context.customerCredentials.ToListAsync();
            foreach (DbCustomerCredentials credential in credentials)
            {
                users.Add(toUser(credential));
            }
            return users;
        }

        private CustomerCredentials toUser(DbCustomerCredentials credential)
        {
            DbCustomer customer = _context.customers.Single(customer => customer.Username == credential.Username);
            if (customer == null)
                return null;
            DbContactInfo contactInfo = _context.contactInfo.Single(contactInfo => contactInfo.Username == credential.Username);
            Customer cust;
            cust = customer.toCustomer(contactInfo);
            CustomerCredentials cc = new CustomerCredentials(credential.Password, cust);
            return cc;
        }

        // GET: api/DbCustomerCredentials/5
        [HttpGet("{username}")]
        public async Task<ActionResult<CustomerCredentials>> GetDbCustomerCredentials(string username)
        {
            DbCustomerCredentials dbCustomerCredentials = await _context.customerCredentials.FindAsync(username);
            CustomerCredentials user = toUser(dbCustomerCredentials);

            if (dbCustomerCredentials == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/DbCustomerCredentials/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{username}")]
        public async Task<IActionResult> PutDbCustomerCredentials(string username, CustomerCredentials credentials)
        {
            if (username != credentials.Customer.Username)
            {
                return BadRequest();
            }

            DbCustomer customer = new DbCustomer();
            customer.toDbCustomer((Customer)credentials.Customer);
            _context.Entry(customer).State = EntityState.Modified;
            
             DbContactInfo ci = new DbContactInfo();
             ci.toDbContactInfo(credentials.Customer.ContactInfo, username);
            _context.Entry(ci).State = EntityState.Modified;

            DbCustomerCredentials dbCustomerCredentials = new DbCustomerCredentials();
            dbCustomerCredentials.toDbCustomerCredentials(credentials);
            _context.Entry(dbCustomerCredentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return NoContent();
        }

        // POST: api/DbCustomerCredentials
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbCustomerCredentials>> PostDbCustomerCredentials(CustomerCredentials credentials)
        {
            DbCustomerCredentials dbCustomerCredentials = new DbCustomerCredentials();
            dbCustomerCredentials.toDbCustomerCredentials(credentials);
            _context.customerCredentials.Add(dbCustomerCredentials);
            
            DbCustomer cust = new DbCustomer();
            cust.toDbCustomer((Customer)credentials.Customer);
            _context.customers.Add(cust);
            
            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(credentials.Customer.ContactInfo, credentials.Customer.Username);
            _context.contactInfo.Add(ci);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DbCustomerCredentialsExists(dbCustomerCredentials.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDbCustomerCredentials", new { id = credentials.Customer.Username }, credentials);
            //hi
        }

        // DELETE: api/DbCustomerCredentials/5
        [HttpDelete("{username}")]
        public async Task<ActionResult<DbCustomerCredentials>> DeleteDbCustomerCredentials(string username)
        {
            var dbCustomerCredentials = await _context.customerCredentials.FindAsync(username);
            if (dbCustomerCredentials == null)
            {
                return NotFound();
            }

            DbCustomer cust = await _context.customers.FindAsync(username);
            _context.customers.Remove(cust);

            DbContactInfo ci = await _context.contactInfo.FindAsync(username);
            _context.contactInfo.Remove(ci);

            _context.customerCredentials.Remove(dbCustomerCredentials);
            await _context.SaveChangesAsync();

            return dbCustomerCredentials;
        }

        private bool DbCustomerCredentialsExists(string id)
        {
            return _context.customerCredentials.Any(e => e.Username == id);
        }
    }
}
