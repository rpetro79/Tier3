using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbCredentials
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }

        public void toDbCredentials(Credentials cr)
        {
            this.username = cr.username;
            this.password = cr.password;
        }

        public Credentials toCredentials(IUser user)
        {
            return new Credentials(username, password, user);
        }
    }
}
