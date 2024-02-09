using Humanizer;
using System.Xml.Linq;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public int SubCategoryId {get;set;}
        public SubCategory SubCategory { get; set;} 
    }
}
