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
    [Route("api/Customers")]
    [ApiController]
    public class DbCustomersController : ControllerBase
    {
        private readonly UserContext _context;

        public DbCustomersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbCustomers
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await CustomerDb.getCustomersAsync(_context);
        }

        // GET: api/DbCustomers/5
        [HttpGet("{username}")]
        public async Task<ActionResult<Customer>> GetDbCustomer(string username)
        {
            var customer = await CustomerDb.getCustomerAsync(username, _context);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        // GET: api/DbCustomers/5
        [HttpGet("projectId/{projectId}")]
        public async Task<ActionResult<Customer>> GetDbCustomerByProjectId(string projectId)
        {
            var customer = await CustomerDb.getCustomerByIdAsync(projectId, _context);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        // PUT: api/DbCustomers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            bool x = await CustomerDb.putCustomerAsync(customer, _context);

            if (x)
                return Accepted();
            return NotFound();
        }

/*        you should only be able to post credentials
 *        
 *        // POST: api/DbCustomers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DbCustomer>> PostDbCustomer(Customer customer)
        {
            bool x = await CustomerDb.postCustomerAsync(customer, _context);

            if (x)
                return Accepted();
            return Conflict();
            
        }*/

        /*// DELETE: api/DbCustomers/5
        [HttpDelete("{username}")]
        public async Task<ActionResult<DbCustomer>> DeleteCustomer(string username)
        {
            await CustomerDb.deleteCustomerAsync(username, _context);
            return Ok();
        }*/
    }
}
