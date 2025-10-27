using APIStore.DTOs.Categories;
using APIStore.DTOs.Products;
using APIStore.Models;
using APIStore.Repositories;
using APIStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly CategoryRepository _categoryRepo;

        public ProductService(ProductRepository productRepo, CategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            var products = await _productRepo.GetAllProduct();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Categories.Name,
                Price = p.Price,
                Description = p.Description,
            });
        }

        public async Task<ProductDTO?> GetProductById(int id)
        {
            var p = await _productRepo.GetProductById(id);
            if (p == null) return null;
            return new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Categories.Name,
                Price = p.Price,
                Description = p.Description,
            };
        }

        public async Task<ProductSaveDTO> CreateProduct(ProductSaveDTO dto)
        {
            var categoryExists = await _categoryRepo.Exists(dto.CategoryId);
            if (!categoryExists)
                throw new Exception($"Danh mục không tồn tại.");

            var entity = new Products
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                Description = dto.Description,
            };

            var created = await _productRepo.CreateProduct(entity);

            return new ProductSaveDTO
            {
                Name = created.Name,
                CategoryId = created.CategoryId,
                Price = created.Price,
                Description = created.Description,
            };
        }
        public async Task<bool> UpdateProduct(int id, ProductSaveDTO dto)
        {
            var categoryExists = await _categoryRepo.Exists(dto.CategoryId);
            if (!categoryExists)
                throw new Exception($"Danh mục không tồn tại.");

            var exists = await _productRepo.GetProductById(id);
            if (exists == null) return false;

            exists.Name = dto.Name;
            exists.CategoryId = dto.CategoryId;
            exists.Price = dto.Price;
            exists.Description = dto.Description;

            await _productRepo.UpdateProduct(exists);
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var entity = await _productRepo.GetProductById(id);
            if (entity == null) return false;

            await _productRepo.DeleteProduct(entity);
            return true;
        }
    }
}
