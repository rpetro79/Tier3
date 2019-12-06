using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbApplication
    {
        [Key]
        public int Id { get; set; }
        public string ProposalId { get; set; }
        public string ITproviderUsername { get; set; }
        public string ApplicationText { get; set; }
        public DateTime Date { get; set; }
        public string Approved { get; set; }

        public DbApplication() { }

        public Application toApplication(ITProvider provider)
        {
            return new Application(ProposalId, provider, ApplicationText, Date, (ApplicationAnswer)Enum.Parse(typeof(ApplicationAnswer), Approved));
        }

        public void toDbApplication(Application app)
        {
            this.ProposalId = app.ProjectId;
            this.ITproviderUsername = app.Provider.Username;
            this.ApplicationText = app.ApplicationText;
            this.Date = app.Date;
            this.Approved = Enum.GetName(typeof(ApplicationAnswer), app.Answer);
        }
    }
}
