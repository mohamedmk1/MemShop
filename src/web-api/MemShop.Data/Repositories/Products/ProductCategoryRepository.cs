using MemShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MemShop.Data.Repositories.Products
{
    class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(MemShopDbContext context) : base(context)
        { }

        public bool DoesExist(int categoryId)
        {
            return MemShopDbContext.Categories
                .Any(c => c.Id == categoryId);
        }

        public ProductCategory GetByIdWithProducts(int id)
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
