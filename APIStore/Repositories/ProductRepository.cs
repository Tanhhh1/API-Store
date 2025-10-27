using APIStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIStore.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDbContext _db;

        public ProductRepository(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<List<Products>> GetAllProduct()
        {
            return await _db.Products
                .Include(p => p.Categories)
                .ToListAsync();
        }

        public async Task<Products?> GetProductById(int id)
        {
            return await _db.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(c => c.Id == id); ;
        }
        public async Task<Products> CreateProduct(Products product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProduct(Products product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProduct(Products product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}
