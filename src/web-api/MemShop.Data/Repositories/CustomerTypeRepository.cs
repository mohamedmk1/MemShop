using MemShop.Domain.CustomerTypes;
using System.Linq;

namespace MemShop.Data.Repositories
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

        private MemShopDbContext MemShopDbContext
        {
            get { return Context as MemShopDbContext; }
        }
    }
}
