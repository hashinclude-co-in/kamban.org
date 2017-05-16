using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<UserContext, UserMigrationsConfiguration>()
                );
        }

        public DbSet<User> Users { get; set; }
    }
}
