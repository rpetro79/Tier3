using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbCustomer
    {
        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void toDbCustomer(Customer c)
        {
            this.Username = c.Username;
            this.Name = c.Name;
            this.Description = c.Description;
        }

        public Customer toCustomer(DbContactInfo ci)
        {
            return new Customer(Username, Name, Description, ci.toContactInfo());
        }
    }
}
