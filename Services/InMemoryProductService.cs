using ProductsCRUD.Models;
namespace ProductsCRUD.Services;
// Scoped service shares a static, synchronized store between requests.
public sealed class InMemoryProductService : IProductService
{
    private static readonly object Sync = new();
    private static readonly List<Category> Categories = new()
    {
        new() { Id = 1, Name = "Електроніка" },
        new() { Id = 2, Name = "Аксесуари" }
    };
    private static readonly List<Product> Products = new()
    {
        new() { Id = 1, Name = "Ноутбук", Description = "Для навчання та роботи", Price = 28500, CategoryId = 1 },
        new() { Id = 2, Name = "Миша", Description = "Бездротова", Price = 850, CategoryId = 2 }
    };
    private static int _nextId = 3;
    private static Product Copy(Product p) => new()
    {
        Id = p.Id, Name = p.Name, Price = p.Price, Description = p.Description, CategoryId = p.CategoryId
    };
    public Task<IReadOnlyList<Product>> GetAllAsync()
    {
        lock (Sync) return Task.FromResult<IReadOnlyList<Product>>(Products.OrderBy(p => p.Id).Select(Copy).ToList());
    }
    public Task<Product?> GetByIdAsync(int id)
    {
        lock (Sync)
        {
            var found = Products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(found is null ? null : Copy(found));
        }
    }
    public Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        lock (Sync) return Task.FromResult<IReadOnlyList<Category>>(Categories.Select(c => new Category { Id = c.Id, Name = c.Name }).ToList());
    }
    public Task AddAsync(Product product)
    {
        lock (Sync)
        {
            var copy = Copy(product);
            copy.Id = _nextId++;
            Products.Add(copy);
        }
        return Task.CompletedTask;
    }
    public Task<bool> UpdateAsync(Product product)
    {
        lock (Sync)
        {
            var stored = Products.FirstOrDefault(p => p.Id == product.Id);
            if (stored is null) return Task.FromResult(false);
            stored.Name = product.Name;
            stored.Description = product.Description;
            stored.Price = product.Price;
            stored.CategoryId = product.CategoryId;
            return Task.FromResult(true);
        }
    }
    public Task<bool> DeleteAsync(int id)
    {
        lock (Sync)
        {
            var stored = Products.FirstOrDefault(p => p.Id == id);
            if (stored is null) return Task.FromResult(false);
            Products.Remove(stored);
            return Task.FromResult(true);
        }
    }
}
