using Microsoft.EntityFrameworkCore;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categoriesTable { get; set; }
        public DbSet<Product> productsTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    name = "Dell",
                    Description = "Windows 11"
                },
                new Category
                {
                    CategoryId = 2,
                    name = "MacBook",
                    Description = "Mac OS"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    CategoryId =1,
                    name =" Dell",
                    Quantity=5000,
                    price=4567654
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 2,
                    name = "MacBook",
                    Quantity = 1000,
                    price =984453
                }


                );
        }
    }
}
