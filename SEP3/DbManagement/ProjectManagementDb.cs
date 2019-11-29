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
    public class ProjectManagementDb
    {
        public async static Task<ProjectManagement> getProjectManagementAsync(string projectId, UserContext _context)
        {
            DbProjectManagement projectManagement = await _context.ProjectManagement.FindAsync(projectId);
            if (projectManagement == null)
                return null;
            return await toProjectManagementAsync(projectManagement, _context);
        }

        private async static Task<ProjectManagement> toProjectManagementAsync(DbProjectManagement projectManagement, UserContext _context)
        {
            Task<Project> tproject = ProjectDb.getProjectAsync(projectManagement.ProjectId, _context);
            Task<List<DbITProvidersAssigned>> tprov = _context.ITProvidersAssigned.Where(p => p.ProjectId == projectManagement.ProjectId).ToListAsync<DbITProvidersAssigned>();

            List<Application> apps = await ApplicationsDb.getApplicationsAsync(projectManagement.ProjectId, _context);

            List<DbITProvidersAssigned> prov = await tprov;
            List<ITProvider> providers = new List<ITProvider>();
            if (prov != null)
            {
                foreach (DbITProvidersAssigned p in prov)
                {
                    providers.Add(await ITProviderDb.getITProviderAsync(p.ProviderUsername, _context));
                }
            }

            Project pr = await tproject;
            ProjectManagement pm = projectManagement.toProjectManagement(pr, apps, providers);
            return pm;
        }

        public async static Task<List<ProjectManagement>> getProjectsManagementOfUserAsync(string username, UserContext _context)
        {
            List<DbProjectManagement> projectManagement = await _context.ProjectManagement.Where(pm => pm.ProjectId == username).ToListAsync<DbProjectManagement>();
            List<ProjectManagement> pms = new List<ProjectManagement>();
            foreach(DbProjectManagement pm in projectManagement)
            {
                pms.Add(await toProjectManagementAsync(pm, _context));
            }

            return pms;
        }

        public async static Task<bool> putProjectManagementAsync(ProjectManagement pm, UserContext _context)
        {
            DbProjectManagement p = _context.ProjectManagement.Find(pm.project.ProjectId);
            if (p == null)
                return false;
            p.toDbProjectManagement(pm);
            _context.Entry(p).State = EntityState.Modified;
            bool x = await ProjectDb.putProjectAsync(pm.project, _context);
            if (!x)
                return false;
            x = ApplicationsDb.putApplications(pm.Applications, _context);
            if (!x)
                return false;
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

        public async static Task<bool> postProjectManagementAsync(ProjectManagement pm, UserContext _context)
        {
            DbProjectManagement p = _context.ProjectManagement.Find(pm.project.ProjectId);
            if (p != null)
                return false;
            bool x = await ProjectDb.postProjectAsync(pm.project, _context);
            if (!x)
                return false;
            p = new DbProjectManagement();
            p.toDbProjectManagement(pm);

            _context.ProjectManagement.Add(p);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public async static Task deleteProjectManagement(string projectId, UserContext _context)
        {
            var projectM = await _context.ProjectManagement.FindAsync(projectId);
            await ProjectDb.deleteProject(projectId, _context);
            await ApplicationsDb.deleteApplications(projectId, _context);
            var itP = await _context.ITProvidersAssigned.Where(p => p.ProjectId == projectId).ToListAsync<DbITProvidersAssigned>();
            foreach (DbITProvidersAssigned p in itP)
            {
                _context.ITProvidersAssigned.Remove(p);
            }

            if (projectM == null)
            {
                return;
            }

            _context.ProjectManagement.Remove(projectM);
            await _context.SaveChangesAsync();
        }
    }
}
