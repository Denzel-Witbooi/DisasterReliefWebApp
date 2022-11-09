using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Data;
using Portal.Models;
using Portal.Models.Donation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTests
{
    [TestClass]
    public class CategoriesInitTests
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<DisasterReliefContext> _options;

        public CategoriesInitTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<DisasterReliefContext>()
                .UseSqlServer(_configuration.GetConnectionString("DRData"))
                .Options;
        }

        [TestMethod]
        public void InitializeDatabaseWithDataTest()
        {
            using (var context = new DisasterReliefContext(_options))
            {
                context.Database.EnsureCreated();

                var categories = new Category()
                {
                    Name = "Clothes"
                };

                var categories2 = new Category()
                {
                    Name = "Non‐perishable foods"
                };
                
                context.Categories.AddRange(categories, categories2);
                context.SaveChanges();
            }
        }
    }
}

