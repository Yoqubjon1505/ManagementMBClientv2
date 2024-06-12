namespace ManagementMBClient.DTOs
{
    public class Expenses : BaseEntity
    {
        public double Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        
    }
}
