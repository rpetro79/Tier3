using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3.DbContexts;
using SEP3.DbManagement;
using SEP3.Model;

namespace SEP3.Controllers
{
    [Route("api/CategoryList")]
    [ApiController]
    public class DbCategoryListController : ControllerBase
    {
        private readonly UserContext _context;
        public DbCategoryListController(UserContext context)
        {
            _context = context;
        }

        //Get: api/CategorList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryList>>> GetCategoryList()
        {
            return await CategoryListDb.GetCategoryListAsync(_context);
        }
    }
}