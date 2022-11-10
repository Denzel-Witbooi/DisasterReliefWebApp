using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Data;
using Portal.Models.Donation;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterUnitTest
{
    [TestClass]
    public class MonetaryUnitTest
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<DisasterReliefContext> _options;

        public MonetaryUnitTest()
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

                var monetaries = new Monetary()
                {
                    DonationDate = DateTime.Parse("2022-09-04"),
                    DonationAmount = 350000,
                    DonorName = "Nasrin2"
                };

                var monetaries2 = new Monetary()
                {
                    DonationDate = DateTime.Parse("2022-08-03"),
                    DonationAmount = 450000,
                    DonorName = "Stacey2"
                };

                context.Monetaries.AddRange(monetaries, monetaries2);
                context.SaveChanges();
            }
        }
    }
}
