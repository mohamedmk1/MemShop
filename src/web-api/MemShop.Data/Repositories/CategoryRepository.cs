using MemShop.Domain.ProductCategories;
using MemShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemShop.Data.Repositories
{
    class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MemShopDbContext context) : base(context)
        { }
        public bool DoesExist(int categoryId)
        {
            return MemShopDbContext.Categories
                .Any(c => c.Id == categoryId);
        }

        public Category GetByIdWithProducts(int id)
        {
            return MemShopDbContext.Categories
                .Include(c => c.Products)
                .SingleOrDefault(c => c.Id == id);
        }

        public void AddProductForCategory(int categoryId, Product product)
        {
            var category = GetByIdWithProducts(categoryId);
            category.Products.Add(product);
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
