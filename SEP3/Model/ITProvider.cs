using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbModel;

namespace SEP3.Model
{
    [Serializable]
    public class ITProvider : IUser
    {
        public string name { get; set; }
        public string description { get; set; }
        public double review { get; set; }
        public int noOfReviews;
        public List<string> technologies { get; set; }
        public string type { get; set; }
        public ContactInfo contactInfo { get; set; }

        public ITProvider(string name, string description, List<string> techs, string type, ContactInfo contactInfo)
        {
            this.name = name;
            this.description = description;
            technologies = new List<string>();
            foreach (string t in techs)
            {
                this.technologies.Add(t);
            }
            this.contactInfo = contactInfo;
            review = 0;
            noOfReviews = 0;
            this.type = type;
        }

        public ITProvider(string name, string description, double review, int noOfReviews, List<string> techs, string type, ContactInfo contactInfo)
        {
            this.name = name;
            this.description = description;
            technologies = new List<string>();

            foreach (string t in techs)
            {
                this.technologies.Add(t);
            }

            this.contactInfo = contactInfo;
            this.review = review;
            this.noOfReviews = noOfReviews;
            this.type = type;
        }

        public ContactInfo getContactInfo()
        {
            return contactInfo;
        }

        public void addTechnology(string technology)
        {
            technologies.Add(technology);
        }

        public void removeTechnology(string technology)
        {
            technologies.Remove(technology);
        }

        public void replaceTechnologies(List<string> techs)
        {
            technologies = techs;
        }

        public void reviewReceived(int newReview)
        {
            if (noOfReviews == 0)
                review = newReview;
            else
            {
                review = (review * noOfReviews + newReview) / (noOfReviews+1);
            }
            noOfReviews++;                
        }
    }
}
