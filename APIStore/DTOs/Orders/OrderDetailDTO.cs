namespace APIStore.DTOs.Orders
{
    public class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? CustomerName { get; set; }

        public List<OrderItemDetailDTO> Items { get; set; } = new();
    }

    public class OrderItemDetailDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal => Quantity * UnitPrice;
    }

}