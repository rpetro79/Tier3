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
            DbContactInfo contactInfo = await _context.contactInfo.SingleAsync(contactInfo => contactInfo.Username == provider.Username);

            List<DbTechnologies> technologies = new List<DbTechnologies>();
            technologies = _context.technologies.Where(technology => technology.Username == provider.Username).ToList<DbTechnologies>();

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

        public async static Task<bool> putITProviderAsync(ITProvider provider, UserContext _context)
        {
            DbITProvider dbProvider = new DbITProvider();
            List<DbTechnologies> techs = dbProvider.toDbITProvider(provider);

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(provider.ContactInfo, provider.Username);

            List<DbTechnologies> toDeleteTechs = _context.technologies.Where(tec => tec.Username == provider.Username).ToList<DbTechnologies>();
            foreach (DbTechnologies t in toDeleteTechs)
            {
                _context.technologies.Remove(t);
            }
            await _context.SaveChangesAsync();

            foreach (DbTechnologies t in techs)
            {
                _context.technologies.Add(t);
            }

            _context.Entry(provider).State = EntityState.Modified;
            _context.Entry(ci).State = EntityState.Modified;

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

            foreach (DbTechnologies tec in techs)
            {
                _context.technologies.Add(tec);
            }


            _context.ITProviders.Add(dbProvider);

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(provider.ContactInfo, provider.Username);
            _context.contactInfo.Add(ci);
           
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
            DbContactInfo ci = _context.contactInfo.Find(username);
            _context.contactInfo.Remove(ci);

            List<DbTechnologies> techs = _context.technologies.Where(tec => tec.Username == username).ToList<DbTechnologies>();
            foreach (DbTechnologies tec in techs)
            {
                _context.technologies.Remove(tec);
            }

            DbITProvider prov = _context.ITProviders.Find(username);
            _context.ITProviders.Remove(prov);

            await _context.SaveChangesAsync();
        }

        public async static Task<IEnumerable<ITProviderCredentials>> GetITProviderCredentialsAsync(UserContext _context)
        {
            List<ITProvider> providers = await getITProvidersAsync(_context);
            List<ITProviderCredentials> providerCredentials = new List<ITProviderCredentials>();

            foreach(ITProvider provider in providers)
            {
                DbCredentials cr = await _context.credentials.FindAsync(provider.Username);
                providerCredentials.Add(cr.toITProviderCredentials(provider));
            }
            return providerCredentials;
        }

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

            Task<bool> task = postITProviderAsync(credentials.Provider, _context);

            DbCredentials dbCredentials = new DbCredentials();
            dbCredentials.toDbITProviderCredentials(credentials);
            _context.credentials.Add(dbCredentials);

            bool x = await task;

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
