using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Data;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTests
{
    [TestClass]
    public class DisastersInitTests
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<DisasterReliefContext> _options;

        public DisastersInitTests()
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

                var disaster = new Disaster()
                {
                    AidTypeID = 1,
                    StartDate = DateTime.Parse("2022-11-09"),
                    EndDate = DateTime.Parse("2022-11-10"),
                    Description = "Tsunami",
                    Location = "PE"
                };

                context.Disasters.AddRange(disaster);
                context.SaveChanges();
            }
        }
    }
}
