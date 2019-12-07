using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.Model
{
    [Serializable]
    public class Collaboration
    {
        [Key]
        public string CollaborationId { get; set; }
        public ITProvider ITProvider { get; set; }
        public string CollaborationName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Collaboration() { }

        public Collaboration(string collaborationId, ITProvider iTProvider, string collaborationName, string description, string category)
        {
            CollaborationId = collaborationId;
            ITProvider = iTProvider;
            CollaborationName = collaborationName;
            Description = description;
            Category = category;
        }
    }
}
