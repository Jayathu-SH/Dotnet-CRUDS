using CrudApp.DTO;
using CrudApp.Models;
using CrudApp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CrudApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;
        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(e => new TransactionResponseDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                Amount = e.Amount,
                PaymentMethod = e.PaymentMethod,
                TransactionDate = e.TransactionDate
            });
        }

        public async Task<TransactionResponseDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;
            return new TransactionResponseDto
            {
                Id = entity.Id,
                OrderId = entity.OrderId,
                Amount = entity.Amount,
                PaymentMethod = entity.PaymentMethod,
                TransactionDate = entity.TransactionDate
            };
        }

        public async Task<TransactionResponseDto> CreateAsync(TransactionCreateDto dto)
        {
            var entity = new Transaction
            {
                OrderId = dto.OrderId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod
            };
            var created = await _repo.CreateAsync(entity);
            return new TransactionResponseDto
            {
                Id = created.Id,
                OrderId = created.OrderId,
                Amount = created.Amount,
                PaymentMethod = created.PaymentMethod,
                TransactionDate = created.TransactionDate
            };
        }

        public async Task<TransactionResponseDto?> UpdateAsync(int id, TransactionUpdateDto dto)
        {
            var entity = new Transaction
            {
                Id = dto.Id,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod
            };
            var updated = await _repo.UpdateAsync(id, entity);
            if (updated == null) return null;
            return new TransactionResponseDto
            {
                Id = updated.Id,
                OrderId = updated.OrderId,
                Amount = updated.Amount,
                PaymentMethod = updated.PaymentMethod,
                TransactionDate = updated.TransactionDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
