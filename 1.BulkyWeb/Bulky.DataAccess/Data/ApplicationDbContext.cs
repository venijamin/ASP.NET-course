using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Category> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData
        (
            new Category { Id = 1, Name = "Category1", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Category2", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Category3", DisplayOrder = 3 }
        );

        modelBuilder.Entity<Product>().HasData
        (
            new Product
            {
                Id = 1,
                Title = "The Great Gatsby",
                ISBN = "978-3-16-148410-0",
                Author = "F. Scott Fitzgerald",
                ListPrice = 25.99
            },
            new Product
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                ISBN = "978-0-06-112008-4",
                Author = "Harper Lee",
                ListPrice = 19.95
            },
            new Product
            {
                Id = 3,
                Title = "1984",
                ISBN = "978-0-452-28423-4",
                Author = "George Orwell",
                ListPrice = 22.50
            },
            new Product
            {
                Id = 4,
                Title = "The Catcher in the Rye",
                ISBN = "978-0-316-76948-0",
                Author = "J.D. Salinger",
                ListPrice = 18.75
            }
        );
    }
}