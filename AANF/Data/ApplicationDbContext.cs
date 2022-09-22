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
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                //optionsBuilder.UseSqlServer("Server=localhost;Database=scrapping; User Id=sa;Password=Cardinals25;MultipleActiveResultSets=true");
                //string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

                

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                    optionsBuilder.UseMySql("server = localhost; port = 3306; database = core; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));
                else
                    optionsBuilder.UseMySql("server = 192.168.0.18; port = 3306; database = core; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30")));
                    
                 return new ApplicationDbContext(optionsBuilder.Options);

            }
        }
    }
}

