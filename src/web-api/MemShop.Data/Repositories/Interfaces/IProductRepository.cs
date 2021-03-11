using MemShop.Data.Entities;
using System.Collections.Generic;

namespace MemShop.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        Product GetProductForCategory(int categoryId, int productId);

    }
}
