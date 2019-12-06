using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3.DbModel;

namespace SEP3.Model
{
    [Serializable]
    public class Customer
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public Customer() { }

        public Customer(string username, string name, string description, ContactInfo contactInfo)
        {
            this.Username = username;
            this.Name = name;
            this.Description = description;
            this.ContactInfo = contactInfo;
        }

    }
}
