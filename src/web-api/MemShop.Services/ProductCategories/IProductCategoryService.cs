﻿using MemShop.Domain.ProductCategories;
using MemShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public interface IProductCategoryService
    {
        ProductCategory GetCategoryById(int id);
        ProductCategory CreateCategory(ProductCategory category);
        IEnumerable<ProductCategory> GetCategories();
        void UpdateCategory(ProductCategory category);
        void DeleteCategory(ProductCategory category);
        ProductCategory GetCategoryByIdWithProducts(int id);
        void AddProductForCategory(int categoryId, Product product);
        bool IsCategoryExist(int categoryId);
    }
}