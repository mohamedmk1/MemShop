using MemShop.Domain.Interfaces;
using MemShop.Domain.Products;

namespace MemShop.Domain.ProductCategories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory GetByIdWithProducts(int id);
        void AddProductForCategory(int categoryId, Product product);
        bool DoesExist(int categoryId);
    }
}
