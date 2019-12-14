using Microsoft.EntityFrameworkCore;
using SEP3.DbContexts;
using SEP3.DbModel;
using SEP3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3.DbManagement
{
    public class CollaborationManagementDb
    {
        public async static Task<CollaborationManagement> getCollaborationManagementAsync(string collaborationId, UserContext _context)
        {
            DbCollaborationManagement collaborationManagement = await _context.CollaborationManagement.FindAsync(collaborationId);
            if (collaborationManagement == null)
                return null;
            return await toCollaborationManagementAsync(collaborationManagement, _context);
        }

        private async static Task<CollaborationManagement> toCollaborationManagementAsync(DbCollaborationManagement collaborationManagement, UserContext _context)
        {
            Collaboration collaboration = await CollaborationDb.GetCollaborationAsync(collaborationManagement.CollaborationId, _context);

            List<ITProvider> providers = await ITProvidersOnCollaborationDb.getProvidersOnCollaboration(collaborationManagement.CollaborationId, _context);

            CollaborationManagement cm = collaborationManagement.toCollaborationManagement(collaboration, providers);
            return cm;
        }

        public async static Task<List<CollaborationManagement>> getCollaborationManagementOfUserAsync(string username, UserContext _context)
        {
            List<DbCollaborationManagement> collaborationManagement = await _context.CollaborationManagement.Where(pm => pm.CollaborationId.Substring(0, username.Length) == username).ToListAsync<DbCollaborationManagement>();
            List<CollaborationManagement> cmanage = new List<CollaborationManagement>();
            foreach (DbCollaborationManagement cm in collaborationManagement)
            {
                cmanage.Add(await toCollaborationManagementAsync(cm, _context));
            }

            return cmanage;
        }

        public async static Task<bool> putCollaborationManagementAsync(CollaborationManagement cm, UserContext _context)
        {
            DbCollaborationManagement c = _context.CollaborationManagement.(cm.Collaboration.CollaborationId);
            if (c == null)
                return false;
            c.toDbCollaborationManagement(cm);
            _context.Entry(c).State = EntityState.Modified;
            bool x = await CollaborationDb.PutCollaborationAsync(cm.Collaboration, _context);

            if (!x)
                return false;
            x = ITProvidersOnCollaborationDb.putProvidersOnCollaboration(cm.Collaboration.CollaborationId, cm.ProvidersOnCollaboration, _context);
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

        public async static Task<bool> postCollaborationManagementAsync(CollaborationManagement cm, UserContext _context)
        {
            DbCollaborationManagement c = _context.CollaborationManagement.Find(cm.Collaboration.CollaborationId);
            if (c != null)
                return false;
            bool x = await CollaborationDb.PostCollaborationAsync(cm.Collaboration, _context);
            if (!x)
                return false;
            c = new DbCollaborationManagement();
            c.toDbCollaborationManagement(cm);

            _context.CollaborationManagement.Add(c);

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

        public async static Task deleteCollaborationManagement(string collaborationId, UserContext _context)
        {
            var collaborationM = await _context.CollaborationManagement.FindAsync(collaborationId);
            await CollaborationDb.DeleteCollaborationFromITProvider(collaborationId, _context);
            await ITProvidersOnCollaborationDb.deleteProvidersOnCollaboration(collaborationId, _context);

            if (collaborationM == null)
            {
                return;
            }

            _context.CollaborationManagement.Remove(collaborationM);
            await _context.SaveChangesAsync();
        }

        public async static Task DeleteAllCollaborationsFromITProvider(string username, UserContext _context)
        {
            var collaborationMs = _context.CollaborationManagement.Where(c => c.CollaborationId.Substring(0, username.Length) == username).ToList();

            foreach (DbCollaborationManagement cm in collaborationMs)
            {
                await deleteCollaborationManagement(cm.CollaborationId, _context);
            }
        }
    }
}
