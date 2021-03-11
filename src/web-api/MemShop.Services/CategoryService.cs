using MemShop.Data;
using MemShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void AddProductForCategory(int categoryId, Product product)
        {
            _unitOfWork.Categories.AddProductForCategory(categoryId, product);
            _unitOfWork.Commit();
        }

        public Category CreateCategory(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Commit();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            _unitOfWork.Commit();
        }

        public Category GetCategoryByIdWithProducts(int id)
        {
            return _unitOfWork.Categories
                .GetByIdWithProducts(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Categories
                .GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Categories
                .GetById(id);
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _unitOfWork.Categories
                .DoesExist(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
        }
    }
}
