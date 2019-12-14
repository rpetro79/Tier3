using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;
using SEP3.DbContexts;
using SEP3.DbSeeder;
using SEP3.DbModel;
using SEP3.DbManagement;
using SEP3.Model;

namespace SEP3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<UserContext>();
                   // DbSeeding.init(context);
                    //List<DbProject> dbProjects = context.Projects.ToList<DbProject>();
                    //Customer c;
                    //DbCustomer customer;
                    //ContactInfo ci;
                    //DbContactInfo dbci;
                    //ProjectManagement pm;
                    //DbProjectManagement dbpm = new DbProjectManagement();
                    //foreach (DbProject p in dbProjects)
                    //{
                    //    customer = context.customers.Find(p.customerUsername);
                    //    dbci = context.contactInfo.Find(p.customerUsername);
                    //    ci = dbci.toContactInfo();
                    //    c = customer.toCustomer(ci);
                    //    pm = new ProjectManagement(p.toProject(c));
                    //    dbpm.toDbProjectManagement(pm);
                    //    context.ProjectManagement.Add(dbpm);
                    //    context.SaveChanges();
                    //}
                    //ITProvider petw = new ITProvider("ralu79", "f", "f", new List<string>(), "f", new ContactInfo());
                    //ITProvider p2 = new ITProvider("leksi12", "f", "f", new List<string>(), "f", new ContactInfo());
                    //Application app = new Application("kiril211", petw, "can you please choose me?", DateTime.Now);
                    //Application app2 = new Application("kiril211", p2, "can you please choose me?", DateTime.Now);
                    //ApplicationsDb.postApplication(app, context);
                    //ApplicationsDb.postApplication(app2, context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, ex.Message);

                }
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<UserContext>();
                    DbSeeding.init(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, ex.Message);

                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
