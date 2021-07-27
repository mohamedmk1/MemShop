using MemShop.Domain.Interfaces;
using MemShop.Domain.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProviderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Provider CreateProvider(Provider provider)
        {
            _unitOfWork.Providers.Add(provider);
            _unitOfWork.Commit();
            return provider;
        }

        public void DeleteProvider(Provider provider)
        {
            _unitOfWork.Providers.Remove(provider);
        }

        public IEnumerable<Provider> GetAllWithProducts()
        {
            return _unitOfWork.Providers.GetAllWithProducts();
        }

        public Provider GetProviderById(int id)
        {
            return _unitOfWork.Providers.GetById(id);
        }

        public void UpdateProvider(Provider provider)
        {
            _unitOfWork.Providers.Update(provider);
        }
    }
}
