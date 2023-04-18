using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCLibrary.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MobileContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MobileContext") ?? throw new InvalidOperationException("Connection string 'MobileContext' not found.")));
builder.Services.AddDbContext<MVCLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCLibraryContext") ?? throw new InvalidOperationException("Connection string 'MVCLibraryContext' not found.")));
builder.Services.AddDbContext<MVCLibraryTrail13042023>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCLibraryTrail13042023") ?? throw new InvalidOperationException("Connection string 'MVCLibraryTrail13042023' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
