namespace Umuhinzi.Models
{
    public class TransportLog
    {
        public long Id { get; set; }
        public DateOnly ShippedAt { get; set; }
        public DateOnly? ReceivedAt { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string Transporter { get; set; } = string.Empty;

        public long? BatchId { get; set; }
        public Batch? Batch { get; set; }
    }
}
