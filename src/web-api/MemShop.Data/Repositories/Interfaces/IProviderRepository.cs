using MemShop.Data.Entities;
using System.Collections.Generic;

namespace MemShop.Data.Repositories.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        IEnumerable<Provider> GetAllWithProducts();
    }
}
