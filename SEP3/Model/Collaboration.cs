using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Model
{
    public class Collaboration
    {
        [Key]
        public string ProjectId { get; set; }
        public ITProvider ITProvider { get; set; }
        public string CollaborationName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Collaboration() { }

        public Collaboration(string projectId, ITProvider ITProvider, string collaborationName, string description, string category)
        {
            ProjectId = projectId;
            this.ITProvider = ITProvider;
            CollaborationName = collaborationName;
            Description = description;
            Category = category;
        }
    }
}
