using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbITProviderCredentials
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public void ToDbITProviderCredentials(ITProviderCredentials cr)
        {
            this.Username = cr.Provider.Username;
            this.Password = cr.Password;
        }

        public ITProviderCredentials ToITProviderCredentials(ITProvider provider)
        {
            return new ITProviderCredentials(Password, provider);
        }
    }
}
