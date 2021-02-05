using MemShop.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Contexts
{
    public class CategoryInfoContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public CategoryInfoContext(DbContextOptions<CategoryInfoContext> options): base(options)
        {
            // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category()
                    {
                        Id = 1,
                        Label = "Category 1",
                        Description = "Desc Category 1"
                    },
                    new Category()
                    {
                        Id = 2,
                        Label = "Category 2",
                        Description = "Desc Category 2"
                    },
                    new Category()
                    {
                        Id = 3,
                        Label = "Category 3",
                        Description = "Desc Category 3"
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product()
                    {
                        Id = 1,
                        CategoryId = 1,
                        Reference = "ref01",
                        Label = "Product 1",
                        Price = 13.45,
                        Image = "image01.png",
                        Description = "desc1"
                    },
                    new Product()
                    {
                        Id = 2,
                        CategoryId = 1,
                        Reference = "ref02",
                        Label = "Product 2",
                        Price = 18.55,
                        Image = "image02.png",
                        Description = "desc2"
                    },
                    new Product()
                    {
                        Id = 3,
                        CategoryId = 2,
                        Reference = "ref03",
                        Label = "Product 3",
                        Price = 20.255,
                        Image = "image03.png",
                        Description = "desc3"
                    },
                    new Product()
                    {
                        Id = 4,
                        CategoryId = 2,
                        Reference = "ref04",
                        Label = "Product 4",
                        Price = 16.25,
                        Image = "image04.png",
                        Description = "desc4"
                    },
                    new Product()
                    {
                        Id = 5,
                        CategoryId = 3,
                        Reference = "ref05",
                        Label = "Product 5",
                        Price = 25.65,
                        Image = "image05.png",
                        Description = "desc5"
                    }
                 );

            base.OnModelCreating(modelBuilder);
        }
    }
}
