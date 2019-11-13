using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Model
{
    public class ITProviderCredentials
    {
        public string Password { get; set; }
        public ITProvider Provider { get; set; }

        public ITProviderCredentials()
        {

        }

        public ITProviderCredentials(string password, ITProvider provider)
        {
            this.Password = password;
            this.Provider = provider;
        }
    }
}
