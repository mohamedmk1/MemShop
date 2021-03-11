using MemShop.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Data
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProviderRepository Providers { get; }
        int Commit();

    }
}
