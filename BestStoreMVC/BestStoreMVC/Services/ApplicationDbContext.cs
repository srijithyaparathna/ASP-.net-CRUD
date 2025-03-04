using BestStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BestStoreMVC.Services
{
    // This class represents the database context for the application.
    public class ApplicationDbContext : DbContext
    {
        // The constructor receives `DbContextOptions` and passes it to the base class.
        // This allows the database provider and configuration to be set from `Program.cs`.
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // Define your DbSets here to map entities to database tables.
        // Example:
        // public DbSet<Movie> Movies { get; set; }

        public DbSet<Product> Products { get; set; }


    }
}
