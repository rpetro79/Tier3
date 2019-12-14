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
        public List<ITProvider> ITProvidersOnCollaboration { get; set; }
        public List<Application> ITProvidersApplications { get; set; }
        

        public CollaborationManagement() { }

        public CollaborationManagement(Collaboration C, bool closed, List<ITProvider> itpoc, List<Application> apps)
        {
            this.Collaboration = C;
            this.Closed = closed;
            this.ITProvidersOnCollaboration = itpoc;
            this.ITProvidersApplications = apps;
        }

        public CollaborationManagement(Collaboration C)
        {
            this.Collaboration = C;
            ITProvidersOnCollaboration = new List<ITProvider>();
            ITProvidersApplications = new List<Application>();
        }
    }
}
