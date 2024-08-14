using MVCWithRazor.Interfaces;
using MVCWithRazor.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Adds services for controllers with views (MVC)
builder.Services.AddRazorPages(); // Adds services for Razor Pages

// Register IConfiguration if you need to inject it directly (optional)
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Register DepartmentRepo as the implementation of IDepartment
builder.Services.AddScoped<IDepartment, DepartmentRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use a custom error page in production
    app.UseHsts(); // Adds HTTP Strict Transport Security in production
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files (e.g., wwwroot)

app.UseRouting(); // Add routing to the middleware pipeline

app.UseAuthentication(); // Ensure this is added if you use authentication
app.UseAuthorization(); // Add authorization to the middleware pipeline

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Route for MVC controllers

app.MapRazorPages(); // Route for Razor Pages

app.Run(); // Run the application
