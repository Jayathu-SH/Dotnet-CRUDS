using CrudApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApp.Repository
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task<OrderDetail> CreateAsync(OrderDetail orderDetail);
        Task<OrderDetail?> UpdateAsync(int id, OrderDetail orderDetail);
        Task<bool> DeleteAsync(int id);
    }
}
