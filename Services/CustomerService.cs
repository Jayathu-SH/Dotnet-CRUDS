using CrudApp.DTOs;
using CrudApp.Models;
using CrudApp.Repositories;
namespace CrudApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(customer => new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                CreatedDate = customer.CreatedDate,
                UpdatedDate = customer.UpdatedDate
            });
        }

        public async Task<CustomerResponseDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer is null)
                throw new KeyNotFoundException();
            var c = customer!;//null-forgiving operator (!), customer is not null at this point(to compiler).
            return new CustomerResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                CreatedDate = c.CreatedDate,
                UpdatedDate = c.UpdatedDate
            };
        }

        public async Task<CustomerResponseDto> CreateCustomerAsync(CustomerCreateDto customerDto)
        {
            var customer = new CrudApp.Models.Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address
            };

            var createdCustomer = await _customerRepository.CreateAsync(customer);
            return new CustomerResponseDto
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                Email = createdCustomer.Email,
                Phone = createdCustomer.Phone,
                Address = createdCustomer.Address,
                CreatedDate = createdCustomer.CreatedDate
            };
        }

        public async Task<CustomerResponseDto> UpdateCustomerAsync(int id, CustomerUpdateDto customerDto)
        {
            var customer = new CrudApp.Models.Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address
            };

            var updatedCustomer = await _customerRepository.UpdateAsync(id, customer);
            if (updatedCustomer is null)
                throw new KeyNotFoundException();

            return new CustomerResponseDto
            {
                Id = updatedCustomer.Id,
                Name = updatedCustomer.Name,
                Email = updatedCustomer.Email,
                Phone = updatedCustomer.Phone,
                Address = updatedCustomer.Address,
                CreatedDate = updatedCustomer.CreatedDate,
                UpdatedDate = updatedCustomer.UpdatedDate
            };
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }
    }
}
