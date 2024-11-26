using EFCore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// read connection string from appsettings.json
var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
// pass connection string to ApplicationDbContext class
builder.Services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(configuration));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
