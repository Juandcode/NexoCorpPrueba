using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
            builder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Nexocorp;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True");

            return new ApplicationDbContext(builder.Options);
        }
    }
}