using Microsoft.EntityFrameworkCore;
using PieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Registering our mock repository services with the application's DI container
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

//Enabling MVC in the application
builder.Services.AddControllersWithViews(); 

//Adding entity framework services using the AddDbContext extension method;
// registering the DbContext that the app will use (PieShopDbContext), specifying that SQL Server
// will be used, and specifying where the connection string to be used is to be pulled from
builder.Services.AddDbContext<PieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:PieShopDbContextConnection"]);
});

var app = builder.Build();

// Middleware:
app.UseStaticFiles(); // Support for returning static files
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // diagnostic middleware - always shows the exception page
}
app.MapDefaultControllerRoute(); // Defaults used in MVC to route to our views

app.Run();
