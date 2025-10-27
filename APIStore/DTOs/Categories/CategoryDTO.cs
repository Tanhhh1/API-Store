using System.ComponentModel.DataAnnotations;

namespace APIStore.DTOs.Categories
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}