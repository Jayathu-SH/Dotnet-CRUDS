using System;
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty; // e.g., Cash, Card

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Order? Order { get; set; }
    }
}
