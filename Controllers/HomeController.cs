using Microsoft.AspNetCore.Mvc;

namespace ProductsCRUD.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Products");
    public IActionResult Error() => View();
}
