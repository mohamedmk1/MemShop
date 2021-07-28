using MemShop.Domain.Interfaces;
using MemShop.Domain.ProductCategories;
using MemShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void AddProductForCategory(int categoryId, Product product)
        {
            _unitOfWork.Categories.AddProductForCategory(categoryId, product);
            _unitOfWork.Commit();
        }

        public ProductCategory CreateCategory(ProductCategory category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Commit();
            return category;
        }

        public void DeleteCategory(ProductCategory category)
        {
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Commit();
        }

        public ProductCategory GetCategoryByIdWithProducts(int id)
        {
            return _unitOfWork.Categories
                .GetByIdWithProducts(id);
        }

        public IEnumerable<ProductCategory> GetCategories()
        {
            return _unitOfWork.Categories
                .GetAll();
        }

        public ProductCategory GetCategoryById(int id)
        {
            return _unitOfWork.Categories
                .GetById(id);
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _unitOfWork.Categories
                .DoesExist(categoryId);
        }

        public void UpdateCategory(ProductCategory category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Commit();
        }
    }
}
