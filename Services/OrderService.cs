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
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status,
                OrderDetails = order.OrderDetails?.Select(od => new OrderDetailResponseDto
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            });
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is null)
                throw new KeyNotFoundException();
            return new OrderResponseDto
            {
                Id = order.Id,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status,
                OrderDetails = order.OrderDetails?.Select(od => new OrderDetailResponseDto
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            };
        }

        public async Task<OrderResponseDto> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var order = new CrudApp.Models.Order
            {
                TotalPrice = 0,
                OrderDate = DateTime.UtcNow,
                Status = "Pending"
            };
            var createdOrder = await _orderRepository.CreateAsync(order);
            return new OrderResponseDto
            {
                Id = createdOrder.Id,
                TotalPrice = createdOrder.TotalPrice,
                OrderDate = createdOrder.OrderDate,
                Status = createdOrder.Status,
                OrderDetails = new List<OrderDetailResponseDto>()
            };
        }

        public async Task<OrderResponseDto> UpdateOrderAsync(int id, OrderUpdateDto orderDto)
        {
            var order = new CrudApp.Models.Order
            {
                Status = orderDto.Status!
            };
            var updatedOrder = await _orderRepository.UpdateAsync(id, order);
            if (updatedOrder is null)
                throw new KeyNotFoundException();
            return new OrderResponseDto
            {
                Id = updatedOrder.Id,
                TotalPrice = updatedOrder.TotalPrice,
                OrderDate = updatedOrder.OrderDate,
                Status = updatedOrder.Status,
                OrderDetails = updatedOrder.OrderDetails?.Select(od => new OrderDetailResponseDto
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            };
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }
}
