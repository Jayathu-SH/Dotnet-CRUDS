namespace CrudApp.Models
{
    public class Order
    {
        public int Id { get; set; }  
        public decimal TotalPrice { get; set; }  
        public DateTime OrderDate { get; set; }  
        public string? Status { get; set; } = "Pending";

        // Navigation property for EF Core relationship
        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
