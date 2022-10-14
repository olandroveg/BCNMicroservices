using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UDRF.Data;
using UDRF.Utility;

var secretKey = StaticConfigurationManager.AppSetting["TokenSecret:Key"];
var secretIssuer = StaticConfigurationManager.AppSetting["TokenSecret:Issuer"];
var builder = WebApplication.CreateBuilder(args);
string connectionString;
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
else
    connectionString = builder.Configuration.GetConnectionString("ProductionConnection") ?? throw new InvalidOperationException("Connection string 'ProductionConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql("server = localhost; port = 3306; database = MicrosUDRF; user = root; password = Cardinals25", new MySqlServerVersion(new Version("8.0.30"))));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
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
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
    options.AddPolicy("BcNode", policy => policy.RequireClaim(ClaimTypes.Role, "bcNode", "Administrator"));
});
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

