using MemShop.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MemShop.Data.Repositories.Customers
{
    class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(MemShopDbContext context): base(context)
        {}

        public bool DoesExist(int customerTypeId)
        {
            return MemShopDbContext.CustomerTypes
                .Any(ct => ct.Id == customerTypeId);
        }

        public CustomerType GetByIdWithCustomers(int id)
        {
            return MemShopDbContext.CustomerTypes
                .Include(ct => ct.Customers)
                .SingleOrDefault(ct => ct.Id == id);
        }

        public void AddCustomerForCustomerType(int customerTypeId, Customer customer)
        {
            var customerType = GetByIdWithCustomers(customerTypeId);
            customerType.Customers.Add(customer);
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
