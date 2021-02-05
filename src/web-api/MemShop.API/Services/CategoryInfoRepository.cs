using MemShop.API.Contexts;
using MemShop.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Services
{
    public class CategoryInfoRepository : ICategoryInfoRepository
    {
        private readonly CategoryInfoContext _context;

        public CategoryInfoRepository(CategoryInfoContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context)); 
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(c => c.Label)
                .ToList();
        }

        public Category GetCategory(int categoryId, bool includeProducts)
        {
            if (includeProducts)
            {
                return _context.Categories
                    .Include(c => c.Products)
                    .Where(c => c.Id == categoryId)
                    .FirstOrDefault();
            }

            return _context.Categories
                .Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public Product GetProductForCategory(int categoryId, int productId)
        {
            return _context.Products
                .Where(p => p.Id == productId && p.CategoryId == categoryId)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _context.Categories
                .Any(c => c.Id == categoryId);
        }

        public void AddProductForCategory(int categoryId, Product product)
        {
            var category = GetCategory(categoryId, false);
            category.Products.Add(product);
        }


        public void DeleteProduct(int categoryId, Product product)
        {
            var category = GetCategory(categoryId, false);
            category.Products.Remove(product);
        }

        public void UpdateProduct(int categoryId, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
