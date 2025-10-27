namespace APIStore.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Orders? Orders { get; set; }
        public Products? Products { get; set; }
    }

}
