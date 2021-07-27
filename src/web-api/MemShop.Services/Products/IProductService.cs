using MemShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemShop.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        Product CreateProduct(Product product);
        Product CreateProductForCategory(int categoryId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        Product GetProductForCategory(int categoryId, int productId);
    }
}
