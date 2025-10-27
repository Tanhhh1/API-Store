using APIStore.DTOs.Categories;
using APIStore.Models;
using APIStore.Repositories;
using APIStore.Services.Interfaces;

namespace APIStore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepo;

        public CategoryService(CategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var categories = await _categoryRepo.GetAllCategory();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            });
        }

        public async Task<CategoryDTO?> GetCategoryById(int id)
        {
            var c = await _categoryRepo.GetCategoryById(id);
            if (c == null) return null;
            return new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            };
        }

        public async Task<CategorySaveDTO> CreateCategory(CategorySaveDTO dto)
        {
            var entity = new Categories
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            var created = await _categoryRepo.CreateCategory(entity);

            return new CategorySaveDTO
            {
                Name = created.Name,
                Description = created.Description,
            };
        }

        public async Task<bool> UpdateCategory(int id, CategorySaveDTO dto)
        {
            var exists = await _categoryRepo.GetCategoryById(id);
            if (exists == null) return false;
            exists.Name = dto.Name;
            exists.Description = dto.Description;
            await _categoryRepo.UpdateCategory(exists);
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var entity = await _categoryRepo.GetCategoryById(id);
            if (entity == null) return false;

            await _categoryRepo.DeleteCategory(entity);
            return true;
        }
    }
}
