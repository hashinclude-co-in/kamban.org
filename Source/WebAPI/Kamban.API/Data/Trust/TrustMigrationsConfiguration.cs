using Kamban.API.Models;
using System.Data.Entity.Migrations;

namespace Kamban.API.Trust
{
    public class TrustMigrationsConfiguration
        :DbMigrationsConfiguration<TrustContext>
    {
        public TrustMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(TrustContext context)
        {
            base.Seed(context);
        }
    }

    public class ApplicationDbContextMigrationsConfiguration
        : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbContextMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }
    }
}