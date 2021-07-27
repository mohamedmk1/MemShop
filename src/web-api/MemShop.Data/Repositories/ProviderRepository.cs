using MemShop.Domain.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemShop.Data.Repositories
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
