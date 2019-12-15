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
    public class ITProviderDb
    {
        private async static Task<ITProvider> toITProviderAsync(DbITProvider provider, UserContext _context)
        {
            ContactInfo contactInfo = await ContactInfoDb.getContactInfoAsync(provider.Username, _context);

            List<string> technologies = TechnologiesDb.getTechnologiesOfProvider(provider.Username, _context);

            ITProvider pr = provider.toITProvider(contactInfo, technologies);

            return pr;
        }

        public async static Task<ITProvider> getITProviderAsync(string username, UserContext _context)
        {
            DbITProvider provider = await _context.ITProviders.FindAsync(username);
            if (provider == null)
                return null;
            return await toITProviderAsync(provider, _context);
        }

        public async static Task<List<ITProvider>> getITProvidersAsync(UserContext _context)
        {
            List<ITProvider> users = new List<ITProvider>();
            List<DbITProvider> providers = await _context.ITProviders.ToListAsync();
            foreach (DbITProvider provider in providers)
            {
                users.Add(await toITProviderAsync(provider, _context));
            }

            return users;
        }

        public async static Task<ActionResult<ITProvider>> getITProviderFromCollaborationAsync(string collaborationId, UserContext context)
        {
            DbCollaboration collaboration = await context.Collaborations.FindAsync(collaborationId);
            if(collaboration == null)
            {
                return null;
            }
            String iTProviderName = collaboration.ITProviderName;
            DbITProvider dbIT =await context.ITProviders.FindAsync(iTProviderName);
            if (dbIT == null)
                return null;
            DbContactInfo contactInfo = await context.contactInfo.FindAsync(iTProviderName);
            ContactInfo ci = contactInfo.toContactInfo();
            List<DbTechnologies> dbtech = await context.technologies.Where(m => m.Username == iTProviderName).ToListAsync();
            List<string> t = new List<string>();
            foreach(var db in dbtech)
            {
                t.Add(db.Technology);
            }
            ITProvider itp = dbIT.toITProvider(ci, t);
            return itp;
        }

        public async static Task<bool> putITProviderAsync(ITProvider provider, UserContext _context)
        {
            DbITProvider dbProvider = new DbITProvider();
            List<DbTechnologies> techs = dbProvider.toDbITProvider(provider);

            bool x = await ContactInfoDb.putContactInfoAsync(provider.ContactInfo, provider.Username, _context);
            if (x == false)
                return false;

            x = await TechnologiesDb.putTechnologies(techs, _context);
            if (!x)
                return false;

            _context.Entry(dbProvider).State = EntityState.Modified;

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

        public async static Task<bool> postITProviderAsync(ITProvider provider, UserContext _context)
        {
            DbITProvider p = await _context.ITProviders.FindAsync(provider.Username);
            if (p != null)
                return false;

            DbITProvider dbProvider = new DbITProvider();
            List<DbTechnologies> techs = dbProvider.toDbITProvider(provider);

            bool x = await ContactInfoDb.postContactInfoAsync(provider.ContactInfo, provider.Username, _context);
            if (x == false)
                return false;

            x = await TechnologiesDb.postTechnologies(techs, _context);
            if (x == false)
                return false;

            _context.ITProviders.Add(dbProvider);

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

        public async static Task deleteITProviderAsync(string username, UserContext _context)
        {
            await ContactInfoDb.deleteContactInfoAsync(username, _context);

            await TechnologiesDb.deleteTechnologiesOfProvider(username, _context);

            await ApplicationsDb.deleteApplicationsOfProvider(username, _context);
            ProvidersAssignedDb.deleteProvider(username, _context);
            await CollaborationManagementDb.deleteAllCollaborationsFromITProvider(username, _context);

            DbITProvider prov = _context.ITProviders.Find(username);
            _context.ITProviders.Remove(prov);

            await _context.SaveChangesAsync();
        }

        /*public async static Task<IEnumerable<ITProviderCredentials>> GetITProviderCredentialsAsync(UserContext _context)
        {
            List<ITProvider> providers = await getITProvidersAsync(_context);
            List<ITProviderCredentials> providerCredentials = new List<ITProviderCredentials>();

            foreach(ITProvider provider in providers)
            {
                DbCredentials cr = await _context.credentials.FindAsync(provider.Username);
                providerCredentials.Add(cr.toITProviderCredentials(provider));
            }
            return providerCredentials;
        }*/

        public async static Task<ITProviderCredentials> GetITProviderCredentialsAsync(string username, UserContext _context)
        {
            ITProvider provider = await getITProviderAsync(username, _context);
            if (provider == null)
                return null;
            DbCredentials cr = await _context.credentials.FindAsync(provider.Username);
            return cr.toITProviderCredentials(provider);
        }

        public async static Task<bool> postITProviderCredentialsAsync(ITProviderCredentials credentials, UserContext _context)
        {

            bool x = await postITProviderAsync(credentials.Provider, _context);

            DbCredentials dbCredentials = new DbCredentials();
            dbCredentials.toDbITProviderCredentials(credentials);
            _context.credentials.Add(dbCredentials);

             

            if (x)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
         
        public async static Task<bool> putITProviderCredentialsAsync(ITProviderCredentials credentials, UserContext _context)
        {
            DbCredentials dbCredentials = new DbCredentials();
            dbCredentials.toDbITProviderCredentials(credentials);

           /* bool x = await putITProviderAsync(credentials.Provider, _context);
            if (x == false)
                return false;*/

            _context.Entry(dbCredentials).State = EntityState.Modified;

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

        public async static Task deleteCredentialsAsync(string username, UserContext _context)
        {
            DbCredentials cr = await _context.credentials.FindAsync(username);
            if (cr != null)
                _context.credentials.Remove(cr);
            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {

            }
            await deleteITProviderAsync(username, _context);
        }
    }
}
