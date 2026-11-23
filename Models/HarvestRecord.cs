namespace Umuhinzi.Models
{
    public class HarvestRecord
    {
        public long Id { get; set; }
        public DateOnly HarvestDate { get; set; }
        public double YieldAmount { get; set; }
        public string Method { get; set; } = string.Empty;

        public long? BatchId { get; set; }
        public Batch? Batch { get; set; }
    }
}
