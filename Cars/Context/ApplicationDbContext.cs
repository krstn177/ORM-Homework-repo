using Cars.Models;
using Cars.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarEngine> CarEngines { get; set; }
        public DbSet<ModelEngine> ModelEngines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=KRISTIYAN\\MSSQLSERVER03;Database=CarsORM;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CarEngine>().HasKey(ce => new { ce.CarId, ce.EngineId });
            modelBuilder.Entity<ModelEngine>().HasKey(me => new { me.ModelId, me.EngineId });

            Seeder.ExampleSeed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
