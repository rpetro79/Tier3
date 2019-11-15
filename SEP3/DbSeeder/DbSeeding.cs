using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbContexts;
using SEP3.DbModel;
using SEP3.Model;

namespace SEP3.DbSeeder
{
    public class DbSeeding
    {
        public static void init(UserContext context)
        {
            //context.Database.EnsureCreated();

            //List<string> techs = new List<string>();
            //techs.Add("Java");
            //techs.Add("C#");
            //techs.Add("C++");
            //techs.Add("Web Design");
            //techs.Add("Mobile apps");
            //ITProviderCredentials user = new ITProviderCredentials("147258", new ITProvider("ralu79", "Raluca-Elena Petrovici", "Find a flaw. I dare you.", 5, 10, techs, "individual",
            //    new ContactInfo("Kollegievaenget 5", "12345678", "279998@via.dk")));
            //techs.RemoveAt(4);
            //ITProviderCredentials user2 = new ITProviderCredentials("258147", new ITProvider("leksi12", "Aleksandra Angelova Aleksandrova", "Everything is better with Christmas decorations!!",
            //    5, 10, techs, "individual", new ContactInfo("Mollersgade 12", "12345678", "280015@via.dk")));
            //ITProviderCredentials user3 = new ITProviderCredentials("987654", new ITProvider("karla7", "Karla Jajic", "Got my facts on point.",
            //    5, 10, techs, "individual", new ContactInfo("Amaliegade 8", "12345678", "280066@via.dk")));
            //ITProviderCredentials user4 = new ITProviderCredentials("321654", new ITProvider("lenaB", "Lena Bojanowska", "A little party never killed anyone.",
            //    5, 10, techs, "individual", new ContactInfo("Hybenvej 10", "12345678", "280069@via.dk")));

            ////DbITProvider dbProvider = context.ITProviders.Find(user.Provider.Username);
            ////context.ITProviders.Remove(dbProvider);
            ////DbITProvider dbProvider4 = context.ITProviders.Find(user4.Provider.Username);
            ////context.ITProviders.Remove(dbProvider4);
            ////DbITProvider dbProvider2 = context.ITProviders.Find(user2.Provider.Username);
            ////context.ITProviders.Remove(dbProvider2);
            ////DbITProvider dbProvider3 = context.ITProviders.Find(user3.Provider.Username);
            ////context.ITProviders.Remove(dbProvider3);
            //context.SaveChanges();

            //DbITProviderCredentials cr = new DbITProviderCredentials();
            //DbITProviderCredentials cr2 = new DbITProviderCredentials();
            //DbITProviderCredentials cr3 = new DbITProviderCredentials();
            //DbITProviderCredentials cr4 = new DbITProviderCredentials();
            //cr.toDbITProviderCredentials(user);
            //cr2.toDbITProviderCredentials(user2);
            //cr3.toDbITProviderCredentials(user3);
            //cr4.toDbITProviderCredentials(user4);

            //context.ITProviderCredentials.Add(cr);
            //context.ITProviderCredentials.Add(cr2);
            //context.ITProviderCredentials.Add(cr3);
            //context.ITProviderCredentials.Add(cr4);
            //context.SaveChanges();

            //DbITProvider p = new DbITProvider();
            //DbITProvider p2 = new DbITProvider();
            //DbITProvider p3 = new DbITProvider();
            //DbITProvider p4 = new DbITProvider();
            //p.toDbITProvider(user.Provider);
            //p2.toDbITProvider(user2.Provider);
            //p3.toDbITProvider(user3.Provider);
            //p4.toDbITProvider(user4.Provider);

            //context.ITProviders.Add(p);
            //context.ITProviders.Add(p2);
            //context.ITProviders.Add(p3);
            //context.ITProviders.Add(p4);
            //context.SaveChanges();

            //DbContactInfo ci = new DbContactInfo();
            //DbContactInfo ci2 = new DbContactInfo();
            //DbContactInfo ci3 = new DbContactInfo();
            //DbContactInfo ci4 = new DbContactInfo();
            //ci.toDbContactInfo(user.Provider.ContactInfo, user.Provider.Username);
            //ci2.toDbContactInfo(user2.Provider.ContactInfo, user2.Provider.Username);
            //ci3.toDbContactInfo(user3.Provider.ContactInfo, user3.Provider.Username);
            //ci4.toDbContactInfo(user4.Provider.ContactInfo, user4.Provider.Username);

            //context.contactInfo.Add(ci);
            //context.contactInfo.Add(ci2);
            //context.contactInfo.Add(ci3);
            //context.contactInfo.Add(ci4);
            //context.SaveChanges();

            //foreach (string s in (user.Provider).Technologies)
            //{
            //    DbTechnologies t = new DbTechnologies();
            //    t.toDbTechnology(user.Provider.Username, s);
            //    context.technologies.Add(t);
            //    context.SaveChanges();
            //}

            //foreach (string s in (user2.Provider).Technologies)
            //{
            //    DbTechnologies t = new DbTechnologies();
            //    t.toDbTechnology(user2.Provider.Username, s);
            //    context.technologies.Add(t);
            //    context.SaveChanges();
            //}

            //foreach (string s in (user3.Provider).Technologies)
            //{
            //    DbTechnologies t = new DbTechnologies();
            //    t.toDbTechnology(user3.Provider.Username, s);
            //    context.technologies.Add(t);
            //    context.SaveChanges();
            //}

            //foreach (string s in (user4.Provider).Technologies)
            //{
            //    DbTechnologies t = new DbTechnologies();
            //    t.toDbTechnology(user4.Provider.Username, s);
            //    context.technologies.Add(t);
            //    context.SaveChanges();
            //}

            //CustomerCredentials c1 = new CustomerCredentials("kiril", new Customer("kiril21", "Kiril Iliev", "Rakiaaa", new ContactInfo("Amaliegade 20", "74684166", "kiril@lala.com")));
            //CustomerCredentials c2 = new CustomerCredentials("zoly", new Customer("zolyphoto", "Zoltan Vegh", "English motherfucker, do you speak it?", new ContactInfo("Kollegievaenget 2", "77788899", "zolly@lala.com")));
            //CustomerCredentials c3 = new CustomerCredentials("harry", new Customer("justHarry", "Just Harry", "I like tea", new ContactInfo("Chr M Ostergaards Vej 5", "75723641", "harryl@lala.com")));
            //CustomerCredentials c4 = new CustomerCredentials("dovydas", new Customer("dovydass", "Dovydas", "Present", new ContactInfo("Kollegievaenget 10", "94758933", "dovy@lala.com")));

            //List<CustomerCredentials> list = new List<CustomerCredentials>();
            //list.Add(c1);
            //list.Add(c2);
            //list.Add(c3);
            //list.Add(c4);

            //foreach(CustomerCredentials c in list)
            //{
            //    DbCustomerCredentials credentials = new DbCustomerCredentials();
            //    credentials.toDbCustomerCredentials(c);

            //    DbCustomer customer = new DbCustomer();
            //    customer.toDbCustomer(c.Customer);

            //    DbContactInfo cinfo = new DbContactInfo();
            //    cinfo.toDbContactInfo(c.Customer.ContactInfo, c.Customer.Username);

            //    context.customerCredentials.Add(credentials);
            //    context.customers.Add(customer);
            //    context.contactInfo.Add(ci);
            //}
            //context.SaveChanges();
        }
    }
}
