namespace CrudApp.DTOs
{
    public class OrderUpdateDto
    {
        // The quantity of the product in the order (to be updated)
        public int Quantity { get; set; }

        // "Pending", "Shipped", "Delivered"
        public string? Status { get; set; }
    }
}
