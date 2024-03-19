using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
//using UDRF.Data;
using OF.Utility;
using OF.Data;
using Quartz;
using OF.Services.JobServices;



var secretKey = StaticConfigurationManager.AppSetting["TokenSecret:Key"];
var secretIssuer = StaticConfigurationManager.AppSetting["TokenSecret:Issuer"];
var _quartzPeriod = StaticConfigurationManager.AppSetting["AdvertStats:jobPeriod"];

//var secretKey = "we_are_champions";
//var secretIssuer = "bilbao_BCN";
//var _quartzPeriod = "0/48 * * * * ?"; // currently 48 secs. "0 0/1 * ? * * *" for 1 sec, "15 0/1 * ? * * *" for 1 min 15sec

var builder = WebApplication.CreateBuilder(args);

string connectionString;

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
else
    connectionString = builder.Configuration.GetConnectionString("ProductionConnection") ?? throw new InvalidOperationException("Connection string 'ProductionConnection' not found.");


// Add services to the container.
builder.Services.UseInjection();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server = localhost; port = 3306; database = OF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30"))));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
            .AddCookie(jwt => jwt.SlidingExpiration = true)
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(secretKey);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = secretIssuer,
                    ValidAudience = secretIssuer,
                    ValidateAudience = true,
                    ValidateLifetime = true

                };
            });

builder.Services.AddQuartz(q =>
{
    // Use a Scoped container to create jobs. I'll touch on this later
    //q.UseMicrosoftDependencyInjectionScopedJobFactory(); deprecated in this quartz version...
    q.UseMicrosoftDependencyInjectionJobFactory();
    // Create a "key" for the job
    var jobKey = new JobKey("MetricJob1");

    // Register the job with the DI container
    q.AddJob<AdvertisMetricJob>(opts => opts.WithIdentity(jobKey));

    // Create a trigger for the job
    q.AddTrigger(opts => opts
        .ForJob(jobKey) // link to the HelloWorldJob
        .WithIdentity("MetricJob-trigger") // give the trigger a unique name
        .WithCronSchedule(_quartzPeriod)); // run every 48 seconds See https://www.freeformatter.com/cron-expression-generator-quartz.html
                                           //.WithCronSchedule("0 0/1 * ? * * *")); // run every 1 minute
                                           //.WithCronSchedule("15 0/1 * ? * * *")); // run every 1 minute and 15 secs // the page above has the minutes in bad format. Take int into account

});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Backend}/{action=Index}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();

