using SEP3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbModel
{
    public class DbCategoryList
    {
        [Key]
        public string Category { get; set; }

        public DbCategoryList() { }

        public CategoryList ToCategoryList(DbCategoryList db)
        {
            return new CategoryList() { Category = db.Category };
        }
        public void ToDbCategoryList(CategoryList category)
        {
            Category = category.Category;
        }
    }
}
