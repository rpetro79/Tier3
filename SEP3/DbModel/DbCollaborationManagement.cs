using SEP3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbModel
{
    public class DbCollaborationManagement
    {
        [Key]
        public string ProjectId { get; set; }
        public bool Closed { get; set; }

        public DbCollaborationManagement()
        { }

        public CollaborationManagement toCollaborationManagement(Collaboration collaboration, List<ITProvider> providers, List<Application> apps)
        {
            return new CollaborationManagement(collaboration, Closed, providers,apps);
        }

        public void toDbCollaborationManagement(CollaborationManagement cm)
        {
            this.ProjectId = cm.Collaboration.ProjectId;
            this.Closed = cm.Closed;

        }
    }
}

