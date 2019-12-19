using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbContactInfo
    {
        [Key]
        public string Username { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public void ToDbContactInfo(ContactInfo ci, string username)
        {
            this.Username = username;
            this.Address = ci.Address;
            this.PhoneNo = ci.PhoneNo;
            this.Email = ci.Email;
        }

        public ContactInfo ToContactInfo()
        {
            return new ContactInfo(Address, PhoneNo, Email);
        }
    }
}
