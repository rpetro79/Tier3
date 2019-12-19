using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbProjectManagement
    {
        [Key]
        public string ProjectId { get; set; }
        public bool Closed { get; set; }
        
        public ProjectManagement ToProjectManagement(Project p, List<Application> aps, List<ITProvider> providers)
        {
            return new ProjectManagement(p, Closed, aps, providers);
        }

        public void ToDbProjectManagement(ProjectManagement pm)
        {
            this.ProjectId = pm.project.ProjectId;
            this.Closed = pm.Closed;
        }
    }
}
