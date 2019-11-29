using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEP3.DbModel
{
    public class DbITProvidersAssigned
    {
        [Key]
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string ProviderUsername { get; set; }
    }
}
