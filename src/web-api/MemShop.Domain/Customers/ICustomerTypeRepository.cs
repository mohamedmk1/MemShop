using MemShop.Domain.Interfaces;

namespace MemShop.Domain.Customers
{
    public interface ICustomerTypeRepository : IRepository<CustomerType>
    {
        bool DoesExist(int customerTypeId);
    }
}
