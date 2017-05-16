using Delete.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WebApplication1.Data
{
    public class TrustMigrationsConfiguration
        : DbMigrationsConfiguration<TrustContext>
    {
        public TrustMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrustContext context)
        {
            base.Seed(context);
            if (context.Trusts.Count() == 0)
            {
                Trust _trust1 = new Trust
                {
                    Name = "Idaya Vasal",
                    UserName = "IdayaVasal",
                    Address = "Villivakkam",
                    Location = "Chennai",
                    HomeType = TrustType.ChildHome,
                    Events = new List<Event>()
                    {
                        new Event()
                        {
                            Title="Manidham Meeting"
                        },
                        new Event()
                        {
                            Title="Core Meeting"
                        },
                        new Event()
                        {
                            Title="Casual Meeting"
                        },
                    },
                    Reviews=new List<Review>()
                    {
                        new Review()
                        {
                            Title="Review Title 1",
                            Description="Description for review title 1."
                        },
                        new Review()
                        {
                            Title="Review Title 2",
                            Description="Description for review title 2."
                        }
                    },

                };
                context.Trusts.Add(_trust1);

                Trust _trust2 = new Trust
                {
                    Name = "Thozhan",
                    UserName = "Thozhan",
                    Address = "Velachery",
                    Location = "Chennai",
                    HomeType = TrustType.OldAgeHome
                };
               
                context.Trusts.Add(_trust2);

                Trust _trust3 = new Trust
                {
                    Name = "Udavum Karangal",
                    UserName = "UdavumKarangal",
                    Address = "Velachery",
                    Location = "Chennai",
                    HomeType = TrustType.OldAgeHome
                };
                context.Trusts.Add(_trust3);

                Trust _trust4 = new Trust
                {
                    Name = "Kakkum Karangal",
                    UserName = "KakkumKarangal",
                    Address = "Karunai Nagar",
                    Location = "Madurai"
                };
                context.Trusts.Add(_trust4);


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