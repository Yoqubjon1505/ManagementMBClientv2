namespace ManagementMBClient.DTOs
{
    public class BalanceDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public double CurrentAssets { get; set; }
        public double Availability { get; set; } // касса и сбережения
        public double Debtors { get; set; }
        public double StockProducts { get; set; }
        public double FixedAssets { get; set; }
        public double Transport { get; set; }
        public double Equipment { get; set; }
        public double Building { get; set; }
        public double Liabilitiies { get; set; }
        public double Capital { get; set; }
    }
}
