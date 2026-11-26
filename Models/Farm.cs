namespace Umuhinzi.Models
{
    public class Farm
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? CertificationId { get; set; }
        public bool Verified { get; set; }

        public long? OwnerId { get; set; }
        public User? Owner { get; set; }
    }
}
