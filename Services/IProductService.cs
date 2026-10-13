using ProductsCRUD.Models;
namespace ProductsCRUD.Services;
public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
    Task<IReadOnlyList<Category>> GetCategoriesAsync();
}
