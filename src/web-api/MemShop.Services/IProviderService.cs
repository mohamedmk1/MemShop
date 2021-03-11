using MemShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public interface IProviderService
    {
        Provider GetProviderById(int id);
        Provider CreateProvider(Provider provider);
        void UpdateProvider(Provider provider);
        void DeleteProvider(Provider provider);
        IEnumerable<Provider> GetAllWithProducts();

    }
}
