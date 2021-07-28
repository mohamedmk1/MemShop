using MemShop.Domain.Providers;
using System.Collections.Generic;

namespace MemShop.Services.Providers
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
