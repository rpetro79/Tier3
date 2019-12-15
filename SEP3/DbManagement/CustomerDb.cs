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
            DbCredentials cr = _context.credentials.Find(credentials.Customer.Username);
            if (cr == null)
                return false;
            cr.toDbCustomerCredentials(credentials);

            bool x = await putCustomerAsync(credentials.Customer, _context);
            if (x == false)
                return false;

            x = await ContactInfoDb.putContactInfoAsync(credentials.Customer.ContactInfo, credentials.Customer.Username, _context);
            if (x == false)
                return false;

            _context.Entry(cr).State = EntityState.Modified;

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

            bool x = await postCustomerAsync(credentials.Customer, _context);
            if (x == false)
                return false;

            x = await ContactInfoDb.postContactInfoAsync(credentials.Customer.ContactInfo, credentials.Customer.Username, _context);
            if (x == false)
                return false;
            
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
        public async static Task<ActionResult<Customer>> getCustomerByIdAsync(string projectId, UserContext _context)
        {
            DbProject dbProject = await _context.Projects.FindAsync(projectId);
            String customerUsrename = dbProject.customerUsername;
            DbCustomer customer = await _context.customers.FindAsync(customerUsrename);
            if (customer == null)
                return null;

            ContactInfo ci = await ContactInfoDb.getContactInfoAsync(customerUsrename, _context);

            return customer.toCustomer(ci);
        }
        public async static Task deleteCredentialsAsync(string username, UserContext _context)
        {
            var dbCustomerCredentials = _context.credentials.Find(username);
            if (dbCustomerCredentials == null)
            {
                return;
            }

            await deleteCustomerAsync(username, _context);
            
            _context.credentials.Remove(dbCustomerCredentials);
            await _context.SaveChangesAsync();
        }

        public async static Task<Customer> getCustomerAsync(string username, UserContext _context)
        {
            DbCustomer customer = await _context.customers.FindAsync(username);
            if (customer == null)
                return null;

            ContactInfo ci = await ContactInfoDb.getContactInfoAsync(username, _context);

            return customer.toCustomer(ci);
        }

        public async static Task<IEnumerable<Customer>> getCustomersAsync(UserContext _context)
        {
            List<DbCustomer> custs = await _context.customers.ToListAsync<DbCustomer>();
            List<Customer> customers = new List<Customer>();
            foreach(DbCustomer cust in custs)
            {
                ContactInfo ci = await ContactInfoDb.getContactInfoAsync(cust.Username, _context);
                customers.Add(cust.toCustomer(ci));
            }
            return customers;
        }

        public async static Task<bool> putCustomerAsync(Customer cust, UserContext _context)
        {
            var c = _context.customers.Find(cust.Username);
            if (c == null)
                return false;
            c.toDbCustomer(cust);

            bool x = await ContactInfoDb.putContactInfoAsync(cust.ContactInfo, cust.Username, _context);
            if(x == false)
            {
                return false;
            }

            _context.Entry(c).State = EntityState.Modified;

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

        public async static Task<bool> postCustomerAsync(Customer customer, UserContext _context)
        {
            if (_context.customers.Any(c => c.Username == customer.Username))
                return false;
            DbCustomer cust = new DbCustomer();
            cust.toDbCustomer(customer);
            await _context.customers.AddAsync(cust);

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

        public async static Task deleteCustomerAsync(string username, UserContext _context)
        {
            await ContactInfoDb.deleteContactInfoAsync(username, _context);
            await ProjectManagementDb.deleteProjectsManagementOfUser(username, _context);
            DbCustomer cust = _context.customers.Find(username);
            _context.customers.Remove(cust);
            await _context.SaveChangesAsync();
        }
    }
}
