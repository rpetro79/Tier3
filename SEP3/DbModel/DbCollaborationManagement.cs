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
        public string CollaborationId { get; set; }
        public bool Closed { get; set; }

        public CollaborationManagement toCollaborationManagement(Collaboration collaboration, List<ITProvider> providers)
        {
            return new CollaborationManagement(collaboration, Closed, providers);
        }

        public void toDbCollaborationManagement(CollaborationManagement cm)
        {
            this.CollaborationId = cm.Collaboration.CollaborationId;
            this.Closed = cm.Closed;

        }
    }
}

