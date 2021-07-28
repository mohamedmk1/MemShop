using MemShop.Domain.CustomerTypes;
using MemShop.Domain.Interfaces;
using System.Collections.Generic;

namespace MemShop.Services.CustomerTypes
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerTypeService(IUnitOfWork unitOfwork)
        {
            this._unitOfWork = unitOfwork;
        }

        public CustomerType CreateCustomerType(CustomerType customerType)
        {
            _unitOfWork.CustomerTypes.Add(customerType);
            _unitOfWork.Commit();

            return customerType;
        }

        public void DeleteCustomerType(CustomerType customerType)
        {
            _unitOfWork.CustomerTypes.Remove(customerType);
            _unitOfWork.Commit();
        }

        public CustomerType GetCustomerTypeById(int id)
        {
            return _unitOfWork.CustomerTypes.GetById(id);

        }

        public IEnumerable<CustomerType> GetCustomerTypes()
        {
            return _unitOfWork.CustomerTypes.GetAll();
        }

        public bool IsCustomerTypeExist(int customerTypeId)
        {
            return _unitOfWork.CustomerTypes.DoesExist(customerTypeId);
        }

        public void UpdateCustomerType(CustomerType customerType)
        {
            _unitOfWork.CustomerTypes.Update(customerType);
            _unitOfWork.Commit();
        }
    }
}
