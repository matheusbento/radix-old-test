using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadixTest.Domain.Entities;
using System.Reflection;

namespace RadixTest.Infra.Context
{
    public class RadixContext: DbContext
    {
        private readonly string _connString = "Server=radix-mssql;Database=Radix;MultipleActiveResultSets=true;User Id=sa;Password=YourStrong!Passw0rd;";

        public DbSet<Event> Event { get; set; }
        
        public RadixContext(DbContextOptions<RadixContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connString,
                sqlOptions => sqlOptions.EnableRetryOnFailure(3));
        }
    }
}
