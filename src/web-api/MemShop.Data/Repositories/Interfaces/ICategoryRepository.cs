using MemShop.Data.Entities;

namespace MemShop.Data.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithProducts(int id);
        void AddProductForCategory(int categoryId, Product product);
        bool DoesExist(int categoryId);
    }
}
