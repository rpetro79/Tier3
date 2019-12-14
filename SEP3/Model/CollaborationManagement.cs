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
        public List<ITProvider> ProvidersOnCollaboration { get; set; }

        public CollaborationManagement() { }

        public CollaborationManagement(Collaboration C, bool closed, List<ITProvider> poc)
        {
            this.Collaboration = C;
            this.Closed = closed;
            this.ProvidersOnCollaboration = poc;
        }

        public CollaborationManagement(Collaboration C)
        {
            this.Collaboration = C;
            ProvidersOnCollaboration = new List<ITProvider>();
        }
    }
}
