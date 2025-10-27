namespace APIStore.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customers? Customers { get; set; }
        public ICollection<OrderItems>? OrderItems { get; set; }
    }
}
