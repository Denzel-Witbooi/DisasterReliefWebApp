using Portal.Models;
using Portal.Models.Donation;
using System;
using System.Linq;

namespace Portal.Data
{
    static class DbInitializer
    {
        public static void Initialize(DisasterReliefContext context)
        {
            context.Database.EnsureCreated();

            // Look for any donations
            if (context.Monetaries.Any())
            {
                return; // DB has been seeded
            }

            #region Monetary Data
            var monetaries = new Monetary[]
            {
                new Monetary{ DonationDate=DateTime.Parse("2022-09-04"), DonationAmount = 350000, DonorName = "Carson"},
                new Monetary{ DonationDate=DateTime.Parse("2022-08-03"), DonationAmount = 450000, DonorName = "Meredith"},
                new Monetary{ DonationDate=DateTime.Parse("2022-07-02"), DonationAmount = 750000, DonorName = "Arturo"},
                new Monetary{ DonationDate=DateTime.Parse("2022-06-01"), DonationAmount = 550000, DonorName = "Alonso"},
                new Monetary{ DonationDate=DateTime.Parse("2022-05-02"), DonationAmount = 650000, DonorName = "Alexander"},
                new Monetary{ DonationDate=DateTime.Parse("2022-04-03"), DonationAmount = 150000, DonorName = "Norman"},
                new Monetary{ DonationDate=DateTime.Parse("2022-08-03"), DonationAmount = 8500, DonorName = ""}
            };

            foreach (Monetary monetary in monetaries)
            {
                context.Monetaries.Add(monetary);
            }

            context.SaveChanges();
            #endregion
            #region Category Data
            var categories = new Category[]
            {
                new Category{ Name = "Clothes"},
                new Category{ Name = "Non‐perishable foods"}
            };

            foreach (Category category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
            #endregion

            #region AidTypes
            var aidtypes = new AidType[]
            {
                new AidType{ Name = "Water Provision"},
                new AidType{ Name = "Clothing"},
                new AidType{ Name = "Food"}
            };

            foreach (AidType aidtype in aidtypes)
            {
                context.AidTypes.Add(aidtype);
            }

            context.SaveChanges();
            #endregion

            #region Disaster 
            var disasters = new Disaster[]
   {
                new Disaster{AidTypeID = 1, StartDate=DateTime.Parse("2022-01-01"), EndDate=DateTime.Parse("2022-01-12"),
                        Description="Explosion of buried nuclear waste from a plutonium-processing plant near Kyshtym",
                        Location=" Chelyabinsk, Russia, Soviet Union" },
                new Disaster{AidTypeID = 2, StartDate=DateTime.Parse("2022-10-01"), EndDate=DateTime.Parse("2022-10-10"),
                        Description="The capsizing of an Italian cruise ship on January 13, 2012, after it struck rocks off the coast of Giglio Island in the Tyrrhenian Sea.",
                        Location="Giglio Island, Italy, Mediterranean Sea Tyrrhenian Sea"}
   };

            foreach (Disaster disaster in disasters)
            {
                context.Disasters.Add(disaster);
            }

            context.SaveChanges();
            #endregion
            #region Goods
            var goods = new Good[]
            {
                new Good{CategoryID = 1, DisasterID = 2, DonationDate=DateTime.Parse("2022-06-10"), NumberOfItems = 8, Description="Old clothes sizes > 10", DonorName="Frank"},
                new Good{CategoryID = 1, DisasterID = 2,DonationDate=DateTime.Parse("2022-05-05"), NumberOfItems = 8, Description="Coffee", DonorName=""},
                new Good{CategoryID = 1, DisasterID = 1,DonationDate=DateTime.Parse("2022-01-08"), NumberOfItems = 8, Description="Old shoes sizes > 10", DonorName="Norman"},
                new Good{CategoryID = 2, DisasterID = 1,DonationDate=DateTime.Parse("2022-03-09"), NumberOfItems = 50, Description="Dry Soups", DonorName="Alonso"},
                new Good{CategoryID = 2, DisasterID = 1,DonationDate=DateTime.Parse("2022-02-02"), NumberOfItems = 8, Description="Old socks", DonorName="Carson"},
                new Good{CategoryID = 2, DisasterID = 1,DonationDate=DateTime.Parse("2022-10-10"), NumberOfItems = 30, Description="Canned Meats", DonorName=""},
                new Good{CategoryID = 1, DisasterID = 2,DonationDate=DateTime.Parse("2022-04-04"), NumberOfItems = 8, Description="Old clothes sizes > 10", DonorName="Meredith"}
            };

            foreach (Good good in goods)
            {
                context.Goods.Add(good);
            }

            context.SaveChanges();
            #endregion

        }
    }
}
