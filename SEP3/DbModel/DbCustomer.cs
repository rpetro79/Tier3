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
        public string username { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public void toDbCustomer(Customer c, string username)
        {
            this.username = username;
            this.name = c.name;
            this.description = c.description;
        }

        public IUser toUser(DbContactInfo ci)
        {
            return new Customer(name, description, ci.toContactInfo());
        }
    }
}
