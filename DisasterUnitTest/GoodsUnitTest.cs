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
    public class GoodsUnitTest
    {
        // to have the same Configuration object as in Startup
        private IConfigurationRoot _configuration;

        // represents database's configuration
        private DbContextOptions<DisasterReliefContext> _options;

        public GoodsUnitTest()
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

                var goods = new Good()
                {
                    CategoryID = 1,
                    DisasterID = 1,
                    DonationDate = DateTime.Parse("2022-01-08"),
                    NumberOfItems = 8,
                    Description = "Old shoes sizes > 10",
                    DonorName = "Norman"
                };

                context.Goods.AddRange(goods);
                context.SaveChanges();
            }
        }
    }
}
