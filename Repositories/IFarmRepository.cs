using Umuhinzi.Models;

namespace Umuhinzi.Repositories;

public interface IFarmRepository
{
    Task<List<Farm>> GetAllAsync (CancellationToken ct = default);
    Task<Farm?> GetByIdAsync(CancellationToken ct = default);
    Task<Farm> AddAsync(Farm farm, CancellationToken ct = default);
    Task UpdateAsync(Farm farm, CancellationToken ct = default);
    Task DeleteAsync(Farm farm, CancellationToken ct = default);
}