using MemShop.Domain.Customers;
using MemShop.Domain.Products;
using MemShop.Domain.Providers;

namespace MemShop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProviderRepository Providers { get; }
        ICustomerTypeRepository CustomerTypes { get; }
        ICustomerRepository Customers { get;  }
        int Commit();

    }
}
