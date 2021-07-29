using MemShop.Domain.Interfaces;

namespace MemShop.Domain.Products
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory GetByIdWithProducts(int id);
        void AddProductForCategory(int categoryId, Product product);
        bool DoesExist(int categoryId);
    }
}
