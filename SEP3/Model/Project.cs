using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEP3.Model
{
    public class Project
    {
        [Key]
        public string ProjectId { get; set; }
        public Customer customer { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Project() { }

        public Project(string projectId, Customer customer, string projectName, string description, string category)
        {
            ProjectId = projectId;
            this.customer = customer;
            ProjectName = projectName;
            Description = description;
            Category = category;
        }
    }
}
