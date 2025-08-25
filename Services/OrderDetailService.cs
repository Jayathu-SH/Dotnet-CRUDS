using CrudApp.DTO;
using CrudApp.Models;
using CrudApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CrudApp.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repo;
        public OrderDetailService(IOrderDetailRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<OrderDetailResponseDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(e => new OrderDetailResponseDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                ProductId = e.ProductId,
                Quantity = e.Quantity,
                UnitPrice = e.UnitPrice
            });
        }

        public async Task<OrderDetailResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;
            return new OrderDetailResponseDto
            {
                Id = entity.Id,
                OrderId = entity.OrderId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice
            };
        }

        public async Task<OrderDetailResponseDto> CreateAsync(OrderDetailCreateDto dto)
        {
            var entity = new OrderDetail
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };
            var created = await _repo.CreateAsync(entity);
            return new OrderDetailResponseDto
            {
                Id = created.Id,
                OrderId = created.OrderId,
                ProductId = created.ProductId,
                Quantity = created.Quantity,
                UnitPrice = created.UnitPrice
            };
        }

        public async Task<OrderDetailResponseDto?> UpdateAsync(int id, OrderDetailUpdateDto dto)
        {
            var entity = new OrderDetail
            {
                Id = dto.Id,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };
            var updated = await _repo.UpdateAsync(id, entity);
            if (updated == null) return null;
            return new OrderDetailResponseDto
            {
                Id = updated.Id,
                OrderId = updated.OrderId,
                ProductId = updated.ProductId,
                Quantity = updated.Quantity,
                UnitPrice = updated.UnitPrice
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
