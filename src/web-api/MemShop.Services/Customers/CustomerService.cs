using MemShop.Domain.Customers;
using MemShop.Domain.Interfaces;
using System.Collections.Generic;

namespace MemShop.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Commit();
            return customer;
        }

        public Customer CreateCustomerForCustomerType(int customerTypeId, Customer customer)
        {
            if (_unitOfWork.CustomerTypes.DoesExist(customerTypeId))
            {
                var customerType = _unitOfWork.CustomerTypes.GetByIdWithCustomers(customerTypeId);
                customerType.Customers.Add(customer);
                _unitOfWork.Commit();
                return customer;
            }

            return null;
        }

        public void DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Commit();
        }

        public IEnumerable<Customer> GetAllCustomersByCustomerTypeId(int customerTypeId)
        {
            return (_unitOfWork.CustomerTypes.DoesExist(customerTypeId))
                ? _unitOfWork.Customers.GetAllByCustomerTypeId(customerTypeId)
                : null;
        }

        public Customer GetCustomerById(int id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        public Customer GetCustomerForCustomerType(int customerTypeId, int customerId)
        {
            return (_unitOfWork.CustomerTypes.DoesExist(customerTypeId))
                ? _unitOfWork.Customers.GetCustomerForCustomerType(customerTypeId, customerId)
                : null;
        }

        public void UpdateCustomer(Customer customer)
        {
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Commit();
        }
    }
}
