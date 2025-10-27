using APIStore.DTOs.Categories;
using APIStore.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProduct();
        Task<ProductDTO?> GetProductById(int id);
        Task<ProductSaveDTO> CreateProduct(ProductSaveDTO dto);
        Task<bool> UpdateProduct(int id, ProductSaveDTO dto);
        Task<bool> DeleteProduct(int id);
    }
}
