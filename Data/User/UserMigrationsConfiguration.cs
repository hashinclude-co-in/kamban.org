using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WebApplication1.Data
{
    public  class UserMigrationsConfiguration
        :DbMigrationsConfiguration<UserContext>
    {
        public UserMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserContext context)
        {
            base.Seed(context);
            if (context.Users.Count() == 0)
            {
                User user1 = new User
                {
                    Name = "Karthikeyan",
                    UserName="karthikeyan"
                };
                context.Users.Add(user1);

                User user2 = new User
                {
                    Name = "Surya Kumar",
                    UserName = "surya"
                };
                context.Users.Add(user2);

                User user3 = new User
                {
                    Name = "Anand",
                    UserName = "anand"
                };
                context.Users.Add(user3);

                User user4 = new User
                {
                    Name = "Anbu",
                    UserName = "anbu"
                };
                context.Users.Add(user4);
                
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}