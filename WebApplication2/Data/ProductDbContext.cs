using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>
            contextOptions)
            : base(contextOptions) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Product1",
                        Description = "Product1 Description",
                        Discount = 20,
                        ImagePath = "images\\product-1-1.jpg",
                        Price = 10
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Product2",
                        Description = "Product2 Description",
                        Discount = 35,
                        ImagePath = "images\\product-2-1.jpg",
                        Price = 20
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Product3",
                        Description = "Product3 Description",
                        Discount = 0,
                        ImagePath = "images\\product-3-1.jpg",
                        Price = 30
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Product4",
                        Description = "Product4 Description",
                        Discount = 5,
                        ImagePath = "images\\product-4-1.jpg",
                        Price = 40
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Product5",
                        Description = "Product5 Description",
                        Discount = 15,
                        ImagePath = "images\\product-5-1.jpg",
                        Price = 50
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Product6",
                        Description = "Product6 Description",
                        Discount = 10,
                        ImagePath = "images\\product-6-1.jpg",
                        Price = 20
                    });
        }
    }
}
