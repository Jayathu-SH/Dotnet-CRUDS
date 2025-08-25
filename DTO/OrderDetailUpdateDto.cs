using System.ComponentModel.DataAnnotations;

namespace CrudApp.DTO
{
    public class OrderDetailUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public decimal UnitPrice { get; set; }
    }
}