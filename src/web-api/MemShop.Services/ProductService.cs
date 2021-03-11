using MemShop.Data;
using MemShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Product CreateProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Commit();
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return _unitOfWork.Products.GetAllByCategoryId(categoryId);
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public Product GetProductForCategory(int categoryId, int productId)
        {
            return _unitOfWork.Products
                .GetProductForCategory(categoryId, productId);
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
        }
    }
}
