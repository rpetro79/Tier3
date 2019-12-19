using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbITProvidersAssigned
    {
        [Key]
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string ProviderUsername { get; set; }

        public DbITProvidersAssigned(string providerUsername, string projectId)
        {
            this.ProviderUsername = providerUsername;
            this.ProjectId = projectId;
        }

        public DbITProvidersAssigned() { }

        public bool Equals(object obj)
        {
            if (obj is ITProvider)
                return ((ITProvider)obj).Username == ProviderUsername;
            else if (obj is DbITProvidersAssigned)
            {
                DbITProvidersAssigned other = (DbITProvidersAssigned)obj;
                return this.ProjectId == other.ProjectId && this.ProviderUsername == other.ProviderUsername;
            }
            return false;
        }
    }
}
