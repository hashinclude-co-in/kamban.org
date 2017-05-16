using Delete.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class TrustContext : DbContext
    {
        public TrustContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TrustContext, TrustMigrationsConfiguration>()
                );
        }

        public DbSet<Trust> Trusts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TrustUserRelationship> TrustUserRelationship { get; set; }
    }
}
