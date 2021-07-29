using MemShop.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services.Customers
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer CreateCustomerForCustomerType(int customerTypeId, Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomersByCustomerTypeId(int customerTypeId);
        Customer GetCustomerForCustomerType(int customerTypeId, int customerId);
    }
}
