﻿using System;
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

        public async static Task<List<ProjectManagement>> getAllProjectManagementsAsync(UserContext _context)
        {
            List<DbProjectManagement> list = await _context.ProjectManagement.ToListAsync<DbProjectManagement>();
            List<ProjectManagement> returnList = new List<ProjectManagement>();
            foreach (DbProjectManagement m in list)
            {
                returnList.Add(await toProjectManagementAsync(m, _context));
            }
            return returnList;
        }

        private async static Task<ProjectManagement> toProjectManagementAsync(DbProjectManagement projectManagement, UserContext _context)
        {
            Project project = await ProjectDb.getProjectAsync(projectManagement.ProjectId, _context);
            
            List<Application> apps = await ApplicationsDb.getApplicationsForProjectAsync(projectManagement.ProjectId, _context);

            List<ITProvider> providers = await ProvidersAssignedDb.getProvidersAssigned(projectManagement.ProjectId, _context);

            ProjectManagement pm = projectManagement.ToProjectManagement(project, apps, providers);
            return pm;
        }

        public async static Task<List<ProjectManagement>> getProjectsManagementOfUserAsync(string username, UserContext _context)
        {
            List<DbProjectManagement> projectManagement = await _context.ProjectManagement.Where(pm => pm.ProjectId.Substring(0, username.Length) == username).ToListAsync<DbProjectManagement>();
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
            p.ToDbProjectManagement(pm);
            _context.Entry(p).State = EntityState.Modified;
            
            bool x = ApplicationsDb.putApplications(pm.Applications, _context);
             foreach (Application a in pm.Applications)
            {
                if (a.Answer.Equals("APPROVED"))
                    pm.AssignedProviders.Add(a.Provider);
            }
            x = ProvidersAssignedDb.putProvidersAssigned(pm.project.ProjectId, pm.AssignedProviders, _context);
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
            p.ToDbProjectManagement(pm);

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
            await ApplicationsDb.deleteApplicationsOnProject(projectId, _context);
            await ProvidersAssignedDb.deleteProvidersAssignedToProject(projectId, _context);

            if (projectM == null)
            {
                return;
            }

            _context.ProjectManagement.Remove(projectM);
            await _context.SaveChangesAsync();
        }

        public async static Task deleteProjectsManagementOfUser(string username, UserContext _context)
        {
            var projectMs = _context.ProjectManagement.Where(p => p.ProjectId.Substring(0, username.Length) == username).ToList();

            foreach (DbProjectManagement pr in projectMs)
            {
                await deleteProjectManagement(pr.ProjectId, _context);
            }
        }
    }
}
