using Microsoft.EntityFrameworkCore;
using Umuhinzi.Data;
using Umuhinzi.Models;

namespace Umuhinzi.Repositories;

public class FarmRepository(AppDbContext db) : IFarmRepository
{
    public Task<List<Farm>> GetAllAsync(CancellationToken ct = default) =>
            db.Farms.AsNoTracking()
                .Include(f => f.Owner)
                .OrderBy(f => f.Id)
                .ToListAsync(ct);

    public Task<Farm?> GetByIdAsync(long id, CancellationToken ct = default) =>
        db.Farms
            .Include(f => f.Owner)
            .FirstOrDefaultAsync(f => f.Id == id, ct);

    public async Task<Farm> AddAsync(Farm farm, CancellationToken ct = default)
    {
        db.Farms.Add(farm);
        await db.SaveChangesAsync(ct);
        return farm;
    }

    public Task UpdateAsync(Farm farm, CancellationToken ct = default) =>
        db.SaveChangesAsync(ct);

    public async Task DeleteAsync(Farm farm, CancellationToken ct = default)
    {
        db.Farms.Remove(farm);
        await db.SaveChangesAsync(ct);
    }
}