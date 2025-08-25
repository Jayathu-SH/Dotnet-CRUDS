using CrudApp.DTO;
using CrudApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApp.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailResponseDto>> GetAllAsync();
        Task<OrderDetailResponseDto?> GetByIdAsync(int id);
        Task<OrderDetailResponseDto> CreateAsync(OrderDetailCreateDto dto);
        Task<OrderDetailResponseDto?> UpdateAsync(int id, OrderDetailUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
