using MemShop.Domain.Interfaces;
using MemShop.Domain.Products;
using System.Collections.Generic;

namespace MemShop.Services.Products
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

        public Product CreateProductForCategory(int categoryId, Product product)
        {
            if (_unitOfWork.Categories.DoesExist(categoryId))
            {
                var category = _unitOfWork.Categories.GetByIdWithProducts(categoryId);
                product.ProviderId = 1;
                category.Products.Add(product);
                _unitOfWork.Commit();
                return product;
            }
            return null;
        }

        public void DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            return (_unitOfWork.Categories.DoesExist(categoryId))
                 ? _unitOfWork.Products.GetAllByCategoryId(categoryId)
                 : null;
        }

        public Product GetProductById(int id)
        {
            return _unitOfWork.Products.GetById(id);
        }

        public Product GetProductForCategory(int categoryId, int productId)
        {
            return (_unitOfWork.Categories.DoesExist(categoryId))
                ? _unitOfWork.Products.GetProductForCategory(categoryId, productId)
                : null;
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
        }
    }
}
