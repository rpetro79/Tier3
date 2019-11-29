using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbModel;

namespace SEP3.Model
{
    public class ProjectManagement
    { 

        public Project project { get; set; }
        public bool Closed { get; set; }
        public List<Application> Applications { get; set; }
        public List<ITProvider> AssignedProviders { get; set; }

        public ProjectManagement() { }

        public ProjectManagement(Project p, bool closed, List<Application> aps, List<ITProvider> providers)
        {
            this.project = p;
            this.Closed = closed;
            this.Applications = aps;
            this.AssignedProviders = providers;
        }
    }
}
