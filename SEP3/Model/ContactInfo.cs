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
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }

        public ContactInfo(string address, string phoneNo, string email)
        {
            this.address = address;
            this.phoneNo = phoneNo;
            this.email = email;
        }

    }
}
