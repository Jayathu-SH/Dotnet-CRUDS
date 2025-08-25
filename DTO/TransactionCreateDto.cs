using System.ComponentModel.DataAnnotations;

namespace CrudApp.DTO
{
    public class TransactionCreateDto
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
