using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbModel;
using Newtonsoft.Json;

namespace SEP3.Model
{
    [Serializable]
    [JsonObject(MemberSerialization.OptOut)]
    public class Credentials
    {
        public string username { get; set; }
        public string password { get; set; }
        public IUser user { get; set; }

        public Credentials(string username, string password, IUser user)
        {
            this.username = username;
            this.password = password;
            this.user = user;
        }
    }
}
