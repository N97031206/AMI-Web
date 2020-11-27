using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models.Repository
{
    public class AMIDbFactory : IDesignTimeDbContextFactory<AMIDbContext>
    {
        public AMIDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AMIDbContext>();
            optionsBuilder.UseSqlite("Data Source=AMI.db");

            return new AMIDbContext(optionsBuilder.Options);
        }
    }
}
