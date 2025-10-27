using APIStore.DTOs.Customers;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomer();
        Task<CustomerDTO?> GetCustomerById(int id);
    }
}
