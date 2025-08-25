namespace CrudApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }      // Foreign key to Order
        public int ProductId { get; set; }    // Foreign key to Product
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Price at the time of sale

        // Navigation properties
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}