using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SEP3.Model
{

    public class CustomerCredentials
    {
        public string Password { get; set; }
        public Customer Customer { get; set; }

        public CustomerCredentials() { }

        public CustomerCredentials(string password, Customer customer)
        {
            this.Password = password;
            this.Customer = customer;
        }
    }
}
