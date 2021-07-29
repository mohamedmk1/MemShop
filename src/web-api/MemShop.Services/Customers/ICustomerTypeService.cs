using MemShop.Domain.Customers;
using System.Collections.Generic;

namespace MemShop.Services.Customers
{
    public interface ICustomerTypeService
    {
        CustomerType GetCustomerTypeById(int id);
        CustomerType CreateCustomerType(CustomerType customerType);
        IEnumerable<CustomerType> GetCustomerTypes();
        void UpdateCustomerType(CustomerType customerType);
        void DeleteCustomerType(CustomerType customerType);
        CustomerType GetCustomerTypeByIdWithCustomers(int id);
        void AddCustomerForCustomerType(int customerTypeId, Customer customer);
        bool IsCustomerTypeExist(int customerTypeId);
    }
}
