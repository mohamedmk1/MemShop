using MemShop.Domain.Interfaces;

namespace MemShop.Domain.Customers
{
    public interface ICustomerTypeRepository : IRepository<CustomerType>
    {
        CustomerType GetByIdWithCustomers(int id);
        void AddCustomerForCustomerType(int customerTypeId, Customer customer);
        bool DoesExist(int customerTypeId);
    }
}
