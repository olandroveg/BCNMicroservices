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
        public virtual DbSet<BcNodeContent> BcNodeContents { get; set; }
        public virtual DbSet<TimeSchedule> TimeSchedules { get; set; }
        public virtual DbSet<RepeatSchedule> RepeatSchedules { get; set; }
        public virtual DbSet<InterfaceBcNode> InterfaceBcNode { get; set; }
        public virtual DbSet<Interfaces> Interfaces { get; set; }
        public virtual DbSet<InterfBcNodeCore> InterfBcNodeCores { get; set; }
        public virtual DbSet<InterfaceBcNodesCoreBcNode> InterfaceBcNodesCoreBcNodes { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<ContentServices> ContentServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BcNodeConfiguration());
            builder.ApplyConfiguration(new BcNodeContentConfiguration());
            builder.ApplyConfiguration(new ContentConfiguration());
            builder.ApplyConfiguration(new InterfacesConfiguration());
            builder.ApplyConfiguration(new ContentServicesConfiguration());
            builder.ApplyConfiguration(new InterfaceBcNodeConfiguration());
            builder.ApplyConfiguration(new InterfaceBcNodesCoreBcNodeConfiguration());
            builder.ApplyConfiguration(new InterfBcNodeCoreConfiguration());
            builder.ApplyConfiguration(new PlaceConfiguration());
            builder.ApplyConfiguration(new RepeatScheduleConfiguration());
            builder.ApplyConfiguration(new TimeScheduleConfiguration());
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
