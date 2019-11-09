using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEP3.DbModel
{
    public class DbTechnologies
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string technology { get; set; }

        public void toDbTechnology(string username, string tech)
        {
            this.username = username;
            this.technology = tech;
        }
    }
}
