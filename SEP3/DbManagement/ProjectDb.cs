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
    public class ProjectDb
    {

        public async static Task<List<Project>> getProjectsAsync(UserContext _context)
        {
            List<ProjectManagement> list = await ProjectManagementDb.getAllProjectManagementsAsync(_context);
            List<Project> projects = new List<Project>();
            foreach (ProjectManagement p in list)
            {
                if (!p.Closed)
                    projects.Add(p.project);
            }
            return projects;
        }


        public async static Task<Project> getProjectAsync(string projectId, UserContext _context)
        {
            var project = await _context.Projects.FindAsync(projectId);

            if (project == null)
            {
                return null;
            }

            Customer c = await CustomerDb.getCustomerAsync(project.customerUsername, _context);
            Project pr = project.toProject(c);
            return pr;
        }

        public async static Task<bool> putProjectAsync(Project project, UserContext _context)
        {

            DbProject p = _context.Projects.Find(project.ProjectId);
            if (p == null)
                return false;
            p.toDbProject(project);
            _context.Entry(p).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async static Task<bool> postProjectAsync(Project project, UserContext _context)
        {
            List<DbProject> projects = _context.Projects.Where(p => p.customerUsername == project.customer.Username).ToList<DbProject>();
            if (projects.Count == 0)
            {
                project.ProjectId = project.customer.Username + 1;
            }
            else
            {
                int n = project.customer.Username.Length;
                int number;
                int max = 1;
                foreach (DbProject p in projects)
                {
                    number = Int32.Parse(p.ProjectId.Substring(n));
                    if (max < number)
                        max = number;
                }
                project.ProjectId = project.customer.Username + (max + 1);
            }

            DbProject dbProject = new DbProject();
            dbProject.toDbProject(project);
            _context.Projects.Add(dbProject);
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
        public async static Task<List<Project>> getProjectsByCustomerUsernameAsync(string customerUsername, UserContext _context)
        {
            List<DbProject> projects = _context.Projects.ToList<DbProject>();
            List<Project> pr = new List<Project>();
            Customer c;
            foreach (DbProject p in projects)
            {

                c = await CustomerDb.getCustomerAsync(p.customerUsername, _context);
                if (c.Username == customerUsername)
                    pr.Add(p.toProject(c));
            }
            return pr;
        }

        public async static Task deleteProject(string projectId, UserContext _context)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null)
            {
                return;
            }

            _context.Projects.Remove(project);
                await _context.SaveChangesAsync();

        }

        public async static Task deleteProjectFromCustomer(string username, UserContext _context)
        {
            var projects = _context.Projects.Where(p => p.customerUsername == username).ToList();
            foreach(DbProject p in projects)
            {
                _context.Projects.Remove(p);
                _context.SaveChanges();
            }
        }

        private static bool ProjectExists(string id, UserContext _context)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }



    }
}
