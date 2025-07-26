namespace CrudApp.DTOs
{
    public class OrderCreateDto
    {
        // The ID of the product that the order is for
        public int ProductId { get; set; }

        // The quantity of the product in the order
        public int Quantity { get; set; }
    }
}
