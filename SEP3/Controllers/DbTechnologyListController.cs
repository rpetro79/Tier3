using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3.DbContexts;
using SEP3.DbManagement;
using SEP3.DbModel;
using SEP3.Model;

namespace SEP3.Controllers
{
    [Route("api/TechnologyList")]
    [ApiController]
    public class DbTechnologyListController : ControllerBase
    {
        private readonly UserContext _context;
        public DbTechnologyListController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnologyList>>> GetTechnologies()
        {
            return await TechnologyListDb.GetTechnologiesAsync(_context);
        }
    }
}