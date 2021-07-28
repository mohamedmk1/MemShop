using MemShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Domain.CustomerTypes
{
    public interface  ICustomerTypeRepository : IRepository<CustomerType>
    {
        bool DoesExist(int customerTypeId);
    }
}
