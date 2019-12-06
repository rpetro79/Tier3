using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.Model;
using SEP3.DbModel;
using SEP3.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace SEP3.DbManagement
{
    public class ProvidersAssignedDb
    {
        public async static Task<List<ITProvider>> getProvidersAssigned(string projectId, UserContext _context)
        {
            List<DbITProvidersAssigned> prov = await _context.ITProvidersAssigned.Where(p => p.ProjectId == projectId).ToListAsync<DbITProvidersAssigned>();

            List<ITProvider> providers = new List<ITProvider>();
            if (prov != null)
            {
                foreach (DbITProvidersAssigned p in prov)
                {
                    providers.Add(await ITProviderDb.getITProviderAsync(p.ProviderUsername, _context));
                }
            }

            return providers;
        }

        public static bool putProvidersAssigned(string projectId, List<ITProvider> assignedProviders, UserContext _context)
        {
            List<DbITProvidersAssigned> provs = _context.ITProvidersAssigned.Where(p => p.ProjectId == projectId).ToList<DbITProvidersAssigned>();
            bool contains;
            foreach (DbITProvidersAssigned pr in provs)
            {
                contains = false;
                foreach (ITProvider pr2 in assignedProviders)
                {
                    if (pr.Equals(pr2))
                    {
                        contains = true;
                    }
                }
                if (contains == false)
                    _context.ITProvidersAssigned.Remove(pr);
            }

            foreach (ITProvider pr2 in assignedProviders)
            {
                contains = false;
                foreach (DbITProvidersAssigned pr in provs)
                {
                    if (pr.Equals(pr2))
                    {
                        contains = true;
                    }
                }
                if (contains == false)
                {
                    DbITProvidersAssigned provAssigned = new DbITProvidersAssigned(pr2.Username, projectId);
                    _context.ITProvidersAssigned.Add(provAssigned);
                }
            }
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

        public async static Task deleteProvidersAssignedToProject(string projectId, UserContext _context)
        {
            var itP = await _context.ITProvidersAssigned.Where(p => p.ProjectId == projectId).ToListAsync<DbITProvidersAssigned>();
            foreach (DbITProvidersAssigned p in itP)
            {
                _context.ITProvidersAssigned.Remove(p);
            }

            _context.SaveChanges();
        }

        public static void deleteProvider(string username, UserContext _context)
        {
            var providersAssigned = _context.ITProvidersAssigned.Where(p => p.ProviderUsername == username).ToList();

            foreach(DbITProvidersAssigned p in providersAssigned)
            {
                _context.ITProvidersAssigned.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
