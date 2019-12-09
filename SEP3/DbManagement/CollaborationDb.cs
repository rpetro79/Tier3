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
    public class CollaborationDb
    {
        //Get all collaborations
        public async static Task<List<Collaboration>> GetCollaborationsAsync(UserContext _context)
        {
            List<DbCollaboration> DBcollaborations = _context.Collaborations.ToList<DbCollaboration>();
            List<Collaboration> collaborations = new List<Collaboration>();
            ITProvider itp;
            foreach(DbCollaboration dbc in DBcollaborations)
            {
                itp = await ITProviderDb.getITProviderAsync(dbc.ITProviderName, _context);
                collaborations.Add(dbc.ToCollaboration(itp));
            }
            return collaborations;
        }

        //Get collaboration by id
        public async static Task<Collaboration> GetCollaborationAsync(string collaborationId, UserContext _context)
        {
            var collaboration = await _context.Collaborations.FindAsync(collaborationId);

            if(collaboration == null)
            {
                return null;
            }
            else
            {
                ITProvider itp = await ITProviderDb.getITProviderAsync(collaboration.ITProviderName, _context);
                Collaboration clb = collaboration.ToCollaboration(itp);
                return clb;
            }
        }

        //Post new Collaboration
        public async static Task<bool> PostCollaborationAsync(Collaboration collab, UserContext _context)
        {
            List<DbCollaboration> collaborations = _context.Collaborations.Where(c => c.ITProviderName == collab.ITProvider.Username).ToList<DbCollaboration>();
            if(collaborations.Count == 0)
            {
                collab.CollaborationId = collab.ITProvider.Username + 1;
            }
            else 
            {
                int n = collab.ITProvider.Username.Length;
                int number;
                int max = 1;
                foreach(DbCollaboration dbclb in collaborations)
                {
                    number = Int32.Parse(dbclb.CollaborationId.Substring(n));
                    if (max < number)
                        max = number;
                }
                collab.CollaborationId = collab.ITProvider.Username + (max + 1);
            }

            DbCollaboration dbCollaboration = new DbCollaboration();
            dbCollaboration.ToDbCollaboration(collab);
            _context.Collaborations.Add(dbCollaboration);
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

        //Put an already existing collaboration
        public async static Task<bool> PutCollaborationAsync(Collaboration collaboration, UserContext _context)
        {
            DbCollaboration dbcollab= _context.Collaborations.Find(collaboration.CollaborationId);
            if (dbcollab == null)
                return false;

            dbcollab.ToDbCollaboration(collaboration);
            _context.Entry(dbcollab).State = EntityState.Modified;

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

        //Delete a collaboration from an It provider
        public async static Task<bool> DeleteCollaborationFromITProvider(string CollaborationId, UserContext _context)
        {
            var collaboration = await _context.Collaborations.FindAsync(CollaborationId);
            if (collaboration == null)
                return false;

            _context.Collaborations.Remove(collaboration);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete all collaborations from an It provider
        public async static Task DeleteAllCollaborationsFromITProvider(string Username, UserContext _context)
        {
            var collaborations = _context.Collaborations.Where(c => c.ITProviderName == Username).ToList<DbCollaboration>();
            foreach (var collaboration in collaborations)
            {
                _context.Collaborations.Remove(collaboration);
                _context.SaveChanges();
            }
        }



    }
}
