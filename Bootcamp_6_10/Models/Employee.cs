using System.ComponentModel.DataAnnotations;

namespace Bootcamp_6_10.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        public string password { get; set; }
   

    }
}
