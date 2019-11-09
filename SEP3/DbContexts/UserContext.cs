using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEP3.DbModel;

namespace SEP3.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<DbTechnologies> technologies { get; set; }
        public DbSet<DbContactInfo> contactInfo { get; set; }
        public DbSet<DbCredentials> credentials { get; set; }
        public DbSet<DbITProvider> ITProviders { get; set; }
        public DbSet<DbCustomer> customers { get; set; }
    }
}
