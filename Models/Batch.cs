namespace Umuhinzi.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public DateOnly HarvestDate { get; set; }
        public string? OriginCoardinaties { get; set; }
        public string? QrCodeUrl { get; set; }
        public long? ProductId { get; set; }
        public Product? Product { get; set; }
        public long? FarmId { get; set; }
        public Farm? Farm { get; set; }
    }
}
