using Microsoft.EntityFrameworkCore;
using APIStore.Models;

namespace APIStore.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbContext _db;

        public CategoryRepository(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<Categories>> GetAllCategory()
        {
            return await _db.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Categories?> GetCategoryById(int id)
        {
            return await _db.Categories
                .FirstOrDefaultAsync(c => c.Id == id); ;
        }

        public async Task<Categories> CreateCategory(Categories category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task UpdateCategory(Categories category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCategory(Categories category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await _db.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
