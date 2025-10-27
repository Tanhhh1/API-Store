using APIStore.DTOs.Customers;
using APIStore.Repositories;
using APIStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepo;

        public CustomerService(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomer()
        {
            var categories = await _customerRepo.GetAllCustomer();
            return categories.Select(c => new CustomerDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
            });
        }

        public async Task<CustomerDTO?> GetCustomerById(int id)
        {
            var c = await _customerRepo.GetCustomerById(id);
            if (c == null) return null;
            return new CustomerDTO
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
            };
        }
    }
}
