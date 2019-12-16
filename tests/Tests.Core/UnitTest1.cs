using EFNewFeature.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace Tests.Core
{
    [TestClass]
    public class UnitTest1
    {
        private DbContextOptionsBuilder<CoffeeShopContext> _optionsBuilder = new DbContextOptionsBuilder<CoffeeShopContext>();

        [TestMethod]
        public async System.Threading.Tasks.Task HasNoSeedDataAsync()
        {
            _optionsBuilder.UseInMemoryDatabase("HasNoSeedData");
            using (var context = new CoffeeShopContext(_optionsBuilder.Options))
            {
                var list = await context.Locations.ToListAsync();
                Assert.IsTrue(list.Count == 0);
            }
        }

        [TestMethod]
        public void RetainChangesAsync()
        {
            _optionsBuilder.UseInMemoryDatabase("RetainChanges");

            using (var context = new CoffeeShopContext(_optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            using (var newContext = new CoffeeShopContext(_optionsBuilder.Options))
            {
                var list = newContext.Locations.ToList();
                Assert.AreNotEqual(0, list.Count);
            }
        }
    }
}
