using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.Mapping;
using Privacy_Web_App.DataContext;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.FileProviders;
using Privacy_Web_App.Models;
using Privacy_Web_App.Services;
using System.Security.Claims;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Connect To MySQL
var connectionString = builder.Configuration.GetConnectionString("PrivDbCon");
builder.Services.AddDbContext<dbContext>(options =>
options.UseMySql(connectionString, ServerVersion.Parse("10.11.7-mariadb"))
);


#endregion
builder.Services.AddDbContext<IdDbContext>(options =>

{ options.UseMySql(connectionString, ServerVersion.Parse("10.11.7-mariadb")); });
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{   
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<IdDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc().AddControllersAsServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();




app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
