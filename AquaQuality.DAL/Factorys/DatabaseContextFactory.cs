using AquaQuality.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace AquaQuality.DAL.Factorys
{
    /*public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public static string connectionString = "";
        public DatabaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return (DatabaseContext)Activator.CreateInstance(typeof(DatabaseContext), new object[] {optionsBuilder.Options});
        }
    }*/
}
