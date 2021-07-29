using MemShop.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemShop.Data.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MemShopDbContext context): base(context)
        {

        }

        public IEnumerable<Customer> GetAllByCustomerTypeId(int customerTypeId)
        {
            return MemShopDbContext.Customers
                .Where(c => c.CustomerTypeId == customerTypeId)
                .ToList();
        }

        public Customer GetCustomerForCustomerType(int customerTypeId, int customerId)
        {
            return MemShopDbContext.Customers
                .Where(c => c.CustomerTypeId == customerTypeId && c.Id == customerId)
                .FirstOrDefault();
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
