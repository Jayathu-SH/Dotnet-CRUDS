using CrudApp.Data;
using CrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CrudApp.Models.Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<CrudApp.Models.Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<CrudApp.Models.Order> CreateAsync(CrudApp.Models.Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<CrudApp.Models.Order?> UpdateAsync(int id, CrudApp.Models.Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
                return null;

            existingOrder.Quantity = order.Quantity;
            existingOrder.Status = order.Status;
            existingOrder.TotalPrice = order.Quantity * existingOrder.TotalPrice;  // Recalculate price if needed

            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
