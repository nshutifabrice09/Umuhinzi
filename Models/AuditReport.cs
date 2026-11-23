namespace Umuhinzi.Models
{
    public class AuditReport
    {
        public long Id { get; set; }
        public string AuditorName { get; set; } = string.Empty;
        public DateOnly AuditDate { get; set; }
        public string? ReportUrl { get; set; }
        public bool Passed { get; set; }

        public long? FarmId { get; set; }
        public Farm? Farm { get; set; }
    }
}
