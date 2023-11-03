using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [DisplayName("Product Desctription")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(1, 150, ErrorMessage = "Range should be 1-150")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Discount is required")]
        [Range(5, 90, ErrorMessage = "Range should be 5-90")]
        public int Discount { get; set; }
        public string ImagePath { get; set; }
    }

}
