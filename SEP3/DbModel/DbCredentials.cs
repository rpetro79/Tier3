using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.Model;
using System.ComponentModel.DataAnnotations;

namespace SEP3.DbModel
{
    public class DbCredentials
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }

        public void ToDbCustomerCredentials(CustomerCredentials cr)
        {
            this.Username = cr.Customer.Username;
            this.Password = cr.Password;
        }

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
