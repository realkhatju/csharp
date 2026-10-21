using CrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db, CancellationToken cancellationToken = default)
    {
        if (await db.Products.AnyAsync(cancellationToken))
            return;

        db.Products.AddRange(
            new Product { Name = "Mechanical Keyboard", Description = "87-key hot-swappable keyboard", Price = 129.99m, Stock = 25, Category = "Electronics" },
            new Product { Name = "Noise Cancelling Headphones", Description = "Over-ear wireless headphones", Price = 249.00m, Stock = 12, Category = "Electronics" },
            new Product { Name = "Standing Desk", Description = "Electric height-adjustable desk", Price = 499.50m, Stock = 7, Category = "Furniture" },
            new Product { Name = "Ergonomic Chair", Description = "Mesh back office chair", Price = 329.00m, Stock = 10, Category = "Furniture" },
            new Product { Name = "Stainless Steel Bottle", Description = "1L insulated water bottle", Price = 24.95m, Stock = 100, Category = "Lifestyle" }
        );

        await db.SaveChangesAsync(cancellationToken);
    }
}
