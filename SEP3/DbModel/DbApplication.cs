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
        public string ProjectId { get; set; }
        public string ITproviderUsername { get; set; }
        public string ApplicationText { get; set; }
        public string  Date { get; set; }
        public string Answer { get; set; }

        public DbApplication() { }

        public Application toApplication(ITProvider provider)
        {
            return new Application(ProjectId, provider, ApplicationText, Date, Answer);
        }

        public void toDbApplication(Application app)
        {
            this.ProjectId = app.ProjectId;
            this.ITproviderUsername = app.Provider.Username;
            this.ApplicationText = app.ApplicationText;
            this.Date = app.Date;
            this.Answer = app.Answer;
        }
    }
}
