using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Xml.Linq;

namespace BestBuy.Models
{
    public enum ProductsCategory
    {

        Сlothing,
        [Display(Name = "Consumer electronics")]
        Consumer_electronics,
        [Display(Name = "Radio engineering")]
        Radio_engineering
    }
    public enum County
    {

        Azerbaijan,
        Russia,
        Belarus,
        Ukrain,
        [Display(Name = "United States")]
        United_States
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
