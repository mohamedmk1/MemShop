using MemShop.Data.Repositories;
using MemShop.Domain.Interfaces;
using MemShop.Domain.ProductCategories;
using MemShop.Domain.Products;
using MemShop.Domain.Providers;

namespace MemShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MemShopDbContext _context;
        private readonly ProductCategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;
        private readonly ProviderRepository _providerRepository;

        public UnitOfWork(MemShopDbContext context)
        {
            this._context = context;
        }
        public IProductCategoryRepository Categories => _categoryRepository ?? new ProductCategoryRepository(_context);

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public IProviderRepository Providers => _providerRepository ?? new ProviderRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
