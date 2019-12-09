using SEP3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbModel
{
    public class DbTechnologyList
    {
        [Key]
        public string Technology { get; set; }

        public DbTechnologyList() { }

        public TechnologyList ToTechnologyList(DbTechnologyList db)
        {
            return new TechnologyList() { Technology = db.Technology };
        }

        public void ToDbTechnology(TechnologyList technology)
        {
            Technology = technology.Technology;
        }
    }
}
