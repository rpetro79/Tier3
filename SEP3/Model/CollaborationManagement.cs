using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Model
{
    public class CollaborationManagement
    {
        public Collaboration Collaboration { get; set; }
        public bool Closed { get; set; }
        public List<ITProvider> AssignedProviders { get; set; }
        public List<Application> Applications { get; set; }
        

        public CollaborationManagement() { }

        public CollaborationManagement(Collaboration collaboration, bool closed, List<ITProvider> itpoc, List<Application> apps)
        {
            this.Collaboration = collaboration;
            this.Closed = closed;
            this.AssignedProviders = itpoc;
            this.Applications= apps;
        }

        public CollaborationManagement(Collaboration collaboration)
        {
            this.Collaboration = collaboration;
            AssignedProviders= new List<ITProvider>();
            Applications = new List<Application>();
        }
    }
}
