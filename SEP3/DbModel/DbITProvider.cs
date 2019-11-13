using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbITProvider
    {
        [Key]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Review { get; set; }
        public int NoOfReviews { get; set; }
        public string Type { get; set; }

        public List<DbTechnologies> toDbITProvider(ITProvider p)
        {
            this.Username = p.Username;
            this.Name = p.Name;
            this.Description = p.Description;
            this.Review = p.Review;
            this.NoOfReviews = p.NoOfReviews;
            this.Type = p.Type;

            List<DbTechnologies> techs = new List<DbTechnologies>();
            for(int i = 0; i < p.Technologies.Count; ++i)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(Username, p.Technologies.ElementAt(i));
                techs.Add(t);
            }
            return techs;
        }

        public ITProvider toITProvider(DbContactInfo ci, List<DbTechnologies> techs)
        {
            List<string> technologies = new List<string>();
            foreach(DbTechnologies t in techs)
            {
                technologies.Add(t.Technology);
            }
            return new ITProvider(Username, Name, Description, Review, NoOfReviews, technologies, Type, ci.toContactInfo());
        }
    }
}
