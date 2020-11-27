using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System;
using System.Reflection;

namespace Models.Repository
{
    public class AMIDbContext : DbContext 
    {
        private static bool _created = false;

        public AMIDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
  
        public AMIDbContext(DbContextOptions<AMIDbContext> options) : base(options) {}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AMIDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AMI.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        public  DbSet<Account> Accounts { get; set; }
        public  DbSet<Role> Roles { get; set; }

    }
}
