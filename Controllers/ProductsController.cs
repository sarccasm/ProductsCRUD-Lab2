using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsCRUD.Models;
using ProductsCRUD.Services;
namespace ProductsCRUD.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _service;
    public ProductsController(IProductService service) => _service = service;

    private async Task LoadCategoriesAsync()
    {
        ViewBag.Categories = new SelectList(await _service.GetCategoriesAsync(), "Id", "Name");
    }
    private async Task CheckCategoryAsync(Product product)
    {
        var categories = await _service.GetCategoriesAsync();
        if (!categories.Any(c => c.Id == product.CategoryId))
            ModelState.AddModelError(nameof(Product.CategoryId), "Виберіть категорію зі списку.");
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.CategoryNames = (await _service.GetCategoriesAsync()).ToDictionary(c => c.Id, c => c.Name);
        return View(await _service.GetAllAsync());
    }
    public async Task<IActionResult> Details(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product is null) return NotFound();
        ViewBag.CategoryNames = (await _service.GetCategoriesAsync()).ToDictionary(c => c.Id, c => c.Name);
        return View(product);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadCategoriesAsync();
        return View(new Product());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Price,Description,CategoryId")] Product product)
    {
        await CheckCategoryAsync(product);
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(product);
        }
        await _service.AddAsync(product);
        TempData["Message"] = "Товар додано.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product is null) return NotFound();
        await LoadCategoriesAsync();
        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,CategoryId")] Product product)
    {
        if (id != product.Id) return BadRequest();
        if (await _service.GetByIdAsync(id) is null) return NotFound();
        await CheckCategoryAsync(product);
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(product);
        }
        if (!await _service.UpdateAsync(product)) return NotFound();
        TempData["Message"] = "Товар оновлено.";
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : View(product);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await _service.DeleteAsync(id)) return NotFound();
        TempData["Message"] = "Товар видалено.";
        return RedirectToAction(nameof(Index));
    }
    // Optional JSON API endpoint (+1 point).
    [HttpGet("products/{id:int}/info")]
    public async Task<IActionResult> Info(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Json(product);
    }
}
