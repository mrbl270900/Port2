using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer
{
    public class DataService : IDataService
    {
        private readonly List<Category> _categories = new List<Category>
        {
            new Category{ Id = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales"},
            new Category{ Id = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
            new Category{ Id = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads"},
            new Category{ Id = 4, Name = "Dairy Products", Description = "Cheeses"},
            new Category{ Id = 5, Name = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal"},
            new Category{ Id = 6, Name = "Meat/Poultry", Description = "Prepared meats"},
            new Category{ Id = 7, Name = "Produce", Description = "Dried fruit and bean curd"},
            new Category{ Id = 8, Name = "Seafood", Description = "Seaweed and fish"}
        };

        private readonly List<Product> _products = new List<Product>();


        public DataService()
        {
            _products.Add(new Product { Id = 1, Name = "Chai", Category = GetCategory(1) });
            _products.Add(new Product { Id = 2, Name = "Chang", Category = GetCategory(1) });
            _products.Add(new Product { Id = 3, Name = "Aniseed Syrup", Category = GetCategory(2) });
            _products.Add(new Product { Id = 4, Name = "Chef Anton's Cajun Seasoning", Category = GetCategory(2) });
        }


        public IList<Category> GetCategories()
        {
            return _categories;
        }

        public Category? GetCategory(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public void CreateCategory(Category category)
        {
            var maxId = _categories.Max(x => x.Id);
            category.Id = maxId + 1;
            _categories.Add(category);
        }

        public bool UpdateCategory(Category category)
        { 
            var dbCat = GetCategory(category.Id);
            if (dbCat == null)
            {
                return false;
            }
            dbCat.Name = category.Name;
            dbCat.Description = category.Description;
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var dbCat = GetCategory(id);
            if (dbCat == null)
            {
                return false;
            }
            _categories.Remove(dbCat);
            return true;
        }


        public IList<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public IList<ProductSearchModel> GetProductByName(string search)
        {
            return _products
                .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                .Select(x => new ProductSearchModel { ProductName = x.Name, CategoryName = x.Category.Name })
                .ToList();
        }
    }
}
