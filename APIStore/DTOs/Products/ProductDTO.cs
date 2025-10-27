namespace APIStore.DTOs.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
