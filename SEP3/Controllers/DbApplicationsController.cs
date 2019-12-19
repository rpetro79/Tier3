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
    [Route("api/Applications")]
    [ApiController]
    public class DbApplicationsController : ControllerBase
    {
        private readonly UserContext _context;

        public DbApplicationsController(UserContext context)
        {
            _context = context;
        }

        // PUT: api/DbApplications/5
        [HttpPut]
        public async Task<IActionResult> PutDbApplication(Application application)
        {
            bool x = ApplicationsDb.putApplication(application, _context);

            if (x)
                return Accepted();
            return NotFound();
        }

        // POST: api/DbApplications
        [HttpPost]
        public async Task<ActionResult<DbApplication>> PostDbApplication(Application application)
        {
            bool x = ApplicationsDb.postApplication(application, _context);

            if (x)
                return Accepted();
            return Conflict();
        }
    }
}
