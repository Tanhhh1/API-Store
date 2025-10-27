﻿namespace APIStore.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public Categories? Categories { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
