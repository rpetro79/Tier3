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

        public CollaborationManagement(Collaboration C, bool closed, List<ITProvider> itpoc, List<Application> apps)
        {
            this.Collaboration = C;
            this.Closed = closed;
            this.AssignedProviders = itpoc;
            this.Applications= apps;
        }

        public CollaborationManagement(Collaboration C)
        {
            this.Collaboration = C;
            AssignedProviders= new List<ITProvider>();
            Applications = new List<Application>();
        }
    }
}
