using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AANF.Areas.Identity.Data;
using AANF.Data;

var builder = WebApplication.CreateBuilder(args);
string connectionString;
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
else
    connectionString = builder.Configuration.GetConnectionString("ProductionConnection") ?? throw new InvalidOperationException("Connection string 'ProductionConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySql(ServerVersion.AutoDetect(connectionString)));


//builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(ServerVersion.AutoDetect(connectionString)));

//tamien puede usarse AddDbContextPool.
//builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql("server = localhost; port = 3306; database = core; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30"))));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server = localhost; port = 3306; database = MicrosAANF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30"))));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

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
