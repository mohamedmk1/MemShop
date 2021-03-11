using MemShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        Category CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Category GetByIdWithProducts(int id);
        void AddProductForCategory(int categoryId, Product product);
        bool IsCategoryExist(int categoryId);
    }
}
