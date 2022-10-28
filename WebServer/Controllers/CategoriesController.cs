using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private IDataService _dataService = new DataService();

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }
    }
}
