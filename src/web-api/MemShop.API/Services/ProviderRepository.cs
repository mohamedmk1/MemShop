using MemShop.API.Contexts;
using MemShop.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemShop.API.Services
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly CategoryInfoContext _context;

        public ProviderRepository(CategoryInfoContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void AddProvider(Provider provider)
        {
            _context.Providers.Add(provider);
        }

        public void DeleteProvider(Provider provider)
        {
            _context.Providers.Remove(provider);
        }

        public IEnumerable<Product> GetProducts(int providerId)
        {
            return _context.Providers
                .Where(c => c.Id == providerId).FirstOrDefault().Products;
        }

        public Provider GetProvider(int providerId)
        {
            return _context.Providers
                .Where(c => c.Id == providerId).FirstOrDefault();
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _context.Providers
                .OrderBy(c => c.Name)
                .ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProvider(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
        }
    }
}
