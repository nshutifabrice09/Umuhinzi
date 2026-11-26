using Umuhinzi.Models;

namespace Umuhinzi.Dtos;

public static class FarmMappings
{
    public static FarmResponse ToResponse(this Farm farm) => new(
        farm.Id,
        farm.Name,
        farm.Location,
        farm.CertificationId,
        farm.Verified,
        farm.OwnerId,
        farm.Owner?.Username);
}