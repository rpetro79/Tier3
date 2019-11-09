using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbModel;

namespace SEP3.Model
{
    [Serializable]
    public class Customer : IUser
    {
        public string name { get; set; }
        public string description { get; set; }
        public ContactInfo contactInfo { get; set; }

        public Customer(string name, string description, ContactInfo contactInfo)
        {
            this.name = name;
            this.description = description;
            this.contactInfo = contactInfo;
        }

        public ContactInfo getContactInfo()
        {
            return contactInfo;
        }
    }
}
