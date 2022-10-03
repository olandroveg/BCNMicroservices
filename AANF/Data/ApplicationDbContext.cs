using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AANF.Data
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

        public DatabaseFacade GetDatabase()
        {
            return Database;
        }
        public class ApplicationDbContextFctory: IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            //protected readonly IConfiguration Configuration;
            //public ApplicationDbContextFctory(IConfiguration configuration)
            //{
            //    Configuration = configuration;
            //}
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                //string connectionString;
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    optionsBuilder.UseMySql("server = localhost; port = 3306; database = MicrosAANF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));
                else
                    optionsBuilder.UseMySql("server = 192.168.0.18; port = 3306; database = MicrosAANF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));

                //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                //    connectionString = Configuration.GetConnectionString("DefaultConnection");
                //else
                //    connectionString = Configuration.GetConnectionString("ProductionConnection");
                //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                return new ApplicationDbContext(optionsBuilder.Options);

            }
        }
    }
}

