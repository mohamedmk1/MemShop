using MemShop.Domain.Interfaces;
using System.Collections.Generic;

namespace MemShop.Domain.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        Product GetProductForCategory(int categoryId, int productId);

    }
}
