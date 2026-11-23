namespace Umuhinzi.Models
{
    public class Certificate
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string IssuedOrganization { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DocumentUrl { get; set; } = string.Empty;
        public long? FarmId { get; set; }
        public Farm? Farm { get; set; }

    }
}
