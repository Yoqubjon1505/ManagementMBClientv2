namespace ManagementMBClient.DTOs
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            
        }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

    }
}
