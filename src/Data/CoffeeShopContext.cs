using EFNewFeature.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFNewFeature.Data
{
    public class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {

        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<BrewerType> BrewerTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=CoffeeShops.db");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQlLocalDb;Initial Catalog=CoffeShop;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var location = new
            {
                LocationId = new Guid("09236e34-5f9e-437c-a04a-a9155659c084"),
                StreetAddress = "999 Main Street",
                OpenTime = "6AM",
                CloseTime = "4PM"
            };
            modelBuilder.Entity<Location>().HasData(location);
            modelBuilder.Entity<BrewerType>().OwnsOne(b => b.Recipe).HasData(new
            {
                BrewerTypeId = 1,
                WaterTemperature = 60,
                BrewMinutes = 3,
                Description = "so good",
                GrindOunces = 5,
                GrindSize = 2,
                WaterOunces = 1
            });

            //modelBuilder.Entity<Location>().HasData(new
            //{
            //    LocationId = 2,
            //    StreetAddress = "2 Main Street",
            //    OpenTime = "2AM",
            //    CloseTime = "4PM"
            //});
            //modelBuilder.Entity<Location>().HasData(new
            //{
            //    LocationId = 3,
            //    StreetAddress = "3 Main Street",
            //    OpenTime = "3AM",
            //    CloseTime = "4PM"
            //});


            modelBuilder.Entity<BrewerType>().HasData(
                new BrewerType { BrewerTypeId = 1, Description = "Glass Hourglass Drip" },
                new BrewerType { BrewerTypeId = 2, Description = "Hand Press" },
                new BrewerType { BrewerTypeId = 3, Description = "Cold Brew" }
                );

            modelBuilder.Entity<Unit>().HasData(
                new { UnitId = 1, Acquired = new DateTime(2018, 6, 1), LocationId = location.LocationId, TypeBrewerTypeId = 1 },
                new { UnitId = 2, Acquired = new DateTime(2018, 06, 2), BrewerTypeId = 2 }
                );

        }
    }
}
