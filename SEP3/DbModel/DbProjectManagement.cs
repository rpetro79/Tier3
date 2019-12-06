using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SEP3.Model;

namespace SEP3.DbModel
{
    public class DbProjectManagement
    {
        [Key]
        public string ProjectId { get; set; }
        public bool Closed { get; set; }
        
        public ProjectManagement toProjectManagement(Project p, List<Application> aps, List<ITProvider> providers)
        {
            return new ProjectManagement(p, Closed, aps, providers);
        }

        public /*List<DbApplication>*/void toDbProjectManagement(ProjectManagement pm)
        {
            this.ProjectId = pm.project.ProjectId;
            this.Closed = pm.Closed;
            /*List<DbApplication> dbApps = new List<DbApplication>();
            DbApplication ap;
            foreach(Application app in pm.Applications)
            {
                ap = new DbApplication();
                ap.toDbApplication(app);
                dbApps.Add(ap);
            }
            return dbApps;*/
        }
    }
}
