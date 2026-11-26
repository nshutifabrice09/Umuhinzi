using Umuhinzi.Models;

namespace Umuhinzi.Dtos;

public static class FarmMappings
{
    public static FarmResponse ToFarmResponse(this Farm farm) => new(
        farm.Id,
        farm.Name,
        farm.Location,
        farm.CertificationId,
        farm.Verified,
        farm.OwnedId,
        farm.Owner?.Username
    );

}