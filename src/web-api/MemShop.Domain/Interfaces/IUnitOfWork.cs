using MemShop.Domain.ProductCategories;
using MemShop.Domain.Products;
using MemShop.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProviderRepository Providers { get; }
        int Commit();

    }
}
