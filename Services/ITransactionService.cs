using CrudApp.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApp.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionResponseDto>> GetAllAsync();
        Task<TransactionResponseDto?> GetByIdAsync(int id);
        Task<TransactionResponseDto> CreateAsync(TransactionCreateDto dto);
        Task<TransactionResponseDto?> UpdateAsync(int id, TransactionUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
