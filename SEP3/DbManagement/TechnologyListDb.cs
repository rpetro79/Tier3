using Microsoft.EntityFrameworkCore;
using SEP3.DbContexts;
using SEP3.DbModel;
using SEP3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbManagement
{
    public class TechnologyListDb
    {
        public async static Task<List<TechnologyList>> GetTechnologiesAsync(UserContext _context)
        {
            List<TechnologyList> technologies = new List<TechnologyList>();
            List<DbTechnologyList> list = await _context.TechnologyList.ToListAsync();
            foreach (DbTechnologyList t in list)
            {
                technologies.Add(new TechnologyList() { Technology = t.Technology });
            }
            return technologies;
        }
    }
}
