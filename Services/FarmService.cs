using Umuhinzi.Dtos;
using Umuhinzi.Exceptions;
using Umuhinzi.Models;
using Umuhinzi.Repositories;

namespace Umuhinzi.Services;

public class FarmService(IFarmRepository farms, IUserRepository users) : IFarmService
{
    public async Task<IReadOnlyList<FarmResponse>> GetAllAsync(CancellationToken ct = default)
    {
        var all = await farms.GetAllAsync(ct);
        return all.Select(f => f.ToResponse()).ToList();
    }

    public async Task<FarmResponse> GetByIdAsync(long id, CancellationToken ct = default)
    {
        var farm = await farms.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Farm), id);
        return farm.ToResponse();
    }

    public async Task<FarmResponse> CreateAsync(CreateFarmRequest request, CancellationToken ct = default)
    {
        var farm = new Farm
        {
            Name = request.Name,
            Location = request.Location,
            CertificationId = request.CertificationId,
            Owner = await ResolveOwnerAsync(request.OwnerId, ct)
        };

        await farms.AddAsync(farm, ct);
        return farm.ToResponse();
    }

    public async Task<FarmResponse> UpdateAsync(long id, UpdateFarmRequest request, CancellationToken ct = default)
    {
        var farm = await farms.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Farm), id);

        farm.Name = request.Name;
        farm.Location = request.Location;
        farm.CertificationId = request.CertificationId;
        farm.Owner = await ResolveOwnerAsync(request.OwnerId, ct);

        await farms.UpdateAsync(farm, ct);
        return farm.ToResponse();
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var farm = await farms.GetByIdAsync(id, ct)
            ?? throw new NotFoundException(nameof(Farm), id);

        await farms.DeleteAsync(farm, ct);
    }

    private async Task<User?> ResolveOwnerAsync(long? ownerId, CancellationToken ct)
    {
        if (ownerId is null) return null;

        return await users.GetByIdAsync(ownerId.Value, ct)
            ?? throw new BadRequestException($"Owner with id {ownerId} does not exist.");
    }
}