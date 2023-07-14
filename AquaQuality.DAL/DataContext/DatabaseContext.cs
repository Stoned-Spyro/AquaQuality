using System;
using Microsoft.EntityFrameworkCore;
using AquaQuality.DAL.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AquaQuality.DAL.DataContext
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()).Where(p => p.ClrType == typeof(string)))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<WaterStorage> WaterStorages { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
     }
}
