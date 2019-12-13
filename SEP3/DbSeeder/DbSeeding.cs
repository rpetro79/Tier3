using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3.DbContexts;
using SEP3.DbModel;
using SEP3.Model;
using SEP3.DbManagement;

namespace SEP3.DbSeeder
{
    public class DbSeeding
    {
        public static void init(UserContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();

            if(!context.TechnologyList.Any())
            {
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "C#" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "C" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "C++" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "Java" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "JavaScript" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "Python" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "Php" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "FrontEnd" });
                context.TechnologyList.Add(new DbTechnologyList() { Technology = "Assembly" });
            }
         
            
            if (!context.CategoryList.Any())
            {
                context.CategoryList.Add(new DbCategoryList() {Category = "Web Application"});
                context.CategoryList.Add(new DbCategoryList() { Category = "Website" });
                context.CategoryList.Add(new DbCategoryList() { Category = "System" });
                context.CategoryList.Add(new DbCategoryList() { Category = "Application" });
                context.CategoryList.Add(new DbCategoryList() { Category = "Mobile application" });
            }

            List<string> techs = new List<string>() { "Java", "C#", "C++", "Php"};

            ITProviderCredentials user = new ITProviderCredentials("147258", new ITProvider("ralu79", "Raluca-Elena Petrovici", "Find a flaw. I dare you.", 5.2, 10, techs, "individual", new ContactInfo("Kollegievaenget 5", "12345678", "279998@via.dk")));
            ITProviderCredentials user2 = new ITProviderCredentials("258147", new ITProvider("leksi3", "Aleksandra Angelova Aleksandrova", "Everything is better with Christmas decorations!!",5.1, 10, techs, "individual", new ContactInfo("Mollersgade 12", "12345678", "280015@via.dk")));
            ITProviderCredentials user3 = new ITProviderCredentials("987654", new ITProvider("karla7", "Karla Jajic", "Got my facts on point.",5.2, 10, techs, "individual", new ContactInfo("Amaliegade 8", "12345678", "280066@via.dk")));
            ITProviderCredentials user4 = new ITProviderCredentials("321654", new ITProvider("lenaB", "Lena Bojanowska", "A little party never killed anyone.",5.3, 10, techs, "individual", new ContactInfo("Hybenvej 10", "12345678", "280069@via.dk")));

            CustomerCredentials cust = new CustomerCredentials("123", new Customer()
            {
                Username = "leksi37", Name = "Aleksandra Aleksandrova", Description = "Merry Chsristmas",
                ContactInfo = new ContactInfo() { Address = "North Pole", Email = "leksi@gmail.com", PhoneNo = "+12 77 14 15 17"}
            });
            CustomerCredentials cust2 = new CustomerCredentials("321", new Customer()
            {
                Username = "ralu12", Name = "Raluca Petrovici", Description = "Likes serious programming",
                ContactInfo = new ContactInfo() { Address = "Romania", Email = "raluca@gmail.com", PhoneNo = "+12 86 39 40 24" }
            });
            CustomerCredentials cust3 = new CustomerCredentials("456", new Customer() {
                Username = "lena13", Name = "Lena Bojanowska", Description = "Design person",
                ContactInfo = new ContactInfo() { Address = "Poland", Email = "lena@gmail.com", PhoneNo = "+12 38 50 22" }
            });
            CustomerCredentials cust4 = new CustomerCredentials("654", new Customer()
            {
                Username = "karla7", Name = "Karla Kinder", Description = "Likes to be called c# master/wikipedia",
                ContactInfo = new ContactInfo() { Address = "Croatia", Email = "daisy@gmail.com", PhoneNo = "+12 14 27 38" }
            });

            if (!context.credentials.Any())
            {
            context.credentials.Add(new DbCredentials { Username = user.Provider.Username, Password = user.Password });
            context.credentials.Add(new DbCredentials { Username = user2.Provider.Username, Password = user2.Password });
            context.credentials.Add(new DbCredentials { Username = user3.Provider.Username, Password = user3.Password });
            context.credentials.Add(new DbCredentials { Username = user4.Provider.Username, Password = user4.Password });
            context.SaveChanges();    
            }

            if (!context.customers.Any())
            {
                context.customers.Add(new DbCustomer() { Username = cust.Customer.Username, Description = cust.Customer.Description, Name = cust.Customer.Name });
                context.customers.Add(new DbCustomer() { Username = cust2.Customer.Username, Description = cust2.Customer.Description, Name = cust2.Customer.Name });
                context.customers.Add(new DbCustomer() { Username = cust3.Customer.Username, Description = cust3.Customer.Description, Name = cust3.Customer.Name });
                context.customers.Add(new DbCustomer() { Username = cust4.Customer.Username, Description = cust4.Customer.Description, Name = cust4.Customer.Name });
            }

            if (!context.ITProviders.Any())
            {
                DbITProvider p = new DbITProvider();
                DbITProvider p2 = new DbITProvider();
                DbITProvider p3 = new DbITProvider();
                DbITProvider p4 = new DbITProvider();
            
                p.toDbITProvider(user.Provider);
                p2.toDbITProvider(user2.Provider);
                p3.toDbITProvider(user3.Provider);
                p4.toDbITProvider(user4.Provider);

                context.ITProviders.Add(p);
                context.ITProviders.Add(p2);
                context.ITProviders.Add(p3);
                context.ITProviders.Add(p4);
                context.SaveChanges();
            }

            if (!context.contactInfo.Any())
            {
                context.contactInfo.Add(new DbContactInfo() {Username = user.Provider.Username, Address = user.Provider.ContactInfo.Address, Email =  user.Provider.ContactInfo.Email, PhoneNo = user.Provider.ContactInfo.PhoneNo});
                context.contactInfo.Add(new DbContactInfo() { Username = user2.Provider.Username, Address = user2.Provider.ContactInfo.Address, Email = user2.Provider.ContactInfo.Email, PhoneNo = user2.Provider.ContactInfo.PhoneNo });
                context.contactInfo.Add(new DbContactInfo() { Username = user3.Provider.Username, Address = user3.Provider.ContactInfo.Address, Email = user3.Provider.ContactInfo.Email, PhoneNo = user3.Provider.ContactInfo.PhoneNo });
                context.contactInfo.Add(new DbContactInfo() { Username = user4.Provider.Username, Address = user4.Provider.ContactInfo.Address, Email = user4.Provider.ContactInfo.Email, PhoneNo = user4.Provider.ContactInfo.PhoneNo });
                context.SaveChanges();
            }

            if (!context.technologies.Any())
            {
                foreach (string s in (user.Provider).Technologies)
                {
                    DbTechnologies t = new DbTechnologies();
                    t.toDbTechnology(user.Provider.Username, s);
                    context.technologies.Add(t);
                    context.SaveChanges();
                }
                
                foreach (string s in (user2.Provider).Technologies)
                {
                    DbTechnologies t = new DbTechnologies();
                    t.toDbTechnology(user2.Provider.Username, s);
                    context.technologies.Add(t);
                    context.SaveChanges();
                }
                foreach (string s in (user3.Provider).Technologies)
                {
                    DbTechnologies t = new DbTechnologies();
                    t.toDbTechnology(user3.Provider.Username, s);
                    context.technologies.Add(t);
                    context.SaveChanges();
                }
                foreach (string s in (user4.Provider).Technologies)
                {
                    DbTechnologies t = new DbTechnologies();
                    t.toDbTechnology(user4.Provider.Username, s);
                    context.technologies.Add(t);
                    context.SaveChanges();
                }
            }

            if (!context.Projects.Any())
            {
                context.Projects.Add(new DbProject() { ProjectId = "leksi371", customerUsername = "leksi37", ProjectName = "Christmas application", Category = "Web Application", Description = "I am looking for IT provider who can develop a countdown application for me."});
                context.Projects.Add(new DbProject() { ProjectId = "ralu121", customerUsername = "ralu12", ProjectName = "Politics website", Category = "Website", Description = "I need a person who can help me with a political website"});
                context.Projects.Add(new DbProject() { ProjectId = "lena131", customerUsername = "lena13", ProjectName = "Design system", Category = "System", Description = "I need a person who can help me with the design of a system" });
                context.Projects.Add(new DbProject() { ProjectId = "karla71", customerUsername = "karla7", ProjectName = "Database system", Category = "System", Description = "I need a person who can create database for a system" });
            }

            if (!context.ProjectManagement.Any())
            {
                context.ProjectManagement.Add(new DbProjectManagement() { ProjectId = "leksi371", Closed = false });
                context.ProjectManagement.Add(new DbProjectManagement() { ProjectId = "ralu121", Closed = false });
                context.ProjectManagement.Add(new DbProjectManagement() { ProjectId = "lena131", Closed = false });
                context.ProjectManagement.Add(new DbProjectManagement() { ProjectId = "karla71", Closed = false });
            }

            if (!context.Applications.Any())
            {
                context.Applications.Add(new DbApplication() { Id = 1, ProposalId = "leski371", Answer = "NOT_ANSWERED", ApplicationText = "I would like to apply", ITproviderUsername = "karla7", Date = DateTime.Now.ToString() });
                context.Applications.Add(new DbApplication() { Id = 2, ProposalId = "leski371", Answer = "NOT_ANSWERED", ApplicationText = "I would like to apply", ITproviderUsername = "ralu79", Date = DateTime.Now.ToString() });
                context.Applications.Add(new DbApplication() { Id = 3, ProposalId = "lena131", Answer = "NOT_ANSWERED", ApplicationText = "I would like to apply", ITproviderUsername = "karla7", Date = DateTime.Now.ToString() });
                context.Applications.Add(new DbApplication() { Id = 4, ProposalId = "lena131", Answer = "NOT_ANSWERED", ApplicationText = "I would like to apply", ITproviderUsername = "ralu79", Date = DateTime.Now.ToString() });
            }

            if (!context.Collaborations.Any()) 
            {
                context.Collaborations.Add(new DbCollaboration() { CollaborationId = "karla71", CollaborationName = "DataBase person needed", Category = "System", Description = "Need help to create database on a project", ITProviderName = "karla7" });
                context.Collaborations.Add(new DbCollaboration() { CollaborationId = "ralu791", CollaborationName = "Design person needed", Category = "Website", Description = "Need help to create design for a website on a project", ITProviderName = "ralu79" });
            }

            context.SaveChanges();
        }
    }
}