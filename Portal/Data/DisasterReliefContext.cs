using Microsoft.EntityFrameworkCore;
using Portal.Models;
using Portal.Models.Donation;

namespace Portal.Data
{
    public class DisasterReliefContext : DbContext
    {
        public DisasterReliefContext(DbContextOptions<DisasterReliefContext> options) : base(options)
        {
        }

        public DbSet<Monetary> Monetaries { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AidType> AidTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monetary>().ToTable("Monetary");
            modelBuilder.Entity<Good>().ToTable("Good");
            modelBuilder.Entity<Disaster>().ToTable("Disaster");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<AidType>().ToTable("AidType");
        }
    }
}
