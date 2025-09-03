using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
      
        public int CategotyId { get; set; }
      
        [ForeignKey("CategotyId")]        
        public Categoty? Categoty { get; set; }

        public int? ProductQTY { get; set; }

     

    }
}
