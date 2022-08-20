using System.Drawing;

namespace BestBuy.Models
{
    public enum ProductsCategory
    {
        Product
    }
    public class ProductsModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductsCategory? Category { get; set; }
        public int Price { get; set; }
        public Image? Image { get; set; }
    }
}
