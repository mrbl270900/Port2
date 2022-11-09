using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
