using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.Model;
using SEP3.DbModel;
using SEP3.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SEP3.DbManagement
{
    public class ApplicationsDb
    {
        public async static Task<List<Application>> getApplicationsForProjectAsync(string projectId, UserContext _context)
        {
            List<DbApplication> applications = _context.Applications.Where(app => app.ProposalId == projectId).ToList<DbApplication>();
            if (applications == null)
                return new List<Application>();
            List<Application> apps = new List<Application>();
            foreach(DbApplication application in applications)
            {
                ITProvider provider = await ITProviderDb.getITProviderAsync(application.ITproviderUsername, _context);
                apps.Add(application.toApplication(provider));
            }
            return apps;
        }

        public static bool putApplications(List<Application> applications, UserContext _context)
        {
            bool x;
            foreach(Application ap in applications)
            {
                x = putApplication(ap, _context);
                if (x == false)
                    return false;
            }
            return true;
        }

        public static bool putApplication(Application application, UserContext _context)
        {
            List<DbApplication> dbApps = _context.Applications.Where(ap => ap.ITproviderUsername == application.Provider.Username && ap.ProposalId == application.ProjectId).ToList<DbApplication>();
            if (dbApps == null || dbApps.Count == 0)
                return false;
            
            dbApps[0].toDbApplication(application);

            _context.Entry(dbApps[0]).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public static bool postApplication(Application application, UserContext _context)
        {
            /*if (_context.Applications.Where(ap => ap.ITproviderUsername == application.Provider.Username && ap.ProposalId == application.ProjectId).Any())
                return false;*/
            /*if (_context.Applications.Any(ap => ap.ITproviderUsername == application.Provider.Username && ap.ProposalId == application.ProjectId))
                return false;*/
            DateTime d = DateTime.Now;
            application.Date = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DbApplication app = new DbApplication();
            app.toDbApplication(application);
            _context.Applications.Add(app);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public async static Task deleteApplicationsOnProject(string projectId, UserContext _context)
        {
            var apps = await _context.Applications.Where(a => a.ProposalId == projectId).ToListAsync<DbApplication>();
            if (apps == null)
            {
                return;
            }

            foreach(DbApplication a in apps)
            {
                _context.Applications.Remove(a);
            }
            await _context.SaveChangesAsync();
        }

        public async static Task deleteApplication(string projectId, string providerUsername, UserContext _context)
        {
            var app = await _context.Applications.SingleAsync(a => a.ProposalId == projectId && a.ITproviderUsername == providerUsername);
            
            if (app == null)
            {
                return;
            }

            _context.Applications.Remove(app);
            await _context.SaveChangesAsync();
        }

        public async static Task deleteApplicationsOfProvider(string providerUsername, UserContext _context)
        {
            var app = await _context.Applications.Where(a => a.ITproviderUsername == providerUsername).ToListAsync();

            if (app == null)
            {
                return;
            }

            foreach(DbApplication a in app)
            {
                _context.Applications.Remove(a);
            }
            await _context.SaveChangesAsync();
        }
    }
}
