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

    public class CustomerDb
    {

        public async static Task<IEnumerable<CustomerCredentials>> getCustomerCredentialsAsync(UserContext _context)
        {
            List<CustomerCredentials> users = new List<CustomerCredentials>();
            List<DbCredentials> credentials = await _context.credentials.ToListAsync<DbCredentials>();
            CustomerCredentials c;
            foreach (DbCredentials credential in credentials)
            {
                c = await toCredentials(credential, _context);
                if(c != null)
                    users.Add(c);
            }
            return users;
        }

        private async static Task<CustomerCredentials> toCredentials(DbCredentials credential, UserContext _context)
        {
            Customer cust = await getCustomerAsync(credential.Username, _context);
            CustomerCredentials cc = null;
            if (cust != null)
                cc = new CustomerCredentials(credential.Password, cust);
            return cc;
        }

        public async static Task<CustomerCredentials> getCustomerCredentialsAsync(string username, UserContext _context)
        {
            DbCredentials dbCustomerCredentials = await _context.credentials.FindAsync(username);
            if (dbCustomerCredentials == null)
                return null;
            CustomerCredentials user = await toCredentials(dbCustomerCredentials, _context);

            return user;
        }

        public async static Task<bool> putCustomerCredentialsAsync(CustomerCredentials credentials, UserContext _context)
        {
            DbCustomer customer = new DbCustomer();
            customer.toDbCustomer((Customer)credentials.Customer);
            _context.Entry(customer).State = EntityState.Modified;

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(credentials.Customer.ContactInfo, credentials.Customer.Username);
            _context.Entry(ci).State = EntityState.Modified;

            DbCredentials dbCustomerCredentials = new DbCredentials();
            dbCustomerCredentials.toDbCustomerCredentials(credentials);
            _context.Entry(dbCustomerCredentials).State = EntityState.Modified;

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
        public async static Task<bool> postCustomerCredentialsAsync(CustomerCredentials credentials, UserContext _context)
        {
            DbCredentials dbCustomerCredentials = new DbCredentials();
            dbCustomerCredentials.toDbCustomerCredentials(credentials);
            await _context.credentials.AddAsync(dbCustomerCredentials);

            DbCustomer cust = new DbCustomer();
            cust.toDbCustomer((Customer)credentials.Customer);
            await _context.customers.AddAsync(cust);

            DbContactInfo ci = new DbContactInfo();
            ci.toDbContactInfo(credentials.Customer.ContactInfo, credentials.Customer.Username);
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

        public async static Task deleteAsync(string username, UserContext _context)
        {
            var dbCustomerCredentials = _context.credentials.Find(username);
            if (dbCustomerCredentials == null)
            {
                return;
            }

            DbCustomer cust = _context.customers.Find(username);
            _context.customers.Remove(cust);

            DbContactInfo ci = _context.contactInfo.Find(username);
            _context.contactInfo.Remove(ci);

            _context.credentials.Remove(dbCustomerCredentials);
            await _context.SaveChangesAsync();
        }

        private static bool DbCustomerCredentialsExists(string id, UserContext _context)
        {
            return _context.credentials.Any(e => e.Username == id);
        }

        public async static Task<Customer> getCustomerAsync(string username, UserContext _context)
        {
            DbCustomer customer = await _context.customers.FindAsync(username);
            if (customer == null)
                return null;

            return await getCustomerWithContactInfoAsync(customer, _context);
        }

        public async static Task<IEnumerable<Customer>> getCustomers(UserContext _context)
        {
            List<DbCustomer> custs = await _context.customers.ToListAsync<DbCustomer>();
            List<Customer> customers = new List<Customer>();
            foreach(DbCustomer cust in custs)
            {
                customers.Add(await getCustomerWithContactInfoAsync(cust, _context));
            }
            return customers;
        }

        private async static Task<Customer> getCustomerWithContactInfoAsync(DbCustomer cust, UserContext _context)
        {
            DbContactInfo contactInfo = await _context.contactInfo.SingleAsync(contactInfo => contactInfo.Username == cust.Username);
            return cust.toCustomer(contactInfo);
        }
    }
}
