using CrudApp.DTOs;
using CrudApp.Models;
using CrudApp.Repositories;
namespace CrudApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(order => new OrderResponseDto
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status
            });
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is null)
                throw new KeyNotFoundException();
            var o = order!;
            return new OrderResponseDto
            {
                Id = o.Id,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                TotalPrice = o.TotalPrice,
                OrderDate = o.OrderDate,
                Status = o.Status
            };
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var order = new CrudApp.Models.Order
            {
                ProductId = orderDto.ProductId,
                Quantity = orderDto.Quantity,
                TotalPrice = orderDto.Quantity * 100,  // Just for example, calculate the price based on quantity
                OrderDate = DateTime.UtcNow,
                Status = "Pending"
            };

            var createdOrder = await _orderRepository.CreateAsync(order);
            return new OrderResponseDto
            {
                Id = createdOrder.Id,
                ProductId = createdOrder.ProductId,
                Quantity = createdOrder.Quantity,
                TotalPrice = createdOrder.TotalPrice,
                OrderDate = createdOrder.OrderDate,
                Status = createdOrder.Status
            };
        }

        public async Task<OrderResponseDto> UpdateOrderAsync(int id, OrderUpdateDto orderDto)
        {
            var order = new CrudApp.Models.Order
            {
                Quantity = orderDto.Quantity,
                Status = orderDto.Status!
            };

            var updatedOrder = await _orderRepository.UpdateAsync(id, order);
            if (updatedOrder is null)
                throw new KeyNotFoundException();
            return new OrderResponseDto
            {
                Id = updatedOrder.Id,
                ProductId = updatedOrder.ProductId,
                Quantity = updatedOrder.Quantity,
                TotalPrice = updatedOrder.TotalPrice,
                OrderDate = updatedOrder.OrderDate,
                Status = updatedOrder.Status
            };
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }
}
