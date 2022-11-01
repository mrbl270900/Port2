using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class ProductModel
    {
        public string? Url { get; set; }
        public string? Name { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string? QuantityPerUnit { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
