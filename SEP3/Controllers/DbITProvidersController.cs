﻿using System;
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
    [Route("api/ITProviders")]
    [ApiController]
    public class DbITProvidersController : ControllerBase
    {
        private readonly UserContext _context;

        public DbITProvidersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/DbITProviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ITProvider>>> GetITProviders()
        {
            return await ITProviderDb.getITProvidersAsync(_context);
        }

        // GET: api/DbITProviders/5
        [HttpGet("{username}")]
        public async Task<ActionResult<ITProvider>> GetITProvider(string username)
        {
            var provider = await ITProviderDb.getITProviderAsync(username, _context);

            if (provider == null)
            {
                return NotFound();
            }

            return provider;
        }

        // PUT: api/DbITProviders/5
        [HttpPut]
        public async Task<IActionResult> PutITProvider(ITProvider provider)
        {
            bool x = await ITProviderDb.putITProviderAsync(provider, _context);
            if (x)
                return Accepted();
            return NotFound();
        }
    }
}
