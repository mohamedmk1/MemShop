using MemShop.Domain.CustomerTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services.CustomerTypes
{
    public interface ICustomerTypeService
    {
        CustomerType GetCustomerTypeById(int id);
        CustomerType CreateCustomerType(CustomerType customerType);
        IEnumerable<CustomerType> GetCustomerTypes();
        void UpdateCustomerType(CustomerType customerType);
        void DeleteCustomerType(CustomerType customerType);
        bool IsCustomerTypeExist(int customerTypeId);
    }
}
