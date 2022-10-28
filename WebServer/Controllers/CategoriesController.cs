using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    [ApiController]
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

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            _dataService.CreateCategory(category);

            return CreatedAtRoute(null, CreateCategoryModel(category));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleted = _dataService.DeleteCategory(id);

            if (!deleted)
            {
               return  NotFound();
            }

            return Ok();
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
