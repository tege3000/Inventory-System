using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InventorySystem.Data
{
    public class InventoryDbContext : IdentityDbContext<ApplicationUser>
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API examples if needed:
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);
            
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Stationery" }
            );

            // Seed Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Tech Supplies Ltd", ContactInfo = "Giving you a great tech supplies", ContactEmail = "tech@example.com" },
                new Supplier { Id = 2, Name = "Office World", ContactInfo = "Giving you great office supplies", ContactEmail = "office@example.com" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    SKU = "ELEC001",
                    Quantity = 50,
                    Price = 2500.00m,
                    CategoryId = 1,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Notebook",
                    SKU = "STAT001",
                    Quantity = 200,
                    Price = 500.00m,
                    CategoryId = 2,
                    SupplierId = 2
                }
            );
        }
    }
}
