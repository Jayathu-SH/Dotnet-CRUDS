namespace CrudApp.Models
{
    public class Order
    {
        public int Id { get; set; }  
        public int ProductId { get; set; }  // foreign key to Product
        public int Quantity { get; set; }  
        public decimal TotalPrice { get; set; }  
        public DateTime OrderDate { get; set; }  
        public string? Status { get; set; } = "Pending";

        // Navigation property for EF(entity framework) Core relationship
        public Product? Product { get; set; }
    }
}
