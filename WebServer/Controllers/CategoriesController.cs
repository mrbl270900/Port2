using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
