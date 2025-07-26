namespace CrudApp.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<CrudApp.Models.Order>> GetAllAsync();
        Task<CrudApp.Models.Order?> GetByIdAsync(int id);
        Task<CrudApp.Models.Order> CreateAsync(CrudApp.Models.Order order);
        Task<CrudApp.Models.Order?> UpdateAsync(int id, CrudApp.Models.Order order);
        Task<bool> DeleteAsync(int id);
    }
}
