using BestStoreMVC.Services; // Import the namespace containing ApplicationDbContext
using Microsoft.EntityFrameworkCore; // Import Entity Framework Core for database operations

var builder = WebApplication.CreateBuilder(args); // Create a web application builder

// Add services to the container.
builder.Services.AddControllersWithViews(); // Register MVC pattern controllers and views

// Configure the database context with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Retrieve the database connection string from `appsettings.json`
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Configure the database context to use SQL Server with the retrieved connection string
    options.UseSqlServer(connectionString); // Change this to `UseMySQL(connectionString)` if using MySQL
});

var app = builder.Build(); // Build the application

// Configure the HTTP request pipeline (middleware setup)
if (!app.Environment.IsDevelopment()) // If the app is NOT in development mode
{
    app.UseExceptionHandler("/Home/Error"); // Use a custom error handler
    app.UseHsts(); // Enforce HTTPS security by enabling HTTP Strict Transport Security (HSTS)
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Enable serving static files (CSS, JS, images, etc.)
app.UseRouting(); // Enable routing
app.UseAuthorization(); // Enable authentication and authorization

// Define default route pattern for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route to HomeController -> Index action

app.Run(); // Start the application
