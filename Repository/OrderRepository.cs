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
            return await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        public async Task<CrudApp.Models.Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
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

            existingOrder.Status = order.Status;
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
