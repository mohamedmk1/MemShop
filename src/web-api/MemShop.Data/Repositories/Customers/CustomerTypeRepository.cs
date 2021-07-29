using MemShop.Domain.Customers;
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
            throw new System.NotImplementedException();
        }

        public void AddCustomerForCustomerType(int customerTypeId, Customer customer)
        {
            throw new System.NotImplementedException();
        }

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
