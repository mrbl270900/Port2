using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataService : IDataService
    {
        public void CreateCategory(Category category)
        {
            using var db = new NorthwindContext();
            category.Id = db.Categories.Any() ? db.Categories.Max(x => x.Id) + 1 : 1;
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            return db.SaveChanges() > 0;
        }

        public IList<Category> GetCategories()
        {
            using var db = new NorthwindContext();
            return db.Categories.ToList();
        }

        public Category? GetCategory(int id)
        {
            using var db = new NorthwindContext();
            return db.Categories.Find(id);
        }

        public Product? GetProduct(int id)
        {
            using var db = new NorthwindContext();
            return db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public IList<ProductSearchModel> GetProductByName(string search)
        {
            using var db = new NorthwindContext();
            return db.Products
                .Include(x => x.Category)
                .Where(x => x.Name == search)
                .Select(x => new ProductSearchModel
                {
                    ProductName = x.Name,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }

        public IList<Product> GetProducts(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.Products
                .Include(x => x.Category)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.Id)
                .ToList();
        }

        public int GetNumberOfProducts()
        {
            using var db = new NorthwindContext();
            return db.Products.Count();
        }

        public bool UpdateCategory(Category category)
        {
            using var db = new NorthwindContext();
            var dbCategory = db.Categories.Find(category.Id);
            if (dbCategory == null) return false;
            dbCategory.Name = category.Name;
            dbCategory.Description = category.Description;
            db.SaveChanges();
            return true;
        }
    }
}
