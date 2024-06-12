namespace ManagementMBClient.DTOs
{
    public class Sale:BaseEntity
    {
        public double Quantity { get; set; }
        public double Price { get; set; }
       
        public double TotalPrice { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public User? User { get; set; }
        public Guid UserId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}

