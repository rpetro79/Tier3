using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbModel;

namespace SEP3.Model
{
    [Serializable]
    public class ITProvider
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Review { get; set; }
        public int NoOfReviews { get; set; }
        public List<string> Technologies { get; set; }
        public string Type { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public ITProvider()
        {

        }

        public ITProvider(string username, string name, string description, List<string> techs, string type, ContactInfo contactInfo)
        {
            this.Username = username;
            this.Name = name;
            this.Description = description;
           // this.Technologies = techs;
            Technologies = new List<string>();
            foreach (string t in techs)
            {
                this.Technologies.Add(t);
            }
            this.ContactInfo = contactInfo;
            Review = 0;
            NoOfReviews = 0;
            this.Type = type;
        }

        public ITProvider(string username, string name, string description, double review, int noOfReviews, List<string> techs, string type, ContactInfo contactInfo)
        {
            this.Username = username;
            this.Name = name;
            this.Description = description;
            this.Technologies = techs;
            Technologies = new List<string>();

            foreach (string t in techs)
            {
                this.Technologies.Add(t);
            }

            this.ContactInfo = contactInfo;
            this.Review = review;
            this.NoOfReviews = noOfReviews;
            this.Type = type;
        }

        public void addTechnology(string technology)
        {
            Technologies.Add(technology);
        }

        public void removeTechnology(string technology)
        {
            Technologies.Remove(technology);
        }

        public void replaceTechnologies(List<string> techs)
        {
            Technologies = techs;
        }

        public void reviewReceived(int newReview)
        {
            if (NoOfReviews == 0)
                Review = newReview;
            else
            {
                Review = (Review * NoOfReviews + newReview) / (NoOfReviews+1);
            }
            NoOfReviews++;                
        }
    }
}
