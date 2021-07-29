using MemShop.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MemShop.Data.Repositories.Providers
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(MemShopDbContext context)
            : base(context)
        {

        }
        public IEnumerable<Provider> GetAllWithProducts()
        {
            return MemShopDbContext.Providers
                .Include(p => p.Products)
                .ToList();
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
