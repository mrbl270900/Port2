using DataLayer.Domain;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {
        IList<Category> GetCategories();
        Category? GetCategory(int id);
        IList<Product> GetProducts(int page, int pageSize);
        Product? GetProduct(int id);
        int GetNumberOfProducts();
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);

        IList<ProductSearchModel> GetProductByName(string search);
    }
}