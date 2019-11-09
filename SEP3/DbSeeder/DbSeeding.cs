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
            List<string> techs = new List<string>();
            techs.Add("Java");
            techs.Add("C#");
            techs.Add("C++");
            techs.Add("Web Design");
            techs.Add("Mobile apps");
            Credentials user = new Credentials("ralu79", "147258", new ITProvider("Raluca-Elena Petrovici", "Find a flaw. I dare you.", 5, 10, techs, "individual",
                new ContactInfo("Kollegievaenget 5", "12345678", "279998@via.dk")));
            techs.RemoveAt(4);
            Credentials user2 = new Credentials("leksi12", "258147", new ITProvider("Aleksandra Angelova Aleksandrova", "Everything is better with Christmas decorations!!",
                5, 10, techs, "individual", new ContactInfo("Mollersgade 12", "12345678", "280015@via.dk")));
            Credentials user3 = new Credentials("karla7", "987654", new ITProvider("Karla Jajic", "Got my facts on point.",
                5, 10, techs, "individual", new ContactInfo("Amaliegade 8", "12345678", "280066@via.dk")));
            Credentials user4 = new Credentials("lenaB", "321654", new ITProvider("Lena Bojanowska", "A little party never killed anyone.",
                5, 10, techs, "individual", new ContactInfo("Hybenvej 10", "12345678", "280069@via.dk")));

/*
            DbCredentials cr = new DbCredentials();
            DbCredentials cr2 = new DbCredentials();
            DbCredentials cr3 = new DbCredentials();
            DbCredentials cr4 = new DbCredentials();
            cr.toDbCredentials(user);
            cr2.toDbCredentials(user2);
            cr3.toDbCredentials(user3);
            cr4.toDbCredentials(user4);

            context.credentials.Add(cr);
            context.credentials.Add(cr2);
            context.credentials.Add(cr3);
            context.credentials.Add(cr4);
            context.SaveChanges();*/

            DbITProvider p = new DbITProvider();
            DbITProvider p2 = new DbITProvider();
            DbITProvider p3 = new DbITProvider();
            DbITProvider p4 = new DbITProvider();
            p.toDbITProvider((ITProvider)user.user, user.username);
            p2.toDbITProvider((ITProvider)user2.user, user2.username);
            p3.toDbITProvider((ITProvider)user3.user, user3.username);
            p4.toDbITProvider((ITProvider)user4.user, user4.username);

            context.ITProviders.Add(p);
            context.ITProviders.Add(p2);
            context.ITProviders.Add(p3);
            context.ITProviders.Add(p4);
            context.SaveChanges();

           /* DbContactInfo ci = new DbContactInfo();
            DbContactInfo ci2 = new DbContactInfo();
            DbContactInfo ci3 = new DbContactInfo();
            DbContactInfo ci4 = new DbContactInfo();
            ci.toDbContactInfo(user.user.getContactInfo(), user.username);
            ci2.toDbContactInfo(user2.user.getContactInfo(), user2.username);
            ci3.toDbContactInfo(user3.user.getContactInfo(), user3.username);
            ci4.toDbContactInfo(user4.user.getContactInfo(), user4.username);

            context.contactInfo.Add(ci);
            context.contactInfo.Add(ci2);
            context.contactInfo.Add(ci3);
            context.contactInfo.Add(ci4);
            context.SaveChanges();*/

           /* foreach (string s in ((ITProvider)user.user).technologies)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(user.username, s);
                context.technologies.Add(t);
                context.SaveChanges();
            }

            foreach (string s in ((ITProvider)user2.user).technologies)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(user2.username, s);
                context.technologies.Add(t);
                context.SaveChanges();
            }

            foreach (string s in ((ITProvider)user3.user).technologies)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(user3.username, s);
                context.technologies.Add(t);
                context.SaveChanges();
            }

            foreach (string s in ((ITProvider)user4.user).technologies)
            {
                DbTechnologies t = new DbTechnologies();
                t.toDbTechnology(user4.username, s);
                context.technologies.Add(t);
                context.SaveChanges();
            }*/
        }
    }
}
