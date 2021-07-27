using MemShop.Domain.Interfaces;
using System.Collections.Generic;

namespace MemShop.Domain.Providers
{
    public interface IProviderRepository : IRepository<Provider>
    {
        IEnumerable<Provider> GetAllWithProducts();
    }
}
