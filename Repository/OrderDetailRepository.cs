using CrudApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApp.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly Data.ApplicationDbContext _context;
        public OrderDetailRepository(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail?> GetByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<OrderDetail?> UpdateAsync(int id, OrderDetail orderDetail)
        {
            var existing = await _context.OrderDetails.FindAsync(id);
            if (existing == null) return null;
            existing.Quantity = orderDetail.Quantity;
            existing.UnitPrice = orderDetail.UnitPrice;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.OrderDetails.FindAsync(id);
            if (existing == null) return false;
            _context.OrderDetails.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
