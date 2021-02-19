using MemShop.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Services
{
    public interface ICategoryInfoRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int categoryId, bool includeProducts);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        IEnumerable<Product> GetProducts(int categoryId);
        Product GetProductForCategory(int categoryId, int productId);
        bool IsCategoryExist(int categoryId);
        void AddProductForCategory(int categoryId, Product product);
        void UpdateProduct(int categoryId, Product product);
        public void DeleteProduct(int categoryId, Product product);
        bool Save();
    }
}
