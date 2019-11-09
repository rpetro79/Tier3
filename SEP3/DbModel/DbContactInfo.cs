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
        public string username { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }

        public void toDbContactInfo(ContactInfo ci, string username)
        {
            this.username = username;
            this.address = ci.address;
            this.phoneNo = ci.phoneNo;
            this.email = ci.email;
        }

        public ContactInfo toContactInfo()
        {
            return new ContactInfo(address, phoneNo, email);
        }
    }
}
