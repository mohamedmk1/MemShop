using MemShop.API.Entities;
using System.Collections.Generic;

namespace MemShop.API.Services
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetProviders();
        Provider GetProvider(int providerId);
        void AddProvider(Provider provider);
        void UpdateProvider(Provider provider);
        void DeleteProvider(Provider provider);
        IEnumerable<Product> GetProducts(int providerId);
        bool Save();
    }
}
