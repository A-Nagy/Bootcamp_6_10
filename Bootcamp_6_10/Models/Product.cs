using System.ComponentModel.DataAnnotations;

namespace Bootcamp_6_10.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
     
        public string? ProductDescription { get; set; }
    
        public double? ProductPrice { get; set; }

        public int? ProductQTY { get; set; }

     

    }
}
