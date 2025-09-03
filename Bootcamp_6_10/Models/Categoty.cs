using System.ComponentModel.DataAnnotations;

namespace Bootcamp_6_10.Models
{
    public class Categoty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayAttribute(Name ="Describ")]
        public string? Description { get; set; }

       
        public ICollection<Product>? Products { get; set; }

    }
}
