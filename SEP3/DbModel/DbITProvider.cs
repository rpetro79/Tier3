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
        public string username { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double review { get; set; }
        public int noOfReviews { get; set; }
        public string type { get; set; }

        public List<DbTechnologies> toDbITProvider(ITProvider p, string username)
        {
            this.username = username;
            this.name = p.name;
            this.description = p.description;
            this.review = p.review;
            this.noOfReviews = p.noOfReviews;
            this.type = p.type;

            List<DbTechnologies> techs = new List<DbTechnologies>();
            for(int i = 0; i < p.technologies.Count; ++i)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(username, p.technologies.ElementAt(i));
                techs.Add(t);
            }
            return techs;
        }

        public IUser toUser(DbContactInfo ci, List<DbTechnologies> techs)
        {
            List<string> technologies = new List<string>();
            foreach(DbTechnologies t in techs)
            {
                technologies.Add(t.technology);
            }
            return new ITProvider(name, description, review, noOfReviews, technologies, type, ci.toContactInfo());
        }
    }
}
