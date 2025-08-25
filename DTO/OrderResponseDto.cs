namespace CrudApp.DTOs
{
    public class OrderResponseDto
    {
       
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }

    public List<OrderDetailResponseDto>? OrderDetails { get; set; }
    }
}
