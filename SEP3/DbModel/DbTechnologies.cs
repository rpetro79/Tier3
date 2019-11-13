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
        public int Id { get; set; }
        public string Username { get; set; }
        public string Technology { get; set; }

        public void toDbTechnology(string username, string tech)
        {
            this.Username = username;
            this.Technology = tech;
        }
    }
}
