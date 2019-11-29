using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEP3.Model
{
    public enum ApplicationAnswer
    {
        APPROVED,
        DECLINED,
        NOT_ANSWERED
    }


    public class Application
    {
        public string ProjectId { get; set; }
        public ITProvider Provider { get; set; }
        public string ApplicationText { get; set; }
        public DateTime Date { get; set; }
        public ApplicationAnswer Approved { get; set; }

        public Application() { }

        public Application(string projectId, ITProvider provider, string applicationText, DateTime date)
        {
            this.ProjectId = projectId;
            this.Provider = provider;
            this.ApplicationText = applicationText;
            this.Date = date;
            this.Approved = ApplicationAnswer.NOT_ANSWERED;
        }

        public Application(string projectId, ITProvider provider, string applicationText, DateTime date, ApplicationAnswer approved)
        {
            this.ProjectId = projectId;
            this.Provider = provider;
            this.ApplicationText = applicationText;
            this.Date = date;
            this.Approved = approved;
        }
    }
}
