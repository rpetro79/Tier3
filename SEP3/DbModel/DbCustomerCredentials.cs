using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.Model;
using System.ComponentModel.DataAnnotations;

namespace SEP3.DbModel
{
    public class DbCustomerCredentials
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public void toDbCustomerCredentials(CustomerCredentials cr)
        {
            this.Username = cr.Customer.Username;
            this.Password = cr.Password;
        }

        public CustomerCredentials toCredentials(Customer customer)
        {
            return new CustomerCredentials(Password, customer);
        }
    }
}
