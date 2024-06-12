namespace ManagementMBClient.DTOs
{
    public class LiabilitiiesDTO:BaseEntity
    {
        public LiabilitiiesCategory Category { get; set; }
        public string Name { get; set; }=string.Empty;
        public double Amount { get; set; }
       
    }
}
