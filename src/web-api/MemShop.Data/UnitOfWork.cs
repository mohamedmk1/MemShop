using MemShop.Data.Repositories.Customers;
using MemShop.Data.Repositories.Products;
using MemShop.Data.Repositories.Providers;
using MemShop.Domain.Customers;
using MemShop.Domain.Interfaces;
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
        private readonly CustomerTypeRepository _customerTypeRepository;
        private readonly CustomerRepository _customerRepository;

        public UnitOfWork(MemShopDbContext context)
        {
            this._context = context;
        }
        public IProductCategoryRepository Categories => _categoryRepository ?? new ProductCategoryRepository(_context);
        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);
        public IProviderRepository Providers => _providerRepository ?? new ProviderRepository(_context);
        public ICustomerTypeRepository CustomerTypes => _customerTypeRepository ?? new CustomerTypeRepository(_context);
        public ICustomerRepository Customers => _customerRepository ?? new CustomerRepository(_context);

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
