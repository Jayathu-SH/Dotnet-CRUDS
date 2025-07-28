using CrudApp.DTOs;
namespace CrudApp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync();
        Task<CustomerResponseDto> GetCustomerByIdAsync(int id);
        Task<CustomerResponseDto> CreateCustomerAsync(CustomerCreateDto customerDto);
        Task<CustomerResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
