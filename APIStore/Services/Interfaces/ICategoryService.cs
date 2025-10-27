using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIStore.DTOs.Categories;

namespace APIStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategory();
        Task<CategoryDTO?> GetCategoryById(int id);
        Task<CategorySaveDTO> CreateCategory(CategorySaveDTO dto);
        Task<bool> UpdateCategory(int id, CategorySaveDTO dto);
        Task<bool> DeleteCategory(int id);
    }
}
