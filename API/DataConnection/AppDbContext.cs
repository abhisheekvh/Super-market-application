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
        public DbSet<Category> categories { get; set; }
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
        }
    }
}
