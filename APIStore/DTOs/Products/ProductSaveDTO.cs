using System.ComponentModel.DataAnnotations;

namespace APIStore.DTOs.Products
{
    public class ProductSaveDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
