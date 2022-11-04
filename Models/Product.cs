using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Models
{
    public enum Make
    {
        LG = 1,
        SamSung,
        GE

    }
    public enum Category
    {
        Dishwasher = 1,
        Washer,
        Dryer,
        Stove,
        Refrigerator
    }
    public class Product
    {
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "Please fill in id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Please select")]
        public Category Item { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please fill in name")]
        [MaxLength(100)]

        public string? Name { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Cannot leave with blank")]
        [MaxLength(500, ErrorMessage = "Please limit with 500 character")]
        public string? Description { get; set; }
        [Required(ErrorMessage ="12356")]
        public string? ImageName { get; set; }
        [Required(ErrorMessage ="Please select")]
        public Make Manufacture { get; set; }

    }
}
