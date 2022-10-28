using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;

        public ProductsController(IDataService dataService, LinkGenerator generator)
        {
            _dataService = dataService;
            _generator = generator;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products =
                _dataService.GetProducts().Select(x => CreateProductListModel(x));
            return Ok(products);
        }

        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = CreateProductListModel(product);

            return Ok(model);

        }

        private ProductListModel CreateProductListModel(Product product)
        {
            var model = new ProductListModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id }),
                Name = product.Name,
                CategoryName = product.Category.Name
            };
            return model;
        }
    }
}
