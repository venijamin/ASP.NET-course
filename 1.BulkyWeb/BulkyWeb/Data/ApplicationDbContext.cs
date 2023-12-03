using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData
        (
            new Category { Id = 1, Name = "Category1", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Category2", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Category3", DisplayOrder = 3 }
        );
    }

}