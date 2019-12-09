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
    public class ContactInfoDb
    {
        public async static Task<ContactInfo> getContactInfoAsync(string username, UserContext _context)
        {
            DbContactInfo dbci = await _context.contactInfo.FindAsync(username);
            if (dbci == null)
                return null;
            ContactInfo ci = dbci.toContactInfo();
            return ci;
        }

        public async static Task<bool> putContactInfoAsync(ContactInfo contactInfo, string username, UserContext _context)
        {
            DbContactInfo ci = _context.contactInfo.Find(username);
            ci.toDbContactInfo(contactInfo, username);

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

        public async static Task<bool> postContactInfoAsync(ContactInfo contactInfo, string username, UserContext _context)
        {
            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(contactInfo, username);
            await _context.contactInfo.AddAsync(ci);
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

        public async static Task deleteContactInfoAsync(string username, UserContext _context)
        {
            DbContactInfo ci = _context.contactInfo.Find(username);
            _context.contactInfo.Remove(ci);

            await _context.SaveChangesAsync();
        }
    }
}
