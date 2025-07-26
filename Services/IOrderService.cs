using CrudApp.DTOs;
namespace CrudApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(int id);
        Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto orderDto);
        Task<OrderResponseDto> UpdateOrderAsync(int id, OrderUpdateDto orderDto);
        Task<bool> DeleteOrderAsync(int id);
    }
}
