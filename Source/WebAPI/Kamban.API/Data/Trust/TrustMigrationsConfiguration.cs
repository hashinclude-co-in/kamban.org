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
}