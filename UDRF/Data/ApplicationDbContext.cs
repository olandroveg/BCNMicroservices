using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UDRF.Models;

namespace UDRF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            try
            {
                Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public virtual DbSet<BcNode> BcNode { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<BcNodeContent> BcNodeContent { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DatabaseFacade GetDatabase()
        {
            return Database;
        }
        public class ApplicationDbContextFctory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                //string connectionString;
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    optionsBuilder.UseMySql("server = localhost; port = 3306; database = MicrosUDRF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));
                else
                    optionsBuilder.UseMySql("server = 192.168.0.18; port = 3306; database = MicrosUDRF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));

                return new ApplicationDbContext(optionsBuilder.Options);

            }
        }
    }
}
