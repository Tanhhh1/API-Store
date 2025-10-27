using System.ComponentModel.DataAnnotations;

namespace APIStore.DTOs.Categories
{
    public class CategorySaveDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
