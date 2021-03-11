using MemShop.Data.Repositories;
using MemShop.Data.Repositories.Interfaces;

namespace MemShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MemShopDbContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProviderRepository _providerRepository;

        public UnitOfWork(MemShopDbContext context)
        {
            this._context = context;
        }
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

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
