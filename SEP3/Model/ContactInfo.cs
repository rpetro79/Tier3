using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.DbModel;

namespace SEP3.Model
{
    [Serializable]
    public class ContactInfo
    {
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public ContactInfo()
        {

        }

        public ContactInfo(string address, string phoneNo, string email)
        {
            this.Address = address;
            this.PhoneNo = phoneNo;
            this.Email = email;
        }

    }
}
