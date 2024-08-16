using WebApplication7.Data;
using WebApplication7.Services;
using Microsoft.EntityFrameworkCore; // Add this namespace for EF Core
using static WebApplication7.Data.Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
<<<<<<< HEAD
    options.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;"));
//options.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true"));
=======
//    options.UseSqlServer("Server=.;Database=online_bus;User Id=sa;password=aptech; TrustServerCertificate=True;"));
options.UseSqlServer("Server=DESKTOP-KL71KR7\\SQLEXPRESS;Database= online_bus;Integrated Security=true"));
>>>>>>> 3a1449702830886577897258edea57e5a825f3ca




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=AdminIndex}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employe}/{action=EmployeIndex}/{id?}");

app.Run();
