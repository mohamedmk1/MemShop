using MemShop.Domain.Interfaces;
using System.Collections.Generic;

namespace MemShop.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAllByCustomerTypeId(int customerTypeId);
        Customer GetCustomerForCustomerType(int customerTypeId, int customerId);
    }
}
