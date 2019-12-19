using SEP3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbModel
{
    public class DbCollaboration
    {
        [Key]
        public string CollaborationId { get; set; }
        public string CollaborationName { get; set; }
        public string ITProviderName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        
        
        public void ToDbCollaboration(Collaboration collaboration)
        {
            CollaborationName = collaboration.CollaborationName;
            CollaborationId = collaboration.ProjectId;
            Description = collaboration.Description;
            Category = collaboration.Category;
            ITProviderName = collaboration.ITProvider.Username;
        }

        public Collaboration ToCollaboration(ITProvider iTProvider)
        {
            return new Collaboration(CollaborationId, iTProvider, CollaborationName, Description, Category);
        }
    }
}
