using Microsoft.EntityFrameworkCore;
using SalesRecords.Domain.Models;

namespace SalesRecords.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the database connection here if not already configured
                optionsBuilder.UseSqlServer("Server=KRISTIYAN\\MSSQLSERVER03;Database=SalesRecords;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set table naming convention to lowercase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToLower());
            }
        }
    }
}
