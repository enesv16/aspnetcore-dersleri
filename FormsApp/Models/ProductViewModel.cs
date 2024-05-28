using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsApp.Models
{

    public class ProductListViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
    public class ProductViewModel
    {
        public List<Product>? Products { get; set; }
        public List<Category>? Categories { get; set; }
        public string? SelectedCategory { get; set; }
    }
}