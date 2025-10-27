using APIStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStore.Repositories
{
    public class CustomerRepository
    {
        private readonly StoreDbContext _db;

        public CustomerRepository(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customers>> GetAllCustomer()
        {
            return await _db.Customers
                .ToListAsync();
        }

        public async Task<Customers?> GetCustomerById(int id)
        {
            return await _db.Customers
                .FirstOrDefaultAsync(c => c.Id == id); ;
        }
    }
}
