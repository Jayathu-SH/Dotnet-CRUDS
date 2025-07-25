using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        //relational databases Id field will be auto-incremented if it is marked as the primary key.
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        //string.Empty-Name property with an empty string ("") by default.
        
        [StringLength(500)]
        public string? Description { get; set; } //optional property-?
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}