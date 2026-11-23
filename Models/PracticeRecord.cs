namespace Umuhinzi.Models
{
    public class PracticeRecord
    {
        public long Id { get; set; }
        public string PracticeType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateApplied { get; set; }

        public long? BatchId { get; set; }
        public Batch? Batch { get; set; }
    }
}
