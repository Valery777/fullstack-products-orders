using Microsoft.EntityFrameworkCore;
using DotNetProductApi.Models;

namespace DotNetProductApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "חלב וגבינות" },
                new Category { Id = 2, Name = "טואלטיקה" },
                new Category { Id = 3, Name = "בשר" },
                new Category { Id = 4, Name = "ירקות ופירות" }
            );

            
            // Seed products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "קוטג", Price = 4.5m, CategoryId = 1 },
                new Product { Id = 2, Name = "חלב 3%", Price = 5m, CategoryId = 1 },
                new Product { Id = 3, Name = "שמנת חמוצה", Price = 3.5m, CategoryId = 1 },
                new Product { Id = 4, Name = "קרמים", Price = 142.6m, CategoryId = 2 },
                new Product { Id = 5, Name = "פרסטו ג'ל", Price = 25.99m, CategoryId = 2 },
                new Product { Id = 6, Name = "טיפול וטיפוח השיער", Price = 33.99m, CategoryId = 2 },
                new Product { Id = 7, Name = "קרם צ'רידה", Price = 51.99m, CategoryId = 2 },
                new Product { Id = 8, Name = "שוקים", Price = 12.99m, CategoryId = 3 },
                new Product { Id = 9, Name = "סלמון", Price = 75.99m, CategoryId = 3 }, 
                new Product { Id = 10, Name = "בצל", Price = 3.99m, CategoryId = 4 },
                new Product { Id = 11, Name = "מנגו", Price = 19.40m, CategoryId = 4 },
                new Product { Id = 12, Name = "אגבניות", Price = 7.59m, CategoryId = 4 }
            );
        }
    }
}
