using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbProject
    {
        [Key]
        public string ProjectId { get; set; }
        public string customerUsername { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public void ToDbProject(Project project)
        {
            ProjectId = project.ProjectId;
            customerUsername = project.customer.Username;
            ProjectName = project.ProjectName;
            Description = project.Description;
            Category = project.Category;
        }

        public Project ToProject(Customer cust)
        {
            return new Project(ProjectId, cust, ProjectName, Description, Category);
        }
    }
}
