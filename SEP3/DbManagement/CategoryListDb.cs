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
    public class CategoryListDb
    {
        public async static Task<List<CategoryList>> GetCategoryListAsync(UserContext _context)
        {
            List<CategoryList> categories= new List<CategoryList>();
            List<DbCategoryList> list = await _context.CategoryList.ToListAsync();
            foreach (DbCategoryList c in list)
            {
                categories.Add(new CategoryList() { Category= c.Category});
            }
            return categories;
        }
    }
}
