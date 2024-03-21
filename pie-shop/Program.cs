var builder = WebApplication.CreateBuilder(args);

//Enabling MVC in the application
builder.Services.AddControllersWithViews(); 

var app = builder.Build();

// Middleware:
app.UseStaticFiles(); // Support for returning static files
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // diagnostic middleware - always shows the exception page
}
app.MapDefaultControllerRoute(); // Defaults used in MVC to route to our views

app.Run();
