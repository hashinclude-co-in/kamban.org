using Kamban.API.Contacts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kamban.API.Trust
{
    public class TrustContext : DbContext
    {
        public TrustContext() :
#if DEBUG
            base("DefaultConnection")
#else
            base("AzureDBConnection")
#endif
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TrustContext, TrustMigrationsConfiguration>()
                );
        }
        public DbSet<Trust> Trusts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}