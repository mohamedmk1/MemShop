using MemShop.Data.Entities;
using MemShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemShop.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MemShopDbContext context) : base(context)
        { }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return MemShopDbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public Product GetProductForCategory(int categoryId, int productId)
        {
            return MemShopDbContext.Products
                .Where(p => p.Id == productId && p.CategoryId == categoryId)
                .FirstOrDefault();
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
