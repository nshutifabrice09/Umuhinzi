using Umuhinzi.Dtos;

namespace Umuhinzi.Services;

public interface IFarmService
{
    Task<IReadOnlyList<FarmResponse>> GetAllAsync(CancellationToken ct = default);
    Task<FarmResponse> GetByIdAsync(long id, CancellationToken ct = default);
    Task<FarmResponse> CreateAsync(CreateFarmRequest request, CancellationToken ct = default);
    Task<FarmResponse> UpdateAsync(long id, UpdateFarmRequest request, CancellationToken ct = default);
    Task DeleteAsync(long id, CancellationToken ct = default);
}