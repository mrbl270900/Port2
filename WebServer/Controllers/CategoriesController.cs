using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;

        public CategoriesController(IDataService dataService, LinkGenerator generator)
        {
            _dataService = dataService;
            _generator = generator;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = 
                _dataService.GetCategories().Select(x => CreateCategoryModel(x));
            return Ok(categories);
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            var model = CreateCategoryModel(category);

            return Ok(model);

        }

        private CategoryModel CreateCategoryModel(Category category)
        {
            var model = new CategoryModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetCategory), new { category.Id }),
                Name = category.Name,
                Description = category.Description
            };
            return model;
        }
    }
}
