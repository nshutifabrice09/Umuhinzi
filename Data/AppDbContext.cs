using Microsoft.EntityFrameworkCore;
using Umuhinzi.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Farm> Farms => Set<Farm>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Batch> Batches => Set<Batch>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<AuditReport> AuditReports => Set<AuditReport>();
    public DbSet<HarvestRecord> HarvestRecords => Set<HarvestRecord>();
    public DbSet<PracticeRecord> PracticeRecords => Set<PracticeRecord>();
    public DbSet<TransportLog> TransportLogs => Set<TransportLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // @Enumerated(EnumType.STRING)
        modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
        modelBuilder.Entity<Role>().Property(r => r.Name).HasConversion<string>();

        //@Column(Unique = true)
        modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
    }
}
